using UnityEngine;

public class gameManager : MonoBehaviour
{
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0; 
        }else
        {
            Time.timeScale = 1; 
        }
    }
}
