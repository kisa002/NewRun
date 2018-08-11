using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void ShowHostGame()
    {
        GameObject.Find("Canvas").transform.Find("HostGame").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("JoinGame").gameObject.SetActive(false);
    }

    public void ShowJoinGame()
    {
        GameObject.Find("Canvas").transform.Find("JoinGame").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("HostGame").gameObject.SetActive(false);
    }
}
