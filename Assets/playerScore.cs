using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScore : MonoBehaviour
{
    public static playerScore Instance { get; private set; }
    public TextMeshProUGUI depthText; //text that dislays depth
    public TextMeshProUGUI scoreText;
    public int fishCounter = 0;
    public int pufferFishCounter = 0;
    public int squidCounter = 0;
    public float score = 0;
    public float depth = 0; // made the depth to public to display once the game is over by @Jiho

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

    void Update()
    {
        depth = Time.time * speedMultiplier.Instance.speedMult; //how I calculate the depth (time * speedMultiplier)
        depthText.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m"; //prints the depth

        score = depth + 30 * fishCounter + 50*pufferFishCounter + 70*squidCounter;
        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }

    public void incrementFishCounter()
    {
        fishCounter++;
    }
    public void incrementPufferFishCounter()
    {
        pufferFishCounter++;
    }
    public void incrementSquidCounter()
    {
        squidCounter++;
    }
}
