using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movementScript : MonoBehaviour
{
    audioManager am; 

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    public SpriteRenderer sprite;

    Animator animator;

    public bool isPlayer1 = true;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isFinish;

    public AudioClip jumpSound; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        am = FindObjectOfType<audioManager>(); 
    }

    // Triggers every frame
    void Update()
    {
        if (!isDead && !isFinish)
        {
            MoveControls(); 
        }
    }

    // Player movement and controls
    void MoveControls()
    {
        // Get input from A/D or left/right arrow keys
        float moveX = 0;
        if (isPlayer1)
        {
            moveX = Input.GetAxis("Horizontal1");
        }
        else
        {
            moveX = Input.GetAxis("Horizontal2");
        }

        // Flip player based on movement direction
        if (moveX > 0)
        {
            sprite.flipX = false;
            animator.SetBool("moving", true);
        }
        else if (moveX < 0)
        {
            sprite.flipX = true;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        // Apply movement velocity
        Vector2 velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("grounded", isGrounded);

        // Check for jump input
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump1") && isPlayer1 || Input.GetButtonDown("Jump2") && !isPlayer1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                am.PlaySound(jumpSound); 
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the ground check circle in the scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
