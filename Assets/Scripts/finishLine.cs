using UnityEngine;

public class finishLine : MonoBehaviour
{
    public sceneManager sm;
    int playersPassed = 0;

    public string nextLevel; 

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject.GetComponent<movementScript>().isFinish == false)
        {
            col.gameObject.GetComponent<movementScript>().isFinish = true;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playersPassed++; 
        }
    }

    void Update()
    {
        if (playersPassed == 2)
        {
            sm.ChangeScene(nextLevel); 
        }
    }
}
