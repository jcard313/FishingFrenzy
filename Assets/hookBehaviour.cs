using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hookBehaviour : MonoBehaviour
{
    public static hookBehaviour Instance { get; private set; }
    public float hookSpeed; //speed the hook moves horizontally
    public bool invincibility = false;
    public bool doublePoints = false;
    public float ipowerUpTimer = 0f;
    public float dpowerUpTimer = 0f;
    public SpriteRenderer hookSprite;
    public bool gameOver = false;
    public Sprite defaultHookSprite;
    public Sprite blueOceanHookSprite;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MusicAudioManager.Instance.music[0].Stop(); //stop main menu music
        MusicAudioManager.Instance.PlaySound(1); //play background game music
        int hookSelection = HookCosmeticSelection.hookSelection;
        hookSpeed = 15; //speed the hook moves horizontally set to 15
        hookSprite = GetComponent<SpriteRenderer>();
        if(hookSelection == 1)
        {
            hookSprite.sprite = blueOceanHookSprite;
        }
        else if(hookSelection == 0) 
        {
            hookSprite.sprite = defaultHookSprite;
        }
    }


    void Update()
    {
        // if game is not over, control hook with arrow keys. 
        if(!gameOver){
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

            if (!(Time.time < ipowerUpTimer))

            {
                invincibility = false;
                hookSprite.color = Color.white;
            }
            else
            {
                hookSprite.color = Color.yellow;
            }

            if (!(Time.time < dpowerUpTimer))

            {
                doublePoints = false;
            }
        }
        else{ // else the game is over, disable keys. 
            
        }
        

    }
}
