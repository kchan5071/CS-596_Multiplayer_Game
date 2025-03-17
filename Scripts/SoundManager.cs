using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //get children of game object
    private AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip.name == soundName)
            {
                //if the sound is already playing, return
                if (audioSource.isPlaying) return;
                audioSource.Play();
                return;
            }
        }
        Debug.LogWarning("Sound not found: " + soundName);
    }

    public void StopSound(string soundName)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip.name == soundName)
            {
                audioSource.Stop();
                return;
            }
        }
        Debug.LogWarning("Sound not found: " + soundName);
    }
}
