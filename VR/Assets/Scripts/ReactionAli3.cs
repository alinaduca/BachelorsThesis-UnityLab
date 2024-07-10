using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionAli3 : MonoBehaviour
{
    [SerializeField] PourCuO iodine;
    [SerializeField] PourCuO aluminum;
    [SerializeField] PourFromPipette pipette;

    public ParticleSystem explosion1;
    public ParticleSystem explosion2;
    public ParticleSystem explosion3;

    public GameObject explosionGameObject1;
    public GameObject explosionGameObject2;
    public GameObject explosionGameObject3;

    public GameObject firstPowder;
    public GameObject blackPowder;
    public GameObject purplePowder;
    public GameObject whitePowder;

    public TMP_Text canvasText;
    public GameObject popupWindow;
    public AudioSource audioSource;
    public AudioClip clip;

    public AudioSource audioSource_guidance;
    public AudioClip clip_guidance1;
    public AudioClip clip_guidance2;
    public AudioClip clip_guidance3;
    public AudioClip clip_guidance4;

    private DateTime timpInitial;
    private bool explosionActive = false;
    private bool state2 = false;
    private bool soundStarted = false;

    private bool audioSource1Started = false;
    private bool audioSource2Started = false;
    private bool audioSource3Started = false;
    private bool audioSource4Started = false;

    void Start()
    {
        firstPowder.SetActive(false);
        blackPowder.SetActive(false);
        purplePowder.SetActive(false);
        whitePowder.SetActive(false);

        explosionGameObject1.SetActive(false);
        explosionGameObject2.SetActive(false);
        explosionGameObject3.SetActive(false);

        explosion1.Stop();
        explosion2.Stop();
        explosion3.Stop();
        explosion1.Clear();
        explosion2.Clear();
        explosion3.Clear();
    }


    void Update()
    {
        if(aluminum.containsCuO == true && iodine.containsCuO == false)
        {
            if (canvasText)
            {
                canvasText.text = "Now you can add Iodine. For this, grab the Iodine beaker by pressing the grep button.";
            }
            if (!audioSource1Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance1);
                audioSource1Started = true;
            }
            firstPowder.SetActive(true);
        }
        if(aluminum.containsCuO == false && iodine.containsCuO == true)
        {
            if (canvasText)
            {
                canvasText.text = "Now you can add Aluminum. For this, grab the Aluminum beaker by pressing the grep button.";
            }
            if (!audioSource2Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance2);
                audioSource2Started = true;
            }
            firstPowder.SetActive(true);
        }
        if(aluminum.containsCuO == true && iodine.containsCuO == true && pipette.containsWater == false)
        {
            if (canvasText)
            {
                canvasText.text = "Now you can add water. For this, grab the pipette by pressing the grep button, appropriate it to the mouth of the Water beaker and pour a few drops over the mixture of Aluminum and Iodine.";
            }
            if (!audioSource3Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance3);
                audioSource3Started = true;
            }
            blackPowder.SetActive(true);
        }
        if(soundStarted == false && aluminum.containsCuO == true && iodine.containsCuO == true && pipette.containsWater == true)
        {
            if (canvasText)
            {
                canvasText.text = "Chemical reaction equation: 2Al + 3I2 = 2AlI3. Now you can learn another reaction.";
            }
            if (!audioSource4Started)
            {
                audioSource_guidance.Stop();
                audioSource_guidance.PlayOneShot(clip_guidance4);
                audioSource4Started = true;
            }
            purplePowder.SetActive(true);
            soundStarted = true;
            timpInitial = DateTime.Now;
            explosionActive = true;
            explosionGameObject3.SetActive(true);
            explosion3.Clear();
            explosion3.Play();
            audioSource.PlayOneShot(clip);
        }
        if (explosionActive && (DateTime.Now - timpInitial).TotalSeconds >= 1)
        {
            explosionGameObject2.SetActive(true);
            explosion2.Clear();
            explosion2.Play();
            state2 = true;
            explosionActive = false;
        }
        if (state2 && (DateTime.Now - timpInitial).TotalSeconds >= 2)
        {
            explosionGameObject1.SetActive(true);
            explosion1.Clear();
            explosion1.Play();
            whitePowder.SetActive(true);
            state2 = false;
        }
    }
}
