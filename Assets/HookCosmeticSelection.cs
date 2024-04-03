using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HookCosmeticSelection : MonoBehaviour
{
    public static int hookSelection = 0;
    public Text defaultHookActiveText;
    public Text blueOceanHookActiveText;

    private void Start()
    {
        // Update the active selection indicators based on the current selection
        UpdateSelection();
    }

    public void SelectedDefault()
    {
        hookSelection = 0;
        UpdateSelection();
    }

    public void SelectedBlueOcean()
    {
        hookSelection = 1;
        UpdateSelection();
    }

    private void UpdateSelection() 
    {
        if (hookSelection == 0)
        {
            SFXAudioManager.Instance.PlaySound(0); //play click sound
            defaultHookActiveText.gameObject.SetActive(true);
            blueOceanHookActiveText.gameObject.SetActive(false);
        }
        else if (hookSelection == 1)
        {
            SFXAudioManager.Instance.PlaySound(0); //play click sound
            defaultHookActiveText.gameObject.SetActive(false);
            blueOceanHookActiveText.gameObject.SetActive(true);

        }
    }

    public void GoBack()
    {
        SFXAudioManager.Instance.PlaySound(0); //play click sound
        SceneManager.LoadScene("CosmeticsScreen");
    }
}
