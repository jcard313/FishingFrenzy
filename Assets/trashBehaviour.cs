using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class trashBehaviour : MonoBehaviour
{
    public float trashRiseSpeed; //rising speed of the trash
    public bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI depthText;
    public static trashBehaviour Instance { get; private set; }


    void Start()
    {
        trashRiseSpeed = 3.0f; //rising speed set to 3
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hookBehaviour.Instance.invincibility && other.CompareTag("Hook"))
        {
            Destroy(speedMultiplier.Instance.gameObject);
            Time.timeScale = 0f;
            // once the game is over, display the game over pop up. 
            MusicAudioManager.Instance.music[1].Stop(); //stop music
            SFXAudioManager.Instance.PlaySound(2); //play crash sound effect
            gameOver = true;
            GameOver.Instance.Show();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // if the game is not over, trash will keep rising
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
            // update flag on other .cs files 
            GameOver gameOverInstance = FindObjectOfType<GameOver>();
            GameOver.Instance.gameOver = true;
            hookBehaviour.Instance.gameOver = true;

            // Stop coroutines in fishBehaviour, and update flag for all active fishes 
            fishBehaviour[] fishBehaviours = FindObjectsOfType<fishBehaviour>();
            foreach (fishBehaviour fish in fishBehaviours)
            {
                fish.StopAllCoroutines();
                fish.shouldUpdate = false;

            }

            // stop coroutines in trashBehaviours, and update flag for active trashs
            trashBehaviour[] trashBehaviours = FindObjectsOfType<trashBehaviour>();
            foreach (trashBehaviour trash in trashBehaviours)
            {
                trash.StopAllCoroutines();
                trash.gameOver = true;

            }

            // deactivate updating playerScore UI - I think this method should be updated in a different way. 
            if (playerScore.Instance != null && playerScore.Instance.scoreText != null)
            {
                playerScore.Instance.shouldUpdateScore = false;
            }
        }
    }
}
