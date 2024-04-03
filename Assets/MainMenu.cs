using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button settingButton;
    public Button cosmeticButton;
    public Dropdown difficultyDropdown;
    public Button quitButton;
    public GameObject settingsMenu;

    // any variables for difficulty 

    public void Start()
    {
        MusicAudioManager.Instance.PlaySound(0); //play main menu music
        InitializeDifficultyDropdown(); // initialize difficulty
        Time.timeScale = 1f;
        // initialize all the buttons and assign each button with the corresponding methods.         
        startButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(settingMethod);
        cosmeticButton.onClick.AddListener(CosmeticMethod);
        quitButton.onClick.AddListener(QuitGame);
        difficultyDropdown.onValueChanged.AddListener(delegate { DifficultyChanged(difficultyDropdown); });
    }

    public void InitializeDifficultyDropdown()
    {
        difficultyMode.Instance.difficultyLevel = 1;
    }

    public void StartGame()
    {
        SFXAudioManager.Instance.PlaySound(0);
        SceneManager.LoadScene("SampleScene");
    }
    
    public void settingMethod(){
        SFXAudioManager.Instance.PlaySound(0);
        if(settingsMenu) {
            settingsMenu.SetActive(true);
        }
    }

    public void CosmeticMethod(){
        SFXAudioManager.Instance.PlaySound(0);
        SceneManager.LoadScene("CosmeticsScreen");
    }
    public void DifficultyChanged(Dropdown dropdown)
    {
        if (dropdown != null && dropdown.options != null && dropdown.options.Count > 0)
        {
            string selectedDifficulty = dropdown.options[dropdown.value].text;
            Debug.Log($"Difficulty: {selectedDifficulty}");

            if (selectedDifficulty == "Easy")
            {
                SFXAudioManager.Instance.PlaySound(0);
                difficultyMode.Instance.difficultyLevel = 1;
                Debug.Log("Easy difficulty selected");
            }
            else if (selectedDifficulty == "Hard")
            {
                SFXAudioManager.Instance.PlaySound(0);
                difficultyMode.Instance.difficultyLevel = 5;
                Debug.Log("Hard difficulty selected");
            }
        }
        else
        {
            Debug.LogWarning("Dropdown or options are null.");
        }


    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
