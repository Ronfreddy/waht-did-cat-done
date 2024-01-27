using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            source.PlayOneShot(clip);
        }
    }
}
