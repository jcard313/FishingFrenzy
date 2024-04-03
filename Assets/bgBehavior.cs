using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    public SpriteRenderer backgroundSpriteRenderer; // Assign this in the inspector
    public Sprite defaultBackgroundSprite;
    public Sprite secondBackgroundSprite; 

    void Start()
    {
        UpdateBackground();
    }

    private void UpdateBackground()
    {
        switch (BgCosmeticSelection.bgSelection)
        {
            case 0:
                backgroundSpriteRenderer.sprite = defaultBackgroundSprite;
                break;
            case 1:
                backgroundSpriteRenderer.sprite = secondBackgroundSprite;
                break;
            default:
                backgroundSpriteRenderer.sprite = defaultBackgroundSprite;
                break;
        }
    }
}
