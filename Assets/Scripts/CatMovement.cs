using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = _playerInput.actions["Move"].ReadValue<Vector2>().x * _speed;
        var y = _playerInput.actions["Move"].ReadValue<Vector2>().y * _speed;

        transform.position += new Vector3(x, 0, y) * Time.deltaTime;
    }

    
}
