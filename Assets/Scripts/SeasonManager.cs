using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
    public delegate void ChangeSeason();
    public event ChangeSeason OnChangeSeason;

    public Season currentSeason;
    int seasonIterator;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentSeason = (Season)seasonIterator;
    }


    public void NextSeason()
    {
        if(seasonIterator < 3)
        {
            seasonIterator++;
        }
        else
        {
            seasonIterator = 0;
        }
        currentSeason = (Season)seasonIterator;
        OnChangeSeason.Invoke();
    }
}
