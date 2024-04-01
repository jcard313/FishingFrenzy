using UnityEngine;

public class speedMultiplier : MonoBehaviour
{
    public static speedMultiplier Instance { get; private set; } //using singleton for speedMultiplier
    public float elapsedTime; //time that has passed
    public float speedMult; //beginning speedMult
    public int difficultyLevel;


    void Start()
    {
        elapsedTime = 0f;
        speedMult = 1f;
        difficultyLevel = 1; //1 = easy; 5 = hard
    }


    void Awake()
    {
        if (Instance == null) //using singleton for speedMultiplier
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        elapsedTime += Time.deltaTime; //add the time to elapsedTime variable
        speedMult = difficultyLevel + (1f * (elapsedTime / 10f) * 0.5f); //thissi the calculation for my speedMultiplier
    }
}