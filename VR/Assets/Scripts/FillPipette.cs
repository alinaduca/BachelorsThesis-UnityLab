using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPipette : MonoBehaviour
{
    public GameObject pipette;
    public GameObject liquidInPipette;
    public GameObject glassWithWater;
    public GameObject pivotErlenmeyer;
    public GameObject pivotPipette;

    public bool pipetteIsFull = false;

    void Start()
    {
        liquidInPipette.SetActive(false);
        pivotPipette = pipette.transform.Find("pivott").gameObject;
        pivotErlenmeyer = glassWithWater.transform.Find("Pivot").gameObject;
    }

    void Update()
    {
        if (Math.Abs(pivotPipette.transform.position.x - pivotErlenmeyer.transform.position.x) < 0.05 &&
            Math.Abs(pivotPipette.transform.position.y - pivotErlenmeyer.transform.position.y) < 0.05 &&
            Math.Abs(pivotPipette.transform.position.z - pivotErlenmeyer.transform.position.z) < 0.05)
        {
            liquidInPipette.SetActive(true);
            pipetteIsFull = true;
        }
    }
}
