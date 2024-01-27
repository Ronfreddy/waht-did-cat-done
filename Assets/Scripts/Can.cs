using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public AudioClip audioClip;

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.soundManager.PlaySound(audioClip);
            other.GetComponent<CatMovement>().PowerUp();
            Destroy(gameObject);
        }
    }
}
