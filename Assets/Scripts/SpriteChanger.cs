using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private bool seasonal;

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        SeasonManager.Instance.OnChangeSeason += ChangeSprite;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(Season season)
    {
        switch(season)
        {
            
            case Season.Summer:
                spriteRenderer.sprite = sprites[0];
                break;
            case Season.Winter:
                spriteRenderer.sprite = sprites[1];
                break;
            case Season.Autunm:
                if (seasonal)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                else
                {
                    spriteRenderer.sprite = sprites[0];
                }
                break;
            case Season.Spring:
                if (seasonal)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                else
                {
                    spriteRenderer.sprite = sprites[0];
                }
                break;
        }
    }
}
