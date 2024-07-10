using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class ReactionTestHClNaOH : MonoBehaviour
{
    [SerializeField] PourNahco3 salt;
    [SerializeField] PourHCL hcl;
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public GameObject currentBerzelius;
    public Material material;
    public ParticleSystem explosion;
    public GameObject explosionGameObject;
    public TMP_Text canvasText;
    public GameObject popupWindow;
    public AudioSource audioSource;
    public AudioClip clip;

    private DateTime timpInitial;
    private bool isPlaying = false;
    private bool explosionActive = false;
    private bool oneExplosion = false;
    private bool showPopup = false;
    bool finishedTask = false;

    void Start()
    {
        explosionGameObject.SetActive(false);
        explosion.Stop();
        explosion.Clear();
        //canvasText.text = "Create table salt.";
    }

    void Update()
    {
        if (!finishedTask)
        {
            //    showPopup = true;
            canvasText.text = "Create table salt.";
            //    popupWindow.SetActive(true);
        }
        if (oneExplosion == false && salt.containsNahco3 == true && hcl.containsHCL == true)
        {
            finishedTask = true;
            explosionActive = true;
            explosionGameObject.SetActive(true);
            oneExplosion = true;
            countdown.continua = false;
            timpInitial = DateTime.Now;
            showPopup = true;
            canvasText.text = "Task finished!";
            //popupWindow.SetActive(true);
            explosion.Clear();
            explosion.Play();
            if (!isPlaying)
            {
                StartCoroutine(PlaySoundRepeatedly());
            }
        }
        if (explosionActive && (DateTime.Now - timpInitial).TotalSeconds >= 4)
        {
            explosionActive = false;
            explosionGameObject.SetActive(false);
            currentBerzelius.transform.Find("Substance").gameObject.GetComponent<Renderer>().material = material;
            explosion.Stop();
            explosion.Clear();
            isPlaying = false;
            audioSource.Stop();
            timpInitial = DateTime.Now;
            //popupWindow.SetActive(true);
        }
        if (showPopup == true && (DateTime.Now - timpInitial).TotalSeconds >= 5)
        {
            showPopup = false;
            if (!randomizer.generateNewReaction)
            {
                randomizer.generateNewReaction = true;
            }
            //popupWindow.SetActive(false);
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