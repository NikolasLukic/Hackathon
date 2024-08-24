using UnityEngine;

public class audioManager : MonoBehaviour
{
    public GameObject audioObject; 

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        AudioSource a = Instantiate(audioObject).GetComponent<AudioSource>();
        a.clip = clip;
        a.volume = volume; 
        a.Play(); 
    }
}
