using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] GameObject settingsScreen;
    [SerializeField] GameObject pauseScreen;
    public Slider soundEffectsSlider;
    public AudioMixer soundEffectsMixer;
    public Slider musicSlider;
    public AudioMixer musicMixer;


    private void Start() {
        // setting values of sound
        float value;
        soundEffectsMixer.GetFloat("Volume", out value);
        soundEffectsSlider.value = value;
        musicMixer.GetFloat("Volume", out value);
        musicSlider.value = value;
    }
    public void Back()
    {
        SFXAudioManager.Instance.PlaySound(0);
        settingsScreen.SetActive(false);
        if(pauseScreen) {
            pauseScreen.SetActive(true);
        }
    }

    public void UpdateSoundEffectsVolume()
    {
        soundEffectsMixer.SetFloat("Volume", soundEffectsSlider.value);
    }
    
    public void UpdateMusicVolume()
    {
        musicMixer.SetFloat("Volume", musicSlider.value);
    }
}
