using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float breakForce;
    public GameObject player;
    private bool inRange = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if mouse click & in attack range
        if (Input.GetMouseButtonDown(0) && inRange) 
        {
            ObjectDestroy();
        }
 
    }

    void ObjectDestroy()
    {
        
        
        Vector3 force = (rb.transform.position - player.transform.position).normalized * breakForce / 5f;
        rb.AddForce(force,ForceMode.Impulse);
        GameManager.Instance.scoreSystem.AddScore(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
