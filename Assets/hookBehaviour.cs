using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookBehaviour : MonoBehaviour
{
    public float hookSpeed; //speed the hook moves horizontally


    void Start()
    {
        hookSpeed = 15; //speed the hook moves horizontally set to 15
    }


    void Update()
    {
        if (transform.position.x >= 11) //if x-pos greater than 11, only allowed to move left (used to keep in screen)
        {
            transform.position += Vector3.left * (hookSpeed + 1) * Time.deltaTime; //give a slight bump to the left incase somehow beyond x>11, otherwise stuck
        }
        if (transform.position.x <= -11) //if x-pos less than -11, only allowed to move right (used to keep in screen)
        {
            transform.position += Vector3.right * (hookSpeed + 1) * Time.deltaTime; //give a slight bump to the right incase somehow beyond x>11, otherwise stuck
        }


        if (transform.position.x <= 11 && transform.position.x >= -11) //if on the screen, inside -11, 11
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //if left arrow is clicked, move left (will change to touch when adapting to mobile, but this is a prototype)
            {
                transform.position += Vector3.left * hookSpeed * Time.deltaTime; //move the x position left
            }

            else if (Input.GetKey(KeyCode.RightArrow)) //if right arrow is clicked, move right (will change to touch when adapting to mobile, but this is a prototype)
            {
                transform.position += Vector3.right * hookSpeed * Time.deltaTime; //move the x position right
            }
        }
    }
}
