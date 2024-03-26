using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Console.Write("pausing");
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMenu() 
    {
        Time.timeScale = 1f;
        // assuming the main menu is the scene 0
        SceneManager.LoadScene(0);
    }

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }
}
