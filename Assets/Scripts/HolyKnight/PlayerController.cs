using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PlayerController : NetworkBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 prevMouse, currentMouse;

    public GameObject mainCamera;

    public float angle, distance;
    public bool isFreeze = false;

    [SyncVar]
    public string username = "Holy-Knight";
    
    private void Start()
    {
        CmdChangeName(GameManager.Instance.username);
    }

    void StartInit()
    {
        if (!isLocalPlayer)
        {
            Debug.Log("FAKE");
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.35f);
            return;
        }

        GameManager.Instance.StartGame();
        mainCamera = GameObject.Find("Main Camera");

        if (isServer)
        {
            UIManager.Instance.HideWait();

            GameObject.Find("ItemManager").GetComponent<ItemManager>().SpawnItem();
            Debug.Log("CREATE ITEM - It is Server");
        }
        else
        {
            if (GameObject.Find("JoinGame").activeSelf)
                GameObject.Find("JoinGame").SetActive(false);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            CmdCheckName(username);
        }

        if ( (!GameManager.Instance.isPlaying && NetworkServer.connections.Count == 2) || (!isServer && !GameManager.Instance.isPlaying))
        {
            StartInit();
        }

        if (!isLocalPlayer || !GameManager.Instance.isPlaying)
            return;

        if (Input.GetMouseButtonDown(0))
            TouchIn();
        else if (Input.GetMouseButtonUp(0))
            TouchOut();

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector2.down * .05f);

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, -10);
	}

    public void TouchIn()
    {
        if (isFreeze)
            return;

        prevMouse = Input.mousePosition;
    }

    public void TouchOut()
    {
        if (isFreeze)
            return;

        currentMouse = Input.mousePosition;
        rigidbody2D.AddForce(prevMouse - currentMouse);

        distance = Vector2.Distance(prevMouse, currentMouse);
        angle = Vector2.Angle(prevMouse, currentMouse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeadLine")
        {
            //NetworkManager.Destroy(this.gameObject);
            StartCoroutine(Freeze());
        }

        if (collision.gameObject.tag == "ItemA")
        {
            CmdEatItemA();
            
            NetworkManager.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ItemB")
        {
            CmdEatItemB();

            NetworkManager.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ItemC")
        {
            CmdEatItemC(username);

            NetworkManager.Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "FinishLine")
        {
            CmdResult(username);
        }

        //Debug.Log(collision.gameObject.tag);
    }

    [Command]
    void CmdChangeName(string name)
    {
        RpcChangeName(name);
    }

    [ClientRpc]
    void RpcChangeName(string name)
    {
        username = name;

        if (!isLocalPlayer)
            GameManager.Instance.playerName[1] = username;
    }

    [Command]
    void CmdCheckName(string name)
    {
        RpcCheckName(name);
    }

    [ClientRpc]
    void RpcCheckName(string name)
    {
        Debug.Log(name);
    }

    [Command]
    void CmdResult(string name)
    {
        RpcResult(name);
    }

    [ClientRpc]
    void RpcResult(string name)
    {
        int endrophin;
        int exp;
        bool isLevelup = false;
        bool isWin = false;
        
        if (GameManager.Instance.username == name)
        {
            exp = 500 + Random.Range(150, 400);

            if (GameManager.Instance.IncreaseExp(exp))
            {
                endrophin = 500;
                isLevelup = true;
            }
            else
                endrophin = 20 + Random.Range(10, 30);

            isWin = true;

            Debug.Log(name + ": WIN - " + username);
        }
        else
        {
            exp = 350 + Random.Range(50, 150);

            if (GameManager.Instance.IncreaseExp(exp))
            {
                endrophin = 500;
                isLevelup = true;
            }
            else
                endrophin = 10 + Random.Range(5, 15);

            Debug.Log(name + ": LOSE - " + username);
        }
        UIManager.Instance.ShowResult();
        UIManager.Instance.SetResultData(isWin, isLevelup, endrophin, exp);

        //MatchInfo matchInfo = NetworkManager.singleton.matchInfo;
        //NetworkManager.singleton.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, NetworkManager.singleton.OnDropConnection);
        //NetworkManager.singleton.StopHost();
    }

    [Command]
    void CmdEatItemA()
    {
        StopCoroutine(EatItemA());
        RpcEatItemA();
    }

    [ClientRpc]
    void RpcEatItemA()
    {
        StartCoroutine(EatItemA());
    }

    [Command]
    void CmdEatItemB()
    {
        StopCoroutine(EatItemB());
        RpcEatItemB();
    }

    [ClientRpc]
    void RpcEatItemB()
    {
        StartCoroutine(EatItemB());
    }

    [Command]
    void CmdEatItemC(string name)
    {
        StopCoroutine(EatItemC());
        RpcEatItemC(name);
    }

    [ClientRpc]
    void RpcEatItemC(string name)
    {
        if(GameManager.Instance.username != name)
            StartCoroutine(EatItemC());

        //if (isClient != server)
        //    StartCoroutine(EatItemC());
    }

    IEnumerator Freeze()
    {
        isFreeze = true;
        yield return new WaitForSeconds(2f);

        isFreeze = false;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    private IEnumerator EatItemA()
    {
        rigidbody2D.drag = 20f;
        yield return new WaitForSeconds(3f);

        rigidbody2D.drag = 10f;
    }

    private IEnumerator EatItemB()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1);
        yield return new WaitForSeconds(4f);

        transform.localScale = new Vector3(0.2f, 0.2f, 1);
    }

    private IEnumerator EatItemC()
    {
        rigidbody2D.drag = 1000f;
        yield return new WaitForSeconds(2f);

        rigidbody2D.drag = 10f;
    }
}
