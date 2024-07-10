using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourHCL : MonoBehaviour
{
    public GameObject FirstGlass;
    public GameObject SecondGlass;
    public ParticleSystem waterLeak;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool containsHCL = false;

    private bool play = false;
    private bool isPlaying = false;
    private GameObject StartForSubstanceLeak;
    private GameObject substance;
    private Renderer firstGlassSubstanceRenderer;
    private Renderer secondGlassSubstanceRenderer;
    void Start()
    {
        waterLeak.Stop();
        Quaternion firstGlassRotation = FirstGlass.transform.rotation;
        StartForSubstanceLeak = FirstGlass.transform.Find("Pivot").gameObject;
        substance = SecondGlass.transform.Find("Substance").gameObject;
        substance.SetActive(false);
        firstGlassSubstanceRenderer = FirstGlass.transform.Find("Substance").gameObject.GetComponent<Renderer>();
        secondGlassSubstanceRenderer = substance.GetComponent<Renderer>();
    }

    void Update()
    {
        Quaternion firstGlassRotation = FirstGlass.transform.rotation;
        Vector3 firstGlassPosition = FirstGlass.transform.position;
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
            waterLeak.transform.position = pivotPosition;
            waterLeak.Play();
            secondGlassSubstanceRenderer.material = firstGlassSubstanceRenderer.material;
            substance.SetActive(true);
            play = true;
            containsHCL = true;
            if (!isPlaying)
            {
                StartCoroutine(PlaySoundRepeatedly());
            }
        }
        else
        {
            if (play)
            {
                waterLeak.Stop();
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
