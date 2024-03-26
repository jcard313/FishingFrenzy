using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class trashBehaviour : MonoBehaviour
{
    public float trashRiseSpeed; //rising speed of the trash
    public bool gameOver = false;

    public int score; 
    public int depth;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI depthText;
    public static trashBehaviour Instance { get; private set; }

    private playerScore scoreScript;
    private GameOver gameOverScript;

    void Start()
    {
        trashRiseSpeed = 3.0f; //rising speed set to 3

        scoreScript = FindObjectOfType<playerScore>();
        gameOverScript = FindObjectOfType<GameOver>(); 
    }


    void OnTriggerEnter2D(Collider2D other)
{
    if (!hookBehaviour.Instance.invincibility && other.CompareTag("Hook"))
    {
        gameOver = true;
        score = (int)scoreScript.score;
        depth = (int)scoreScript.depth;

        GameOver.Instance.Show(score, depth);
    }
}


    // Update is called once per frame
    void Update()
{
    if (!gameOver)
    {
        transform.position += Vector3.up * trashRiseSpeed * Time.deltaTime * speedMultiplier.Instance.speedMult;

        if (transform.position.y > 24)
        {
            Destroy(gameObject);
        }
    }
    else
    {
        GameOver gameOverInstance = FindObjectOfType<GameOver>();
        if (gameOverInstance != null)
        {
            gameOverInstance.gameOverPanel.SetActive(true);
        }

        GameOver.Instance.gameOver2 = true;

        // Stop coroutines in fishBehaviour
        fishBehaviour[] fishBehaviours = FindObjectsOfType<fishBehaviour>();
        foreach (fishBehaviour fish in fishBehaviours)
        {
            fish.StopAllCoroutines();
        }

        // Destroy UI elements
        if (playerScore.Instance != null && playerScore.Instance.scoreText != null)
        {
            Destroy(playerScore.Instance.scoreText.gameObject);
        }
        if (playerScore.Instance != null && playerScore.Instance.depthText != null)
        {
            Destroy(playerScore.Instance.depthText.gameObject);
        }


        // Stop Update in fishBehaviour
        fishBehaviour[] fishScripts = FindObjectsOfType<fishBehaviour>();
        foreach (fishBehaviour fish in fishScripts)
        {
            fish.shouldUpdate = false;
        }

        // Stop Update in other scripts if necessary
    }
}

}
