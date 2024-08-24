using UnityEngine;

public class health : MonoBehaviour
{
    audioManager am; 

    movementScript movement; 
    Animator anim;
    Rigidbody2D rb;

    public AudioClip deathSound; 

    void Start()
    {
        movement = GetComponent<movementScript>(); 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        am = FindObjectOfType<audioManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Kill(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            Kill(); 
        }
    }

    void Kill()
    {
        anim.SetBool("dead", true);
        anim.SetBool("grounded", true);
        movement.isDead = true;
        rb.velocity = Vector2.zero;
        am.PlaySound(deathSound, 0.1f);
    }
}