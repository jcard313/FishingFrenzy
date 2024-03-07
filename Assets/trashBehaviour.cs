using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashBehaviour : MonoBehaviour
{
    public float trashRiseSpeed; //rising speed of the trash


    void Start()
    {
        trashRiseSpeed = 3.0f; //rising speed set to 3
    }


    void OnTriggerEnter2D(Collider2D other) //if trash collides with hook, game over
    {
        if (other.CompareTag("Hook")) //used to ensure hook was the collision
        {
            Application.Quit(); //no game over screen set up yet since its a prototype, so just exit the application
            //as an aside, this Application.Quit(); does not quit the game when in game editor, only affects when game is executed
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * trashRiseSpeed * Time.deltaTime * speedMultiplier.Instance.speedMult; //update the trashs y coordinate
        if (transform.position.y > 24) //if the trash is off the screen, destroy object to save memory
        {
            Destroy(gameObject); //destroys the object
        }
    }
}
