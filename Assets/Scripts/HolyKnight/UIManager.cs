using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject waitGame, hostGame, mainGame, joinGame, resultGame;
    public Text textResult, textResultBonus, textResultEndrophin, textResultExp, textName;
    public Transform back1, back2, back3;

    private void Awake()
    {
        if (UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void SetUsername()
    {
        GameManager.Instance.username = textName.text;
        GameManager.Instance.playerName[0] = textName.text;

        GameObject.Find("NameGame").SetActive(false);

        UIManager.Instance.ShowMain();
    }

    public void SetResultData(bool isWin, bool isLevelup, int endrophin, int exp)
    {
        if (isWin)
        {
            textResult.text = "합격";
            textResult.color = Color.white;
        }
        else
        {
            textResult.text = "불합격";
            textResult.color = new Color(176f / 255f, 26f / 255f, 26f / 255f);
        }

        if (isLevelup)
            textResultBonus.gameObject.SetActive(true);

        textResultEndrophin.text = endrophin.ToString();
        textResultExp.text = "EXP + " + exp.ToString();
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
        resultGame.SetActive(false);
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

    public void ShowResult()
    {
        resultGame.SetActive(true);
        mainGame.SetActive(false);
        joinGame.SetActive(false);
        hostGame.SetActive(false);
        waitGame.SetActive(false);
    }

    public void HideResult()
    {
        resultGame.SetActive(false);
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
