using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private Animator _animator;
    private Vector3 _movement;

    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [Header("Ground Check")]
    private Vector3 _boxSize;
    [SerializeField] private float _boxDistance;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _walkParticles;
    [SerializeField] private ParticleSystem _jumpParticles;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _boxSize = new Vector3(_boxCollider.size.x * transform.localScale.x, 0.1f, _boxCollider.size.z * transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(_movement.x * _speed, _rigidbody.velocity.y, _movement.z * _speed);

        if (_movement != Vector3.zero)
        {
            _animator.SetBool("isWalking", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_movement), 0.15f);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _movement = new Vector3(input.x, 0, input.y);

        if (context.performed)
        {
            _walkParticles.Play();
        }
        else if (context.canceled)
        {
            _walkParticles.Stop();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
            _jumpParticles.Play();
        }
    }

    private bool IsGrounded()
    {
        if(Physics.BoxCast(_boxCollider.bounds.center, _boxSize, Vector3.down, transform.rotation, _boxDistance, _groundLayer))
        {
            return true;
        }
        else
        {
            Debug.Log("Not Grounded");
            return false;
        }
    }
}
