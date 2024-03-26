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

    // any variables for difficulty 

    public void Start()
    {
        InitializeDifficultyDropdown();
        
        startButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(settingMethod);
        cosmeticButton.onClick.AddListener(CosmeticMethod);
        difficultyDropdown.onValueChanged.AddListener(delegate { DifficultyChanged(difficultyDropdown); });
    }

    public void InitializeDifficultyDropdown()
    {
        // difficultyDropdown.ClearOptions();

        List<string> difficulties = new List<string> { "Easy", "Hard" };
        // difficultyDropdown.AddOptions(difficulties);

        // difficultyDropdown.value = 0;
        // difficultyDropdown.RefreshShownValue();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void settingMethod(){
        // go to setting scene
        // SceneManager.LoadScene("SettingScene");
    }

    public void CosmeticMethod(){
        // go to Cosmetic Scene
        // SceneManager.LoadScene("CosmeticScene");
    }
    public void DifficultyChanged(Dropdown dropdown)
{
    if (dropdown != null && dropdown.options != null && dropdown.options.Count > 0)
    {
        Debug.Log($"Difficulty : {dropdown.options[dropdown.value].text}");
        // change your difficulty logic

        // easy

        // hard
    } else
    {
        Debug.LogWarning("Dropdown or options are null.");
    }
}


    // Use this if you need, otherwise you may directly edit on DifficultyChanged method @Andrew
    // void updateDifficulty(// any variable requires
    // ){
    //     switch (difficulty){
    //         case 0: // Easy
    //             // easy settings
    //             break;
    //         case 1: // Hard
    //             // hard setting
    //             break;
    //         default:
    //             break;
    //     }

    // }
    
}
