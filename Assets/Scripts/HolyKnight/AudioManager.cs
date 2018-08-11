using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource[] effectSource;

    private void Awake()
    {
        if (AudioManager.Instance == null)
            AudioManager.Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void PlayBgm()
    {
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlayEffect(int index)
    {
        effectSource[index].Play();

        /*
            0: Shot
            1: Item Buff
            2: Item Debuff
            3: Game Over
        */
    }
}
