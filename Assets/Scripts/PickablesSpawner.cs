using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablesSpawner : MonoBehaviour
{
    public GameObject[] pickables;
    public GameObject[] spawnPoints;
    public float spawnTime = 10.0f;
    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (counter <= 3)
        {
            yield return new WaitForSeconds(spawnTime);
            foreach (GameObject pickable in pickables)
            {
                Instantiate(pickable, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            }
            counter++;
        }
    }
}
