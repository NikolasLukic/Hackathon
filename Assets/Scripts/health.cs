using UnityEngine;

public class health : MonoBehaviour
{
    movementScript movement; 
    Animator anim;
    Rigidbody2D rb; 

    void Start()
    {
        movement = GetComponent<movementScript>(); 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            anim.SetBool("dead", true);
            anim.SetBool("grounded", true); 
            movement.isDead = true;
            rb.velocity = Vector2.zero; 
        }
    }
}