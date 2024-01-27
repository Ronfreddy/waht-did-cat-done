using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberTrap : MonoBehaviour
{
    private CatMovement _catMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 700f, ForceMode.Impulse);
            other.GetComponent<BoxCollider>().enabled = false;
            _catMovement = other.GetComponent<CatMovement>();
            StartCoroutine(CucumberCoroutine());
        }
    }

    private IEnumerator CucumberCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        _catMovement.GoBackSpawn();
        Destroy(gameObject);
    }
}
