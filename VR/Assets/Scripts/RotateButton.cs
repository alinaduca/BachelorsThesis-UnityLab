using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    public GameObject rotatingButton;
    public ParticleSystem waterLeak;
    public AudioSource audioSource;
    public AudioClip clip;


    private bool isPlaying = false;
    private bool play = false;
    private bool previous = true;

    void Start()
    {
        waterLeak.Stop();
    }

    void Update()
    {
        if (rotatingButton.transform.hasChanged == false) {
            if (previous == true) {
                play = !play;
                previous = false;
            }
        }
        else
        {
            previous = true;
        }
        if (play)
        {
            waterLeak.Play();
            if (!isPlaying)
            {
                StartCoroutine(PlaySoundRepeatedly());
            }
        }
        else
        {
            waterLeak.Stop();
            isPlaying = false;
            audioSource.Stop();
        }
    }

    IEnumerator PlaySoundRepeatedly()
    {
        isPlaying = true;
        while (isPlaying)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
        }
    }
}
