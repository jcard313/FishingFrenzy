using Unity.VisualScripting;
using UnityEngine;

public class trashSpawnerBehaviour : MonoBehaviour
{
    public GameObject trash; //trash game object (prefab) used to make clones
    public float trashSpawnInterval; //trash spawning interval
    private float trashNextSpawnTime; //nextSpawnTime of a trash


    void Start()
    {
        trashSpawnInterval = 1.0f; //spawn interval is 1
        trashNextSpawnTime = speedMultiplier.Instance.elapsedTime + trashSpawnInterval; //time of the next spawn
    }


    void Update()
    {
        if (speedMultiplier.Instance.elapsedTime >= trashNextSpawnTime) //if time is greater than the next spawn time, then we need to spawn trash
        {
            float adjChance = Random.Range(-1f, 1f); //random chance to affect the next spawn time for 1 or -1
            SpawnTrash(); //spawn the new trash
            trashNextSpawnTime = speedMultiplier.Instance.elapsedTime + (trashSpawnInterval / speedMultiplier.Instance.speedMult) + (adjChance / speedMultiplier.Instance.speedMult); //calculate next spawn time for trash
        }
    }


    void SpawnTrash()
    {
        float xPosition = Random.Range(-13, 13); //xPosition random, can spawn anywhere on the horizontal (min is -13, max is 13)
        float chance = Random.Range(0f, 100f); //will be used to determine if 1 or two trash spawn this time

        if (chance <= 25f) //25% chance to spawn 2 trash at this time
        {
            Instantiate(trash, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new trash
            xPosition = Random.Range(-13, 13); //recalculate a random xPosition forthe second trash
            Instantiate(trash, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new trash
        }
        else //75% chance to spawn 1 trash at this time
        {
            Instantiate(trash, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new trash
        }
    }
}