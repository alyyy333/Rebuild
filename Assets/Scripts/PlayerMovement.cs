using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;

    [SerializeField] float groundDrag;

    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;

    float horizontalInput;
    float verticalInput;
    bool readyToJump = true;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool grounded;

    [SerializeField] Transform Orientation;


    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 1f, whatIsGround);
        Debug.Log(grounded);
        MyInput();
        SpeedControl();

        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0f;
        }

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            Debug.Log("jumping");
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
    }


}
