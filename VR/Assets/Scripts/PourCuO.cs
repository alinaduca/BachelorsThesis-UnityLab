using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourCuO : MonoBehaviour
{
    public GameObject Container;
    public GameObject SecondGlass;
    public ParticleSystem substanceLeak;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool containsCuO = false;

    private bool play = false;
    private bool isPlaying = false;
    private GameObject StartForSubstanceLeak;

    void Start()
    {
        Quaternion firstGlassRotation = Container.transform.rotation;
        StartForSubstanceLeak = Container.transform.Find("pivott").gameObject;
        Debug.Log(StartForSubstanceLeak);
    }

    void Update()
    {
        Quaternion firstGlassRotation = Container.transform.rotation;
        Vector3 firstGlassPosition = Container.transform.position;
        Vector3 secondGlassPosition = SecondGlass.transform.position;
        Vector3 pivotPosition = StartForSubstanceLeak.transform.position;
        if ((
            firstGlassRotation.eulerAngles.x >= 45.0f && firstGlassRotation.eulerAngles.x < 90.0f ||
            firstGlassRotation.eulerAngles.x <= 315.0f && firstGlassRotation.eulerAngles.x >= 270.0f ||
            firstGlassRotation.eulerAngles.y >= 45.0f && firstGlassRotation.eulerAngles.y < 90.0f ||
            firstGlassRotation.eulerAngles.y <= 315.0f && firstGlassRotation.eulerAngles.y >= 270.0f)
            && (
                firstGlassPosition.y > secondGlassPosition.y &&
                pivotPosition.x <= secondGlassPosition.x + 0.15 && pivotPosition.x >= secondGlassPosition.x - 0.15 &&
                pivotPosition.z <= secondGlassPosition.z + 0.15 && pivotPosition.z >= secondGlassPosition.z - 0.15
                )
            )
        {
            substanceLeak.transform.position = pivotPosition;
            if (!play)
            {
                substanceLeak.Clear(); // Clear existing particles before replaying
                substanceLeak.Play();
                containsCuO = true;
                play = true;
                if (!isPlaying)
                {
                    StartCoroutine(PlaySoundRepeatedly());
                }
            }
        }
        else
        {
            if (play)
            {
                substanceLeak.Stop();
                substanceLeak.Clear(); // Clear existing particles when stopping
                play = false;
                isPlaying = false;
                audioSource.Stop();
            }
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