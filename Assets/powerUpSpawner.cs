using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject doublePointsPowerUp;
    public float powerUpSpawnInterval;
    private float powerUpNextSpawnTime;


    void Start()
    {
        powerUpSpawnInterval = 8.0f;
        powerUpNextSpawnTime = speedMultiplier.Instance.elapsedTime + powerUpSpawnInterval;
    }


    void Update()
    {
        if (speedMultiplier.Instance.elapsedTime >= powerUpNextSpawnTime)
        {
            SpawnPowerUp();
            powerUpNextSpawnTime = speedMultiplier.Instance.elapsedTime + powerUpSpawnInterval;
        }
    }


    void SpawnPowerUp()
    {
        float xPosition = Random.Range(-13, 13);
        float chance = Random.Range(0f, 100f);

        if (chance <= 30f)
        {
            Instantiate(powerUp, new Vector3(xPosition, -22, 0), Quaternion.identity);
        }
        else if (chance <= 60f)
        {
            Instantiate(doublePointsPowerUp, new Vector3(xPosition, -22, 0), Quaternion.identity);
        }
    }
}