using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberTrap : MonoBehaviour
{
    private bool _isTriggered;
    private CatMovement _catMovement;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.soundManager.PlaySound(audioClip);
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 700f, ForceMode.Impulse);
            other.GetComponent<BoxCollider>().enabled = false;
            _catMovement = other.GetComponent<CatMovement>();
            StartCoroutine(CucumberCoroutine());
        }
    }

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(10.0f);
        if (!_isTriggered)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CucumberCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        _catMovement.GoBackSpawn();
        Destroy(gameObject);
    }
}
