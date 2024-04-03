using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class InstructionsManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsScreen;

    public void Back()
    {
        SFXAudioManager.Instance.PlaySound(0);
        instructionsScreen.SetActive(false);
    }

}
