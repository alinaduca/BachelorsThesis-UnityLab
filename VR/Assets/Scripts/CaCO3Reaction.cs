using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaCO3Reaction : MonoBehaviour
{
    public GameObject pivotEprubeta;
    public GameObject pivotFoc;
    [SerializeField] LightFire foc;
    [SerializeField] MeshRendererScript balloon;
    public GameObject fume;
    public GameObject balon;

    public GameObject label;
    public Material CaO_material;

    public TMP_Text canvasText;
    public GameObject popupWindow;

    public AudioSource audioSource_guidance;
    public AudioClip clip_guidance1;
    public AudioClip clip_guidance2;
    public AudioClip clip_guidance3;

    private float targetPoint;
    private Vector3 initialScale;
    private Vector3 finalScale;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private bool reactionCompleted = false;

    private bool audioSource1Started = false;
    private bool audioSource2Started = false;
    private bool audioSource3Started = false;
    private bool balon_ok = false;

    void Start()
    {
        fume.SetActive(false);
        initialScale = balon.transform.localScale;
        finalScale = initialScale * 17 / 10;
        initialPosition = balon.transform.localPosition;
        finalPosition = new Vector3(initialPosition.x, initialPosition.y - 0.35f, initialPosition.z);
    }

    void Update()
    {
        if(balloon.balonPesteEprubeta == true)
        {
            if(audioSource1Started == false)
            {
                canvasText.text = "You have successfully attached the balloon! Now you can light the Bunsen burner by pressing the white button on the burner with the grep button.";
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance1);
                audioSource1Started = true;
                balon_ok = true;
            }
        }
        if(balon_ok == true && foc.esteAprins == true)
        {
            if(audioSource2Started == false)
            {
                canvasText.text = "You have lit the Bunsen burner successfully! Now you can hold the CaCO3 test tube over the flame and observe the balloon inflating.";
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance2);
                audioSource2Started = true;
            }
        }
        if (!reactionCompleted && 
            Math.Abs(pivotFoc.transform.position.z - pivotEprubeta.transform.position.z) < 0.05 &&
            Math.Abs(pivotFoc.transform.position.x - pivotEprubeta.transform.position.x) < 0.05 &&
            Math.Abs(pivotFoc.transform.position.y - pivotEprubeta.transform.position.y) < 0.1 && foc.esteAprins == true
            )
        {
            fume.SetActive(true);
            if (balon_ok)
            {
                targetPoint += Time.deltaTime / 10;
                balon.transform.localScale = Vector3.Lerp(initialScale, finalScale, targetPoint);
                balon.transform.localPosition = Vector3.Lerp(initialPosition, finalPosition, targetPoint);
                if (targetPoint >= 1f)
                {
                    targetPoint = 1f;
                    reactionCompleted = true;
                    if (targetPoint >= 1f)
                    {
                        targetPoint = 1f;
                        label.GetComponent<Renderer>().material = CaO_material;
                        if (!audioSource3Started)
                        {
                            canvasText.text = "Chemical reaction equation: CaCO3 = CaO + CO2. Now you can put the test tube with CaO on the support, close the burner and learn another reaction.";
                            audioSource_guidance.Stop();
                            audioSource_guidance.PlayOneShot(clip_guidance3);
                            audioSource3Started = true;
                        }
                        fume.SetActive(false);
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
