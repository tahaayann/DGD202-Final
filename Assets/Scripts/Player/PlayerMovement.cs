using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    
    public Rigidbody rb;
    [SerializeField] private Animator _animator;
    public float Speed;
    public float RotationSpeed;
    public float jumpForce;
    public float extraGravity;

    private bool isJumping = false;
    private bool isGrounded = true; // Add a flag to check if the character is grounded

    [SerializeField] private Vector2 _inputVector;
    [SerializeField] private Vector3 _movementVector;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
    }

    private void Update()
    {
        GetInput();
        RotateCharacter();
        AnimateCharacter();
        MoveCharacter();
    }

    private void FixedUpdate()
    {
        // Using FixedUpdate for physics-related operations
        if (isJumping && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
            isGrounded = false; // Set grounded to false when jumping
        }
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the character is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("jumping",false);
        }
    }

    #endregion

    #region METHODS

    private void GetInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool jumpInput = Input.GetButtonDown("Jump");

        _inputVector = new Vector2(horizontalInput, verticalInput);

        if (jumpInput && isGrounded)
        {
            isJumping = true;
            _animator.SetBool("jumping", true);
        }
    }

    private void AnimateCharacter()
    {
        if (_inputVector.y > 0)
        {
            _animator.SetBool("running", true);
            _animator.SetFloat("runDirection", 1f);
        }
        else if (_inputVector.y < 0)
        {
            _animator.SetBool("running", true);
            _animator.SetFloat("runDirection", -1f);
        }
        else
        {
            _animator.SetBool("running", false);
        }
    }

    private void RotateCharacter()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0f, _inputVector.x * RotationSpeed * Time.deltaTime, 0f));
    }

    private void MoveCharacter()
    {
        transform.position += transform.forward * _inputVector.y * Speed * Time.deltaTime;
    }
    

    #endregion
}
