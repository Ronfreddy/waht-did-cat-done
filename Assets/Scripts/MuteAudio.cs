using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{

    public void MuteHandler(bool mute)
    {
        if(mute)
        {
            GameManager.Instance.soundManager.isMuted = true;
            AudioListener.volume = 0;
        }
        else
        {
            GameManager.Instance.soundManager.isMuted = false;
            AudioListener.volume = 1;
        }
    }
}
