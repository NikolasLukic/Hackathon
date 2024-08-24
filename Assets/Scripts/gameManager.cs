using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject pauseMenu; 

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause(); 
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
