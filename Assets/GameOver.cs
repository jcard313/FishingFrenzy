using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static GameOver Instance { get; private set; }
    public bool gameOver = false;
    public Text gameOverText;
    [SerializeField] GameObject pauseButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        transform.gameObject.SetActive(false); // initially deactivate the game over panel
    }

    public void Show()
    {
        transform.gameObject.SetActive(true); // activate the game over panel once game is over. 
        pauseButton.GetComponent<Button>().interactable = false;
    }

    public void RestartGame()
    {
        playerScore.Instance.depth = 0;
        // destroy hook item once restart, and then re-generate by loading new scene. 
        Destroy(hookBehaviour.Instance.gameObject);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        speedMultiplier.Instance.ResetSpeedMultiplier();
        playerScore.Instance.shouldUpdateScore = true; // restart updating score from 0. 
    }


    public void GoHome()
    {
        // move scene to home, and destroy hook. 
        MusicAudioManager.Instance.PlaySound(0); //play main menu music
        SceneManager.LoadScene("StartScreen");
        Destroy(hookBehaviour.Instance.gameObject);

    }

    void Update()
    {
        if (gameOver)
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
