using System.Collections;
using UnityEngine;

public class MakeRandomSound : MonoBehaviour
{
    private AudioSource audioSource;

    private float sound_probability = 0.2f;
    private float sound_delay = 1f;
    private float sound_cooldown = 2f;
    private float curruent_countdown = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Random.value < sound_probability)
            audioSource.Play();
    }

    void Update()
    {
        if (curruent_countdown <= 0f)
        {
            StartCoroutine(PlaySoundWithDelay(sound_delay));
            curruent_countdown = sound_cooldown;
        }
        else
        {
            curruent_countdown -= Time.deltaTime;
        }
    }
}
