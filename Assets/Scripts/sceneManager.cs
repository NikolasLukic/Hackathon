using UnityEngine;
using UnityEngine.SceneManagement; 

public class sceneManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }
}
