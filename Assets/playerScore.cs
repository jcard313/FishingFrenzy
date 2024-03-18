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
    public float score = 0;

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
        float depth = Time.time * speedMultiplier.Instance.speedMult; //how I calculate the depth (time * speedMultiplier)
        depthText.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m"; //prints the depth

        score = depth + 30 * fishCounter;
        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }

    public void incrementFishCounter()
    {
        fishCounter++;
    }
}
