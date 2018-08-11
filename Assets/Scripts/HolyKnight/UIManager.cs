using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject waitGame, hostGame, mainGame, joinGame;
    public Transform back1, back2, back3;

    private void Awake()
    {
        if (UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void ShowHostGame()
    {
        hostGame.SetActive(true);
        mainGame.SetActive(false);
        joinGame.SetActive(false);
    }

    public void ShowJoinGame()
    {
        joinGame.SetActive(true);
        hostGame.SetActive(false);
        mainGame.SetActive(false);
    }

    public void ShowMain()
    {
        mainGame.SetActive(true);
        joinGame.SetActive(false);
        hostGame.SetActive(false);
    }

    public void ShowWait()
    {
        waitGame.SetActive(true);
    }

    public void HideWait()
    {
        mainGame.SetActive(false);
        joinGame.SetActive(false);
        hostGame.SetActive(false);
        waitGame.SetActive(false);
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
