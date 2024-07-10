using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourMetalSubstance : MonoBehaviour
{
    public GameObject Container;
    public GameObject SecondGlass;
    public ParticleSystem substanceLeak;
    private bool play = false;
    private GameObject StartForSubstanceLeak;
    public bool containsNatrium = false;

    void Start()
    {
        //substanceLeak.Stop();
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
                containsNatrium = true;
                play = true;
            }
        }
        else
        {
            if (play)
            {
                substanceLeak.Stop();
                substanceLeak.Clear(); // Clear existing particles when stopping
                play = false;
            }
        }
    }
}