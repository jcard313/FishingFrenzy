using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CosmeticsRouting : MonoBehaviour
{

    public void RouteHookCosmetics()
    {
        SceneManager.LoadScene("HookCosmeticsScreen");
    }


    public void GoHome()
    {
        // move scene to home, and destroy hook. 
        SFXAudioManager.Instance.PlaySound(0);
        SceneManager.LoadScene("StartScreen");

    }
}
