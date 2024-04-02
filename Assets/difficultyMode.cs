using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class difficultyMode : MonoBehaviour
{
    public static difficultyMode Instance { get; private set; }
    public int difficultyLevel;
    // Start is called before the first frame update

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
        difficultyLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
