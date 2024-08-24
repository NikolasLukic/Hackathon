using UnityEngine;

public class audioManager : MonoBehaviour
{
    public GameObject audioObject; 

    public void PlaySound(AudioClip clip)
    {
        AudioSource a = Instantiate(audioObject).GetComponent<AudioSource>();
        a.clip = clip;
        a.Play(); 
    }
}
