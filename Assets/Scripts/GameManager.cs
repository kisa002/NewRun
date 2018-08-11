using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

    public bool isPlaying = false;

    public int level = 1;
    public int endrophin = 100;
    public int currentExp = 0;
    public int maxExp = 100;

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

    public void IncreaseEndrophin(int amount)
    {
        endrophin += amount;
    }

    public void DecreaseEndrophin(int amount)
    {
        endrophin -= amount;
    }

    public int GetEndrophin()
    {
        return endrophin;
    }

    public bool IncreaseExp(int amount)
    {
        currentExp += amount;
        
        if(currentExp >= maxExp)
        {
            currentExp = 0;
            maxExp = (level - 1) * 180 + 350;

            level++;

            return true;
        }

        return false;
    }

    public int GetCurrentExp()
    {
        return currentExp;
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
