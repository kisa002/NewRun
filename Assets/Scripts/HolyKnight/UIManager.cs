using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform back1, back2, back3;

    public void ShowHostGame()
    {
        GameObject.Find("Canvas").transform.Find("HostGame").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("MainGame").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("JoinGame").gameObject.SetActive(false);
    }

    public void ShowJoinGame()
    {
        GameObject.Find("Canvas").transform.Find("JoinGame").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("HostGame").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("MainGame").gameObject.SetActive(false);
    }

    public void ShowMain()
    {
        GameObject.Find("Canvas").transform.Find("MainGame").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("JoinGame").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("HostGame").gameObject.SetActive(false);
    }

    private void Update()
    {
        if(GameManager.Instance.isPlaying)
            GameBackground();
    }

    private void GameBackground()
    {
        back1.transform.Translate(Vector2.down * 0.05f * Time.deltaTime);
        back2.transform.Translate(Vector2.down * 0.065f * Time.deltaTime);
        //back1.transform.Translate(Vector2.up * 2f * Time.deltaTime);
    }
}
