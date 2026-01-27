using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SCR_PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Controlls")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode maskKey = KeyCode.F;
    public KeyCode interactKey = KeyCode.E;

    [Header("Other")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    [Header("Light")]
    public bool day;
    public Light skyLight;
    public Color dayColour;
    public Color nightColour;

    [Header("Object Arrays")]
    public GameObject[] dayOnly;
    public GameObject[] nightOnly;

    float hInput;
    float vInput;

    Vector3 moveDir;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        dayOnly = GameObject.FindGameObjectsWithTag("DayOnly");
        nightOnly = GameObject.FindGameObjectsWithTag("NightOnly");
        ResetJump();
        MaskSwap();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        KeyboardInput();
        SpeedControl();

        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }

        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void KeyboardInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKeyDown(maskKey))
        {
            MaskSwap();
        }
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vInput + orientation.right * hInput;

        if (grounded) { rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force); }
        else { rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force); }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
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

    private void MaskSwap()
    {
        if (day)
        {
            day = false;
            skyLight.color = nightColour;
            
            foreach (var item in nightOnly)
            {
                item.SetActive(true);
            }
            foreach (var item in dayOnly)
            {
                item.SetActive(false);
            }
        }

        else
        {
            day = true;
            skyLight.color = dayColour;
            foreach (var item in nightOnly)
            {
                item.SetActive(false);
            }
            foreach (var item in dayOnly)
            {
                item.SetActive(true);
            }
        }
    }
}
