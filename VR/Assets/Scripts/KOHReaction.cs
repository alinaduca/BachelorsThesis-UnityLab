using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KOHReaction : MonoBehaviour
{
    [SerializeField] PourMetalSubstance metal;
    [SerializeField] PourSubstance water;
    [SerializeField] PourPhenolphthalein phenolphthalein;
    public ParticleSystem explosion;
    public GameObject explosionGameObject;
    public GameObject natriumMetal;
    public TMP_Text canvasText;
    public GameObject popupWindow;
    public AudioSource audioSource;
    public AudioClip clip;

    public AudioSource audioSource_guidance;
    public AudioClip clip_guidance1;
    public AudioClip clip_guidance2;
    public AudioClip clip_guidance3;

    private DateTime timpInitial;
    private bool explosionActive = false;
    private bool phenolphthaleinAdded = false;
    private bool oneExplosion = false;
    private bool showPopup = true;

    private bool audioSource1Started = false;
    private bool audioSource2Started = false;
    private bool audioSource3Started = false;

    void Start()
    {
        natriumMetal.SetActive(false);
        explosionGameObject.SetActive(false);
        explosion.Stop();
        explosion.Clear();
    }

    void Update()
    {
        if (water.containsWater == true && metal.containsNatrium == false)
        {
            if (canvasText)
            {
                canvasText.text = "Now you can add Potassium. For this, press twice on the lid with the grep button, and when the lid has disappeared you can grab the glass.";
            }
            if (!audioSource1Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance1);
                audioSource1Started = true;
            }
        }
        if (metal.containsNatrium == true)
        {
            natriumMetal.SetActive(true);
        }
        if (oneExplosion == false && metal.containsNatrium == true && water.containsWater == true)
        {
            explosionActive = true;
            showPopup = true;
            if (canvasText)
            {
                canvasText.text = "Chemical reaction equation: 2H2O + 2K = 2KOH + H2.  Now, you can highlight the basicity of the solution by adding methyl orange.";
            }
            if (!audioSource2Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance2);
                audioSource2Started = true;
            }
            oneExplosion = true;
            timpInitial = DateTime.Now;
            explosionGameObject.SetActive(true);
            explosion.Clear();
            explosion.Play();
            audioSource.PlayOneShot(clip);
        }
        if (phenolphthalein.containsPhenolphthalein == true && !phenolphthaleinAdded)
        {
            phenolphthaleinAdded = true;
            showPopup = true;
            if (canvasText)
            {
                canvasText.text = "You added PH indicator successfully! Now you can learn another reaction.";
            }
            if (!audioSource3Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance3);
                audioSource2Started = true;
            }
            timpInitial = DateTime.Now;
            popupWindow.SetActive(true);
        }
        if (explosionActive && (DateTime.Now - timpInitial).TotalSeconds >= 6)
        {
            explosionActive = false;
            explosionGameObject.SetActive(false);
            explosion.Stop();
            explosion.Clear();
            audioSource.Stop();
        }
        if (showPopup == true && (DateTime.Now - timpInitial).TotalSeconds >= 10)
        {
            showPopup = false;
            //popupWindow.SetActive(false);
        }
    }
}
