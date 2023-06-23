using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public enum Season
{
    Summer,
    Autunm,
    Winter,
    Spring
};
public class SeasonManager : MonoBehaviour
{
    public static SeasonManager Instance;
    public delegate void ChangeSeason(Season season);
    public event ChangeSeason OnChangeSeason;


    public Season currentSeason;
    int seasonIterator;
    public int seasonCounter;

    [SerializeField] private Tile groundTile;
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private Tilemap tilemap;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentSeason = (Season)seasonIterator;
        seasonCounter = 1;
    }


    public void NextSeason()
    {
        FadeToBlack.Instance.StartFade(2);
        StartCoroutine(MoveSeason(2));
        seasonCounter++;
        if(seasonCounter >= 9)
        {
            EventManager.Instance.EndGame?.Invoke();
        }
    }
    IEnumerator MoveSeason(int time)
    {
        yield return new WaitForSeconds(time);
        if (seasonIterator < 3)
        {
            seasonIterator++;
        }
        else
        {
            seasonIterator = 0;
        }
        Movement.Instance.ResetMovementPoints(10);
        currentSeason = (Season)seasonIterator;
        OnChangeSeason.Invoke(currentSeason);
        switch (currentSeason)
        {

            case Season.Summer:
                groundTile.sprite = groundSprites[0];
                tilemap.RefreshAllTiles();
                break;
            case Season.Autunm:
                groundTile.sprite = groundSprites[0];
                tilemap.RefreshAllTiles();
                break;
            case Season.Spring:
                groundTile.sprite = groundSprites[0];
                tilemap.RefreshAllTiles();
                break;
            case Season.Winter:
                groundTile.sprite = groundSprites[1];
                tilemap.RefreshAllTiles();
                break;
        }

        Movement.Instance.ReturnToCentre();
    }
}
