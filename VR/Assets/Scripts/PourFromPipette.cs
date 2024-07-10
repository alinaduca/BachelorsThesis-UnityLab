using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourFromPipette : MonoBehaviour
{
    public GameObject pipette;
    public GameObject crystallizing_dish;
    public ParticleSystem substanceLeak;
    public GameObject substanceLeakObject;
    private bool play = false;
    private GameObject pivot;
    public bool containsWater = false;

    public GameObject waterInPipette;
    [SerializeField] FillPipette filledPipette;
    private DateTime timpInitial;

    void Start()
    {
        substanceLeakObject.SetActive(false);
        substanceLeak.Stop();
        substanceLeak.Clear();
        Quaternion firstGlassRotation = pipette.transform.rotation;
        pivot = pipette.transform.Find("pivott").gameObject;
    }
    
    void Update()
    {
        Quaternion firstGlassRotation = pipette.transform.rotation;
        Vector3 firstGlassPosition = pipette.transform.position;
        Vector3 secondGlassPosition = crystallizing_dish.transform.position;
        Vector3 pivotPosition = pivot.transform.position;

        if (filledPipette.pipetteIsFull == true && (firstGlassPosition.y > secondGlassPosition.y &&
                Math.Abs(firstGlassPosition.x - secondGlassPosition.x) < 0.1 &&
                Math.Abs(firstGlassPosition.z - secondGlassPosition.z) < 0.1)
            )
        {
            substanceLeak.transform.position = pivotPosition;
            if (!play)
            {
                substanceLeakObject.SetActive(true);
                substanceLeak.Clear();
                substanceLeak.Play();
                containsWater = true;
                play = true;
                timpInitial = DateTime.Now;
            }
        }
        else
        {
            if (play)
            {
                substanceLeak.Stop();
                substanceLeak.Clear();
                play = false;
                substanceLeakObject.SetActive(false);
            }
        }
        if(filledPipette.pipetteIsFull == true && play && (DateTime.Now - timpInitial).TotalSeconds >= 3)
        {
            waterInPipette.SetActive(false);
            filledPipette.pipetteIsFull = false;
            substanceLeak.Stop();
            substanceLeak.Clear();
            play = false;
            substanceLeakObject.SetActive(false);
        }
    }
}
