using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    float effectDuration = 0.5f;
    float timeOfCreation;
    // Start is called before the first frame update
    void Start()
    {
        timeOfCreation = speedMultiplier.Instance.elapsedTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 4f * Time.deltaTime * speedMultiplier.Instance.speedMult;
        if (speedMultiplier.Instance.elapsedTime >= timeOfCreation + effectDuration)
        {
            Destroy(gameObject);
        }
    }
}
