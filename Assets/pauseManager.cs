using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject settingsScreen;
    [SerializeField] KeyCode pauseKey;

    public void Pause()
    {
        MusicAudioManager.Instance.music[1].Pause();
        SFXAudioManager.Instance.PlaySound(0);
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Console.Write("pausing");
    }

    public void Resume()
    {
        MusicAudioManager.Instance.music[1].UnPause();
        SFXAudioManager.Instance.PlaySound(0);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMenu() 
    {
        SFXAudioManager.Instance.PlaySound(0);
        Time.timeScale = 1f;
        // assuming the main menu is the scene 0
        SceneManager.LoadScene(0);
        MusicAudioManager.Instance.music[1].Stop();
    }

    public void OpenSettings()
    {
        SFXAudioManager.Instance.PlaySound(0);
        settingsScreen.SetActive(true);
    }

    public void Update() {
        if(Input.GetKeyDown(pauseKey)) {
            Pause();
        }
    }
}
