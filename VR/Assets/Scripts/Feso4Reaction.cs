using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Feso4Reaction : MonoBehaviour
{
    public Material substantaEprubetaMaterial;
    public GameObject pivotEprubeta;
    public GameObject pivotFoc;
    [SerializeField] LightFire foc;
    public GameObject fume;

    public GameObject label;
    public Material Fe2O3_material;

    public TMP_Text canvasText;
    public GameObject popupWindow;

    public AudioSource audioSource_guidance;
    public AudioClip clip_guidance1;
    public AudioClip clip_guidance2;

    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;

    private bool audioSource1Started = false;
    private bool audioSource2Started = false;

    void Start()
    {
        substantaEprubetaMaterial.color = colors[0];
        time = 0;
        fume.SetActive(false);
    }

    void Update()
    {
        if(foc.esteAprins == true && !audioSource1Started)
        {
            canvasText.text = "You have lit the Bunsen burner successfully! Now you can hold the FeSO4 test tube over the flame and observe the color change.";
            audioSource_guidance.Stop();
            audioSource_guidance.PlayOneShot(clip_guidance1);
            audioSource1Started = true;
        }
        if (Math.Abs(pivotFoc.transform.position.z - pivotEprubeta.transform.position.z) < 0.05 &&
            Math.Abs(pivotFoc.transform.position.x - pivotEprubeta.transform.position.x) < 0.05 &&
            Math.Abs(pivotFoc.transform.position.y - pivotEprubeta.transform.position.y) < 0.1 && foc.esteAprins == true
            )
        {
            fume.SetActive(true);
            targetPoint += Time.deltaTime / 10;
            substantaEprubetaMaterial.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
            if (targetPoint >= 1f)
            {
                targetPoint = 0f;
                currentColorIndex = targetColorIndex;
                if (targetColorIndex < colors.Length - 1)
                {
                    targetColorIndex++;
                }
                else
                {
                    label.GetComponent<Renderer>().material = Fe2O3_material;
                    fume.SetActive(false);
                    canvasText.text = "Chemical reaction equation: 2FeSO4 = Fe2O3 + SO2 + SO3. Now you can put the test tube with Fe2O3 on the support, close the burner and learn another reaction.";
                    if(!audioSource2Started)
                    {
                        audioSource_guidance.Stop();
                        audioSource_guidance.PlayOneShot(clip_guidance2);
                        audioSource2Started = true;
                    }
                }
            }
        }
        else
        {
            fume.SetActive(false);
        }
    }
}
