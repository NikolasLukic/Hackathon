using UnityEngine;

public class gameManager : MonoBehaviour
{
    public sceneManager sm;
    public audioManager am; 

    public GameObject pauseMenu;
    public GameObject gameOverMenu; 

    public movementScript player1, player2;

    bool gameOver;

    public AudioClip gameOverSound; 

    void Update()
    {
        if (player1.isDead && player2.isDead && !gameOver)
        {
            gameOverMenu.SetActive(true);
            am.PlaySound(gameOverSound); 
            gameOver = true; 
        }

        if (Input.GetButtonDown("Pause"))
        {
            Pause(); 
            // print 
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true); 
        }else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false); 
        }
    }
}
