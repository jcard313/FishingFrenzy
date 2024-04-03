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
        // play sound effect and show pause menu
        MusicAudioManager.Instance.music[1].Pause();
        SFXAudioManager.Instance.PlaySound(0);
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        // play sound effect and close pause menu
        MusicAudioManager.Instance.music[1].UnPause();
        SFXAudioManager.Instance.PlaySound(0);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMenu() 
    {
        // load main menu, reset speed and reset speed and hook location
        Destroy(speedMultiplier.Instance.gameObject);
        SFXAudioManager.Instance.PlaySound(0);
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
        Destroy(hookBehaviour.Instance.gameObject);
        MusicAudioManager.Instance.music[1].Stop();
    }

    public void OpenSettings()
    {
        // open settings menu
        SFXAudioManager.Instance.PlaySound(0);
        settingsScreen.SetActive(true);
    }

    public void Update() {
        // open pause menu if pause key is pressed
        if(Input.GetKeyDown(pauseKey)) {
            Pause();
        }
    }
}
