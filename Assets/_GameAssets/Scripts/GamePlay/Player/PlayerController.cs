using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public event Action OnPlayerJumped;

    [Header("Referance")]
    [SerializeField] private Transform _oriantationTransform;

    [Header("PlayerMovmentSettings")]
    [SerializeField] private KeyCode _movementKey;
    [SerializeField] private float _speed;

    [Header("JumpSettings")]
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpCoolDown = 0.5f;
    [SerializeField] private float _airMultiplier;
    [SerializeField] private float _airDrag;
    [SerializeField] private bool _canJump;


    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _GroundDrag;


    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag;

    private StateController _stateController;

    [SerializeField] private bool _isSliding;

    private Rigidbody _rb;

    private Vector3 _moveDirection;


    private float _horizontalInput, _verticalInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _stateController = GetComponent<StateController>();
    }

    private void Start()
    {
        _rb.freezeRotation = true;

    }

    private void Update()
    {
        SetInput();
        SetStates();
        SetPlayerDrag();   
        LimitPlayerSpeed();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(_slideKey))
        {
            _isSliding = true;
        }
        else if (Input.GetKeyDown(_movementKey))
        {
            _isSliding = false;
        }
        else if (Input.GetKey(_jumpKey) && _canJump && isGrounded())
        {
            _canJump = false;
            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpCoolDown);
        }
    }

    private void SetStates()
    {
        var MovementDirection = GetMovmentDriction();
        var _isGrounded = isGrounded();
        var currentstate = _stateController.GetCurrentState();
        var issliding = isSliding();


        var newState = currentstate switch
        { 
            _ when MovementDirection == Vector3.zero && _isGrounded && !issliding => PlayerState.Idle,
            _ when MovementDirection != Vector3.zero && _isGrounded && !issliding => PlayerState.Move,
            _ when MovementDirection != Vector3.zero && _isGrounded && issliding => PlayerState.Slide,
            _ when MovementDirection == Vector3.zero && _isGrounded && issliding => PlayerState.Slideidle,
            _ when !_canJump && !_isGrounded => PlayerState.Jump,
            _ => currentstate
        };

        if (newState != currentstate)
        {
            _stateController.ChangeState(newState);
        }
     

    }




    private void SetPlayerMovement()
    {
        _moveDirection = _oriantationTransform.forward * _verticalInput
            + _oriantationTransform.right * _horizontalInput;


        float ForceMultilier = _stateController.GetCurrentState() switch
        {
            PlayerState.Move => 1f,
            PlayerState.Slide => _slideMultiplier,
            PlayerState.Jump => _airMultiplier,
            _ => 1f

        };
        _rb.AddForce(_moveDirection.normalized * _speed * ForceMultilier, ForceMode.Force);
    }

    private void SetPlayerDrag()
    {

        _rb.linearDamping = _stateController.GetCurrentState() switch
        { 
            PlayerState.Move => _GroundDrag,
            PlayerState.Slide => _slideDrag,
            PlayerState.Jump => _airDrag,
            _ => _rb.linearDamping
        };

        if (_isSliding)
        {
            _rb.linearDamping = _slideDrag;
        }
        else
        {
            _rb.linearDamping = _GroundDrag;

        }
    }



    private void LimitPlayerSpeed()
    {
        Vector3 flatVelocity = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.y);

        if (flatVelocity.magnitude > _speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * _speed;
            _rb.linearVelocity = new Vector3 (limitedVelocity.x, _rb.linearVelocity.y, limitedVelocity.z);
        }
    }
    
    private void SetPlayerJumping()
    {
        OnPlayerJumped?.Invoke();
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


    private Vector3 GetMovmentDriction()
    {
        return _moveDirection.normalized;
    }

    private bool isSliding()
    {
        return _isSliding;
    }


}
