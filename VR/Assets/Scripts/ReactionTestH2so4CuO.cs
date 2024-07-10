using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class ReactionTestH2so4CuO : MonoBehaviour
{
    [SerializeField] PourCuO salt;
    [SerializeField] PourH2so4 h2so4;
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public GameObject currentBerzelius;
    public TMP_Text canvasText;
    public Material material1;
    public Material material2;
    public Material material3;
    public GameObject popupWindow;

    private DateTime timpInitial;
    private bool oneReaction = false;
    private bool showPopup = false;
    bool finishedTask = false;

    void Start()
    {

    }

    void Update()
    {
        if (!finishedTask)
        {
            canvasText.text = "Create Copper(II) sulfate.";
        }
        if (oneReaction == false && salt.containsCuO == true && h2so4.containsHCL == true)
        {
            finishedTask = true;
            oneReaction = true;
            showPopup = true;
            countdown.continua = false;
            canvasText.text = "Task finished!";
            //canvasText.text = "H2SO4 + CuO = CuSO4 + H2O";
            //popupWindow.SetActive(true);
            timpInitial = DateTime.Now;
        }
        if (showPopup == true && (DateTime.Now - timpInitial).TotalSeconds >= 10)
        {
            showPopup = false;
            //popupWindow.SetActive(false);
        }
        if (oneReaction && (DateTime.Now - timpInitial).TotalSeconds >= 2)
        {
            currentBerzelius.transform.Find("Substance").gameObject.GetComponent<Renderer>().material = material1;
        }
        if (oneReaction && (DateTime.Now - timpInitial).TotalSeconds >= 4)
        {
            currentBerzelius.transform.Find("Substance").gameObject.GetComponent<Renderer>().material = material2;
        }
        if (oneReaction && (DateTime.Now - timpInitial).TotalSeconds >= 6)
        {
            currentBerzelius.transform.Find("Substance").gameObject.GetComponent<Renderer>().material = material3;
        }
        if (oneReaction && (DateTime.Now - timpInitial).TotalSeconds >= 8)
        {
            if (!randomizer.generateNewReaction)
            {
                randomizer.generateNewReaction = true;
            }
        }
    }
}