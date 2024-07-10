using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeSO4ReactionTest : MonoBehaviour
{
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public TMP_Text canvasText;
    private bool finishedTask = false;
    private DateTime timpInitial;

    public Material substantaEprubetaMaterial;
    public GameObject pivotEprubeta;
    public GameObject pivotFoc;
    [SerializeField] LightFire foc;
    public GameObject fume;

    public GameObject label;
    public Material Fe2O3_material;

    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;

    void Start()
    {
        substantaEprubetaMaterial.color = colors[0];
        time = 0;
        fume.SetActive(false);
    }

    void Update()
    {
        if (!finishedTask)
        {
            canvasText.text = "Decompose FeSO4 and observe the color change.";
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
                    timpInitial = DateTime.Now;
                    fume.SetActive(false);
                    canvasText.text = "Task finished!";
                    countdown.continua = false;
                    finishedTask = true;
                }
            }
        }
        else
        {
            fume.SetActive(false);
        }
        if (finishedTask && !randomizer.generateNewReaction && (DateTime.Now - timpInitial).TotalSeconds >= 5)
        {
            randomizer.generateNewReaction = true;
        }
    }
}
