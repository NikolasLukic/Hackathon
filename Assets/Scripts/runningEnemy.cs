using UnityEngine;

public class runningEnemy : MonoBehaviour
{
    public Transform leftLimit, rightLimit, enemy;
    public Rigidbody2D rb;
    public float speed;
    public bool moveRight;
    public SpriteRenderer sr; 

    void Start()
    {
        sr.flipX = !moveRight;
    }

    void Update()
    {
        if (moveRight)
        {
            if (enemy.localPosition.x > rightLimit.localPosition.x)
            {
                sr.flipX = true; 
                moveRight = false; 
            }else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y); 
            }
        }else
        {
            if (enemy.localPosition.x < leftLimit.localPosition.x)
            {
                sr.flipX = false; 
                moveRight = true;
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }
}