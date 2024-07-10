using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 60f;
    int score;
    public bool wasScored = false;
    public bool continua = true;
    public bool reset = false;

    [SerializeField] TMP_Text countdownText;
    [SerializeField] TMP_Text scoreText;      // Textul pentru scor
    [SerializeField] Randomize randomizer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        score = 0;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            startingTime = 60f;
            currentTime = 60f;
            continua = true;
            reset = false;
            wasScored = false;
        }
        //currentTime -= 1 * Time.deltaTime;
        //if (currentTime >= 0 && continua)
        //{
        //    countdownText.text = Mathf.FloorToInt(currentTime).ToString();
        //}
        if (continua)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime >= 0)
            {
                countdownText.text = Mathf.FloorToInt(currentTime).ToString();
            }
            else
            {
                continua = false; // Stop the timer when it reaches zero
            }
        }
        if(!wasScored && currentTime <= 0)
        {
            continua = false;
            wasScored = true;
            randomizer.generateNewReaction = true;
        }
        if (!continua && !wasScored && currentTime >= 0)
        {
            if (currentTime >= 30)
            {
                score += 100;
            }
            else if (currentTime >= 30)
            {
                score += 50;
            }
            else if (currentTime >= 20)
            {
                score += 40;
            }
            else if (currentTime >= 15)
            {
                score += 20;
            }
            else if (currentTime >= 10)
            {
                score += 15;
            }
            else if (currentTime >= 5) 
            {
                score += 10;
            }
            else
            {
                score += 5;
            }
            scoreText.text = score.ToString();
            wasScored = true;
        }
    }
}
