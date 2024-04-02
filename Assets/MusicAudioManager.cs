using UnityEngine;

public class MusicAudioManager : MonoBehaviour
{
    public static MusicAudioManager Instance { get; private set; }
    public AudioSource[] music;

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
        if (index >= 0 && index < music.Length)
        {
            music[index].Play();
        }
    }
}