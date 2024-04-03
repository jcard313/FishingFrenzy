using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class playerScore : MonoBehaviour
{
    public static playerScore Instance { get; private set; }
    public TextMeshProUGUI depthText; 
    public TextMeshProUGUI scoreText;
    public int fishCounter = 0;
    public int pufferFishCounter = 0;
    public int squidCounter = 0;
    public float score = 0;
    public float depth = 0; 
    public bool shouldUpdateScore = true;
    public float highScore;
    public TextMeshProUGUI highScoreText;
    public bool newHighScore = false;

    public static void ReinitializeInstance()
    {
        if (Instance == null)
        {
            GameObject newPlayerScoreObject = new GameObject("PlayerScore");
            Instance = newPlayerScoreObject.AddComponent<playerScore>();
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        depth = 0;
    }

    void Start()
    {
        speedMultiplier.Instance.ResetSpeedMultiplier();
        highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat("highScore");
        highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
    }

    void Update()
    {
        // update score
        if (shouldUpdateScore) {
            if (depthText == null)
            {
                depthText = GameObject.Find("DepthCounter").GetComponent<TextMeshProUGUI>();
            }
            if (scoreText == null)
            {
                scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            }
            if (highScoreText == null)
            {
                highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
            }

            depth = speedMultiplier.Instance.elapsedTime * speedMultiplier.Instance.speedMult; //how I calculate the depth (time * speedMultiplier)
            depthText.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m"; //prints the depth

            score = depth + 30 * fishCounter + 50*pufferFishCounter + 70*squidCounter;
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();

            if (score>highScore) {
                highScore = score;
                PlayerPrefs.SetFloat("highScore", highScore);
                highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
                newHighScore = true;
            } else {
                newHighScore = false;
            }
        }

        if (hookBehaviour.Instance.doublePoints)
        {
            scoreText.color = Color.yellow;
        }
        else
        {
            scoreText.color = Color.white;
        }
        
    }

    public void incrementFishCounter()
    {
        if (hookBehaviour.Instance.doublePoints)
        {
            fishCounter++;
            fishCounter++;
        }
        else
        {
            fishCounter++;
        }
    }
    public void incrementPufferFishCounter()
    {
        if (hookBehaviour.Instance.doublePoints)
        {
            pufferFishCounter++;
            pufferFishCounter++;
        }
        else
        {
            pufferFishCounter++;
        }
    }
    public void incrementSquidCounter()
    {
        if (hookBehaviour.Instance.doublePoints)
        {
            squidCounter++;
            squidCounter++;
        }
        else
        {
            squidCounter++;
        }
    }
}
