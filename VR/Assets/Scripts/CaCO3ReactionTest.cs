using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaCO3ReactionTest : MonoBehaviour
{
    [SerializeField] CountdownTimer countdown;
    [SerializeField] Randomize randomizer;
    public TMP_Text canvasText;
    private bool finishedTask = false;
    private DateTime timpInitial;

    public GameObject pivotEprubeta;
    public GameObject pivotFoc;
    [SerializeField] LightFire foc;
    [SerializeField] MeshRendererScript balloon;
    public GameObject fume;
    public GameObject balon;

    public GameObject label;
    public Material CaO_material;

    private float targetPoint;
    private Vector3 initialScale;
    private Vector3 finalScale;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private bool reactionCompleted = false;
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
        if (!finishedTask)
        {
            canvasText.text = "Decompose CaCO3 and inflate the balloon.";
        }
        if (balloon.balonPesteEprubeta == true)
        {
            balon_ok = true;
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
                        timpInitial = DateTime.Now;
                        fume.SetActive(false);
                        canvasText.text = "Task finished!";
                        countdown.continua = false;
                        finishedTask = true;
                    }
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
