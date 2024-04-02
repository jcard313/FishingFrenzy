using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    public static SFXAudioManager Instance { get; private set; }
    public AudioSource[] soundEffects;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            soundEffects[index].Play();
        }
    }
}