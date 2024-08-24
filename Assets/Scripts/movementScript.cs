using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    public SpriteRenderer sprite;

    public Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        // Get input from A/D or left/right arrow keys
        float moveX = Input.GetAxis("Horizontal");

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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
