using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishBehaviour : MonoBehaviour
{
    public float fishSpeed; //fish speed is the horizontal, automatic swim speed
    public SpriteRenderer fishSprite; //used to get the sprite
    public float fishRiseSpeed; //speed at which the fish rises
    public string fishType; //Type of fish
    public bool shouldUpdate = true;
    public static fishBehaviour Instance { get; private set; }


    void Start()
    {
        fishRiseSpeed = 4.0f; //speed at which the fish rises set to 4
        fishSpeed = 4.0f; //fish speed is the horizontal, automatic swim speed set to 4
        fishSprite = GetComponent<SpriteRenderer>(); //get the sprite
    }


    void OnTriggerEnter2D(Collider2D other) //if there is a collision
    {
        if (other.CompareTag("Hook")) //ensure it is with the hook
        {
            AudioManager.Instance.PlaySound(3);
            if (fishType == "NF") //normal fish
            { playerScore.Instance.incrementFishCounter(); }
            else if(fishType == "PF") //puffer fish
            { playerScore.Instance.incrementPufferFishCounter(); }
            else // fishType == "S" for squid
            { playerScore.Instance.incrementSquidCounter(); }
            Destroy(gameObject); //destroy the fish, (will add a score mechanism for number of fish collect eventually, but this is just a prototype)
        }
    }


    // Update is called once per frame
    void Update()
    {
        // update position if game is not over. 
        if (shouldUpdate)
        {
            transform.position += Vector3.up * fishSpeed * Time.deltaTime * speedMultiplier.Instance.speedMult; //move the fish horizontally (swimming)
            if (transform.position.y > 24) //if the fish is off the screen, then destroy the object
            {
                Destroy(gameObject); //destroys the object
            }

            if (fishSprite.flipX == true) //if the fish is facing left
            {
                transform.position += Vector3.left * fishSpeed * Time.deltaTime; //then move left
            }
            if (fishSprite.flipX == false) //if the fish is facing right
            {
                transform.position += Vector3.right * fishSpeed * Time.deltaTime; //then move right
            }

            if (transform.position.x <= -13f) //if fish is at the left boarder
            {
                fishSprite.flipX = false; //then flip the fish to the right
            }
            else if (transform.position.x >= 13f) //if fish is at the right boarder
            {
                fishSprite.flipX = true; //then flip the fish to the left
            }
        }else{
                // stop updating fish's positions. 
                transform.position = transform.position;
        }
    }
}
