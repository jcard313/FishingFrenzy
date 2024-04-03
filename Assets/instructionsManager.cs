using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class InstructionsManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsScreen;

    public void openInstructions() 
    {
        SFXAudioManager.Instance.PlaySound(0);
        instructionsScreen.SetActive(true);
    }
    public void Back()
    {
        // play sound and close instructions menu
        SFXAudioManager.Instance.PlaySound(0);
        instructionsScreen.SetActive(false);
    }

}
