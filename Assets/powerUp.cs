using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float powerUpRiseSpeed;


    void Start()
    {
        powerUpRiseSpeed = 4.0f;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {

            hookBehaviour.Instance.powerUpTimer = Time.time + 7.0f;
            hookBehaviour.Instance.invincibility = true;
            Destroy(gameObject);
        }
    }


    void Update()
    {
        transform.position += Vector3.up * powerUpRiseSpeed * Time.deltaTime * speedMultiplier.Instance.speedMult;
        if (transform.position.y > 24)
        {
            Destroy(gameObject);
        }
    }
}
