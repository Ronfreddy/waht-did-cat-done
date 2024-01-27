using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CatMovement>().SlowDown();
            Destroy(gameObject);
        }
    }
}
