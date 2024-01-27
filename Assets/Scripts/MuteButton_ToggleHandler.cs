using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton_ToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.soundManager.isMuted)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
