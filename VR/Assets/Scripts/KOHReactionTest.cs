using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KOHReactionTest : MonoBehaviour
{
    [SerializeField] PourMetalSubstance metal;
    [SerializeField] PourSubstance water;
    [SerializeField] PourPhenolphthalein phenolphthalein;
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public ParticleSystem explosion;
    public GameObject explosionGameObject;
    public GameObject natriumMetal;
    public TMP_Text canvasText;
    public GameObject popupWindow;
    public AudioSource audioSource;
    public AudioClip clip;

    private DateTime timpInitial;
    private bool explosionActive = false;
    private bool oneExplosion = false;
    private bool showPopup = false;
    private bool finishedTask = false;

    void Start()
    {
        natriumMetal.SetActive(false);
        explosionGameObject.SetActive(false);
        explosion.Stop();
        explosion.Clear();
    }

    void Update()
    {
        if (!finishedTask)
        {
            canvasText.text = "Create KOH and check the acidity.";
        }
        if (!oneExplosion)
        {
            explosion.Stop();
            explosion.Clear();
            explosion.Stop();
            explosion.Clear();
        }
        if (metal.containsNatrium == true)
        {
            natriumMetal.SetActive(true);
        }
        if (oneExplosion == false && metal.containsNatrium == true && water.containsWater == true)
        {
            explosionActive = true;
            //explosionGameObject.SetActive(true);
            //showPopup = true;
            //popupWindow.SetActive(true);
            oneExplosion = true;
            timpInitial = DateTime.Now;
            explosionGameObject.SetActive(true);
            explosion.Clear();
            explosion.Play();
            audioSource.PlayOneShot(clip);
        }
        if (!finishedTask && metal.containsNatrium && water.containsWater && phenolphthalein.containsPhenolphthalein)
        {
            finishedTask = true;
            //showPopup = true;
            canvasText.text = "Task finished!";
            countdown.continua = false;
            timpInitial = DateTime.Now;
            //popupWindow.SetActive(true);
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
            popupWindow.SetActive(false);
        }
        if (finishedTask && !randomizer.generateNewReaction && (DateTime.Now - timpInitial).TotalSeconds >= 10)
        {
            randomizer.generateNewReaction = true;
        }
    }
}


