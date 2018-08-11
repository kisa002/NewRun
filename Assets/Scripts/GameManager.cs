using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

    public bool isPlaying = false;

    private void Awake()
    {
        if (GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(this.gameObject);

#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
        Screen.fullScreen = false;
#endif
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public void EndGame()
    {
        isPlaying = false;
    }
}
