using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool isMuted = false;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.soundManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timer.isRunning)
        {
            if (GameManager.Instance.timer.currentTime <= 5)
            {
                GetComponent<AudioSource>().pitch = 2f;
            }
            else if (GameManager.Instance.timer.currentTime <= 10)
            {
                GetComponent<AudioSource>().pitch = 1.5f;
            }
            else if(GameManager.Instance.timer.currentTime <= 20)
            {
                GetComponent<AudioSource>().pitch = 1.2f;
            }
        }
        else if (GameManager.Instance.timer.isEnded)
        {
            GetComponent<AudioSource>().pitch = 0.6f;
        }
    }

    public void ResetBGM()
    {
        GetComponent<AudioSource>().pitch = 1f;
    }

    public void MuteHandler(bool mute)
    {
        if (mute)
        {
            isMuted = true;
            AudioListener.volume = 0;
        }
        else
        {
            isMuted = false;
            AudioListener.volume = 1;
        }
    }
}
