using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Referance")]
    [SerializeField] private Transform _oriantationTransform;

    [Header("PlayerMovmentSettings")]
    [SerializeField] private KeyCode _movementKey;
    [SerializeField] private float _speed = 10f;

    [Header("JumpSettings")]
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpCoolDown = 0.5f;
    [SerializeField] private bool _canJump;


    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private float _slideMultiplier;

    [SerializeField] private bool _isSliding;

    private Rigidbody _rb;

    private Vector3 _moveDirection;


    private float _horizontalInput, _verticalInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        SetInput();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInput ()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(_slideKey)) 
        {
            _isSliding = true;
        }
        else if (Input.GetKeyDown(_movementKey))
        {

        }
        else if (Input.GetKey(_jumpKey) && _canJump && isGrounded())
        {
            _canJump = false;
            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpCoolDown);
        }
    }


    private void SetPlayerMovement() 
    {
        _moveDirection = _oriantationTransform.forward * _verticalInput 
            + _oriantationTransform.right * _horizontalInput;
        if (_isSliding)
        {
            _rb.AddForce(_moveDirection.normalized * _speed * _slideMultiplier, ForceMode.Force);
        }
        else 
        {
            _rb.AddForce(_moveDirection.normalized * _speed, ForceMode.Force);
        }

    }

    private void SetPlayerJumping()
    {
        
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ResetJumping()
    {
        _canJump = true;
    }

    private bool isGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer); 
    }
}
