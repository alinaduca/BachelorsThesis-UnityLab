using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class ReactionTest : MonoBehaviour
{
    [SerializeField] PourMetalSubstance metal;
    [SerializeField] PourSubstance water;
    [SerializeField] PourPhenolphthalein phenolphthalein;
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public ParticleSystem explosion;
    public GameObject natriumMetal;
    public TMP_Text canvasText;
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
        explosion.Stop();
        explosion.Clear();
    }

    void Update()
    {
        if (!finishedTask)
        {
            canvasText.text = "Create NaOH and check the acidity.";
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
            oneExplosion = true;
            timpInitial = DateTime.Now;
            explosion.Clear();
            explosion.Play();
            audioSource.PlayOneShot(clip);
        }
        if (!finishedTask && metal.containsNatrium && water.containsWater && phenolphthalein.containsPhenolphthalein)
        {
            finishedTask = true;
            canvasText.text = "Task finished!";
            countdown.continua = false;
            timpInitial = DateTime.Now;
        }
        if (explosionActive && (DateTime.Now - timpInitial).TotalSeconds >= 6)
        {
            explosionActive = false;
            explosion.Stop();
            explosion.Clear();
            audioSource.Stop();
        }
        if (showPopup == true && (DateTime.Now - timpInitial).TotalSeconds >= 8)
        {
            showPopup = false;
        }
        if (finishedTask && !randomizer.generateNewReaction && (DateTime.Now - timpInitial).TotalSeconds >= 8)
        {
            randomizer.generateNewReaction = true;
        }
    }
}
