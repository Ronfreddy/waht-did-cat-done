using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    private Vector3 _movement;
    private float _speed = 5f;
    private Rigidbody _rigidbody;

    public Vector3 _boxSize;
    public float _boxDistance;
    public LayerMask _groundLayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(_movement.x * _speed, _rigidbody.velocity.y, _movement.z * _speed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _movement = new Vector3(input.x, 0, input.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        }
    }

    // WHY THIS WORKS WTF
    private bool IsGrounded()
    {
        if(Physics.BoxCast(transform.position, _boxSize, Vector3.down, transform.rotation, _boxDistance, _groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * _boxDistance, _boxSize);
    }
}
