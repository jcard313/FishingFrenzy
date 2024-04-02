using UnityEngine;

public class speedMultiplier : MonoBehaviour
{
    public static speedMultiplier Instance { get; private set; }
    public float elapsedTime;
    public float speedMult;
    //public int difficultyLevel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetSpeedMultiplier();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        speedMult = difficultyMode.Instance.difficultyLevel + (1f * (elapsedTime / 10f) * 0.5f);
    }

    public void ResetSpeedMultiplier()
    {
        elapsedTime = 0f;
        speedMult = 1f;
        //difficultyLevel = 1;
    }
}