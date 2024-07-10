using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionCaOHTest : MonoBehaviour
{
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public TMP_Text canvasText;
    private bool finishedTask = false;

    [SerializeField] PourCuO salt;
    [SerializeField] PourSubstance h2o;
    public GameObject CaOHPivot;
    public GameObject TurnesolPivot;
    public GameObject wetLitmusPaper;
    public GameObject wetLitmusPaper1;
    public Material blueLitmusMaterial;

    public GameObject currentBerzelius;
    public Material material;
    public ParticleSystem explosion;
    public GameObject explosionGameObject;
    public AudioSource audioSource;
    public AudioClip clip;

    private DateTime timpInitial;
    private bool isPlaying = false;
    private bool explosionActive = false;
    private bool oneExplosion = false;
    private bool showPopup = false;
    private bool done = false;

    void Start()
    {
        explosionGameObject.SetActive(false);
        explosion.Stop();
        explosion.Clear();
    }

    void Update()
    {
        if (!finishedTask)
        {
            canvasText.text = "Create Ca(OH)2 and check the basicity.";
        }
        if (oneExplosion == false && salt.containsCuO == true && h2o.containsWater == true)
        {
            done = true;
            explosionActive = true;
            explosionGameObject.SetActive(true);
            showPopup = true;
            oneExplosion = true;
            timpInitial = DateTime.Now;
            explosion.Clear();
            explosion.Play();
            if (!isPlaying)
            {
                StartCoroutine(PlaySoundRepeatedly());
            }
        }
        if (explosionActive && (DateTime.Now - timpInitial).TotalSeconds >= 6)
        {
            explosionActive = false;
            explosionGameObject.SetActive(false);
            currentBerzelius.transform.Find("Substance").gameObject.GetComponent<Renderer>().material = material;
            explosion.Stop();
            explosion.Clear();
            isPlaying = false;
            audioSource.Stop();
        }
        if (Math.Abs(TurnesolPivot.transform.position.z - CaOHPivot.transform.position.z) < 0.05 &&
            Math.Abs(TurnesolPivot.transform.position.x - CaOHPivot.transform.position.x) < 0.05 &&
            Math.Abs(TurnesolPivot.transform.position.y - CaOHPivot.transform.position.y) < 0.01 &&
            done == true)
        {
            wetLitmusPaper.gameObject.GetComponent<Renderer>().material = blueLitmusMaterial;
            wetLitmusPaper1.gameObject.GetComponent<Renderer>().material = blueLitmusMaterial;

            canvasText.text = "Task finished!";
            countdown.continua = false;
            finishedTask = true;
        }
        if (finishedTask && !randomizer.generateNewReaction && (DateTime.Now - timpInitial).TotalSeconds >= 9)
        {
            randomizer.generateNewReaction = true;
        }
    }

    IEnumerator PlaySoundRepeatedly()
    {
        isPlaying = true;
        while (isPlaying)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
        }
    }
}
