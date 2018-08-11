using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 prevMouse, currentMouse;

    public GameObject mainCamera;

    public float angle, distance;
    
    private void Start()
    {
        //if(isServer)
        //    GameObject.Find("Canvas").transform.Find("WaitGame").gameObject.SetActive(true);

        //StartInit();
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
        prevMouse = Input.mousePosition;
    }

    public void TouchOut()
    {
        currentMouse = Input.mousePosition;

        rigidbody2D.AddForce(prevMouse - currentMouse);

        distance = Vector2.Distance(prevMouse, currentMouse);
        angle = Vector2.Angle(prevMouse, currentMouse);

        //player.transform.eulerAngles = new Vector3(0, 0, angle);

        //player.transform.Translate(Vector2.up * 1);
        
        //Debug.Log("Distance: " + distance.ToString());
        //Debug.Log("Angle: " + angle.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeadLine")
        {
            NetworkManager.Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "ItemA")
        {
            StopCoroutine(EatItemA());
            StartCoroutine(EatItemA());
            
            NetworkManager.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ItemB")
        {
            StopCoroutine(EatItemB());
            StartCoroutine(EatItemB());
            
            NetworkManager.Destroy(collision.gameObject);
        }

        //Debug.Log(collision.gameObject.tag);
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
}
