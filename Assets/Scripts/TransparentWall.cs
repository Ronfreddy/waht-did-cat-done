using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    private bool _playerBlocked = false;
    private float _alpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerBlocked)
        {
            _alpha = Mathf.Lerp(_alpha, 0.4f, 0.1f);
        }
        else
        {
            _alpha = Mathf.Lerp(_alpha, 1f, 0.1f);
        }

        Color color = GetComponent<MeshRenderer>().material.color;
        color.a = _alpha;
        Debug.Log(color);
        GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            _playerBlocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerBlocked = false;
        }
    }
}
