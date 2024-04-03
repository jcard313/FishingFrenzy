using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BgCosmeticSelection : MonoBehaviour
{
    public static int bgSelection = 0;
    public Text defaultBgActiveText;
    public Text bg2ActiveText;

    private void Start()
    {
        // Update the active selection indicators based on the current selection
        UpdateSelection();
    }

    public void SelectedDefaultBg()
    {
        bgSelection = 0;
        UpdateSelection();
    }

    public void Selected2ndBg()
    {
        bgSelection = 1;
        UpdateSelection();
    }

    private void UpdateSelection() 
    {
        if (bgSelection == 0)
        {
            SFXAudioManager.Instance.PlaySound(0); //play click sound
            defaultBgActiveText.gameObject.SetActive(true);
            bg2ActiveText.gameObject.SetActive(false);
        }
        else if (bgSelection == 1)
        {
            SFXAudioManager.Instance.PlaySound(0);
            defaultBgActiveText.gameObject.SetActive(false);
            bg2ActiveText.gameObject.SetActive(true);;
        }
    }

    public void GoBack()
    {
        SFXAudioManager.Instance.PlaySound(0); //play click sound
        SceneManager.LoadScene("CosmeticsScreen");
    }
}
