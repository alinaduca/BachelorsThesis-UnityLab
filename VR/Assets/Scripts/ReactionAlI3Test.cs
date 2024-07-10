using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionAlI3Test : MonoBehaviour
{
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public TMP_Text canvasText;
    private bool finishedTask = false;

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
    public AudioSource audioSource;
    public AudioClip clip;

    private DateTime timpInitial;
    private bool explosionActive = false;
    private bool state2 = false;
    private bool soundStarted = false;

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
        if (!finishedTask)
        {
            canvasText.text = "Create aluminum iodide.";
        }
        if (aluminum.containsCuO == true && iodine.containsCuO == false)
        {
            firstPowder.SetActive(true);
        }
        if (aluminum.containsCuO == false && iodine.containsCuO == true)
        {
            firstPowder.SetActive(true);
        }
        if (aluminum.containsCuO == true && iodine.containsCuO == true && pipette.containsWater == false)
        {
            blackPowder.SetActive(true);
        }
        if (soundStarted == false && aluminum.containsCuO == true && iodine.containsCuO == true && pipette.containsWater == true)
        {
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
        if (!finishedTask && state2 && (DateTime.Now - timpInitial).TotalSeconds >= 2)
        {
            explosionGameObject1.SetActive(true);
            explosion1.Clear();
            explosion1.Play();
            whitePowder.SetActive(true);
            state2 = false;
            canvasText.text = "Task finished!";
            countdown.continua = false;
            finishedTask = true;
        }
        if (finishedTask && !randomizer.generateNewReaction && (DateTime.Now - timpInitial).TotalSeconds >= 8)
        {
            randomizer.generateNewReaction = true;
        }
    }
}
