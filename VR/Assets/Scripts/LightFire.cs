using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    public GameObject burnerSupport;
    public GameObject fireAnimation;
    public AudioSource audioSource;
    public AudioClip clip;

    private bool isPlaying = false;
    private bool play = false;
    private bool previous = true;

    public bool esteAprins = false;

    void Start()
    {
        fireAnimation.SetActive(false);
        esteAprins = false;
        //fireAnimation.Stop();
        //fireAnimation.Clear();
    }

    void Update()
    {
        if (burnerSupport.transform.hasChanged == false)
        {
            if (previous == true)
            {
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
            esteAprins = true;
            fireAnimation.SetActive(true);
            //fireAnimation.Clear();
            //fireAnimation.Play();
            if (!isPlaying)
            {
                StartCoroutine(PlaySoundRepeatedly());
            }
        }
        else
        {
            esteAprins = false;
            fireAnimation.SetActive(false);
            //fireAnimation.Stop();
            //fireAnimation.Clear();
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