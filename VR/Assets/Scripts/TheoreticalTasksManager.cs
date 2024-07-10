using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheoreticalTasksManager : MonoBehaviour
{
    [SerializeField] Randomize randomize;
    [SerializeField] CountdownTimer countdown;
    public TMP_Text canvasText;
    public TMP_Text buton1;
    public TMP_Text buton2;
    public TMP_Text buton3;
    public TMP_Text feedback;

    public GameObject canvasForReactionTask;
    public GameObject canvasForTheoreticalTask;

    private DateTime timpInitial;
    private bool finished = false;

    void Update()
    {
        if (finished && (DateTime.Now - timpInitial).TotalSeconds >= 3)
        {
            randomize.generateNewReaction = true;
            finished = false;
            feedback.text = " ";
            Finish();
        }
        if (randomize.currentReactionInTestPhase == 9)
        {
            canvasText.text = "What is the color of phenolphthalein in a basic solution?";
            buton1.text = "Carmine red";
            buton2.text = "Purple";
            buton3.text = "Dark blue";
        }
        else if (randomize.currentReactionInTestPhase == 10)
        {
            canvasText.text = "What is the color of methyl orange in an acidic solution?";
            buton1.text = "Yellow";
            buton2.text = "Red";
            buton3.text = "Orange";
        }
        else if (randomize.currentReactionInTestPhase == 11)
        {
            canvasText.text = "What color does copper(II) sulfate turn when it is hydrated?";
            buton1.text = "Red";
            buton2.text = "Green";
            buton3.text = "Blue";
        }
        else if (randomize.currentReactionInTestPhase == 12)
        {
            canvasText.text = "What are the products when sodium reacts with water?";
            buton1.text = "Sodium hydroxide and hydrogen gas";
            buton2.text = "Sodium chloride and oxygen gas";
            buton3.text = "Sodium oxide and water";
        }
        else if (randomize.currentReactionInTestPhase == 13)
        {
            canvasText.text = "What is observed when copper(II) chloride is burned in a flame?";
            buton1.text = "A red flame";
            buton2.text = "A green flame";
            buton3.text = "A blue flame";
        }
        else if (randomize.currentReactionInTestPhase == 14)
        {
            canvasText.text = "What gas is produced when sodium bicarbonate reacts with hydrochloric acid?";
            buton1.text = "Oxygen";
            buton2.text = "Hydrogen";
            buton3.text = "Carbon dioxide";
        }
        else if (randomize.currentReactionInTestPhase == 15)
        {
            canvasText.text = "What type of reaction occurs when potassium reacts with water?";
            buton1.text = "Single displacement reaction"; //da
            buton2.text = "Decomposition reaction";
            buton3.text = "Neutralization reaction";
        }
        else if (randomize.currentReactionInTestPhase == 16)
        {
            canvasText.text = "What color is the smoke produced in the reaction between aluminum and iodine?";
            buton1.text = "White";
            buton2.text = "Purple"; //da
            buton3.text = "Yellow";
        }
        else if (randomize.currentReactionInTestPhase == 17)
        {
            canvasText.text = "Which substance acts as a catalyst in the reaction between aluminum and iodine?";
            buton1.text = "Hydrogen peroxide";
            buton2.text = "Sulfuric acid";
            buton3.text = "Water"; //da
        }
        else if (randomize.currentReactionInTestPhase == 18)
        {
            canvasText.text = "What is the color change when FeSO4 decomposes to form Fe2O3?";
            buton1.text = "Green to brown"; //da
            buton2.text = "Blue to white";
            buton3.text = "Red to yellow";
        }
    }

    public void CheckButton1()
    {
        if(!finished)
        {
            if (randomize.currentReactionInTestPhase == 9 || randomize.currentReactionInTestPhase == 12 || randomize.currentReactionInTestPhase == 15 || randomize.currentReactionInTestPhase == 18)
            {
                feedback.text = "Correct!";
                feedback.color = Color.green;
            }
            else
            {
                feedback.text = "Incorrect!";
                feedback.color = Color.red;
                countdown.wasScored = true;
            }
            countdown.continua = false;
            timpInitial = DateTime.Now;
            finished = true;
        }
    }

    public void CheckButton2()
    {
        if(!finished)
        {
            if (randomize.currentReactionInTestPhase == 10 || randomize.currentReactionInTestPhase == 13 || randomize.currentReactionInTestPhase == 16)
            {
                feedback.text = "Correct!";
                feedback.color = Color.green;
            }
            else
            {
                feedback.text = "Incorrect!";
                feedback.color = Color.red;
                countdown.wasScored = true;
            }
            countdown.continua = false;
            finished = true;
            timpInitial = DateTime.Now;
        }
    }

    public void CheckButton3()
    {
        if (!finished)
        {
            if (randomize.currentReactionInTestPhase == 11 || randomize.currentReactionInTestPhase == 14 || randomize.currentReactionInTestPhase == 17)
            {
                feedback.text = "Correct!";
                feedback.color = Color.green;
            }
            else
            {
                feedback.text = "Incorrect!";
                feedback.color = Color.red;
                countdown.wasScored = true;
            }
            countdown.continua = false;
            finished = true;
            timpInitial = DateTime.Now;
        }
    }

    void Finish()
    {
        if (randomize.stopTesting)
        {
            canvasForReactionTask.SetActive(true);
            canvasForTheoreticalTask.SetActive(false);
        }
    }
}
