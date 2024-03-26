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

    public bool gameOver2 = false;

    public Text gameOverText;

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

        transform.gameObject.SetActive(false);
    }

    public void Show(int score, int depth)
    {
        transform.gameObject.SetActive(true);
        // gameOverText.text = "Game Over \n Score : " + score.ToString() + " \n Depth: " + depth.ToString();
    }

    public void RestartGame()
    {
        Destroy(hookBehaviour.Instance.gameObject);
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }


    public void GoHome()
    {
        SceneManager.LoadScene("StartScreen");
    }

    void Update()
    {
        if (gameOver2)
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
