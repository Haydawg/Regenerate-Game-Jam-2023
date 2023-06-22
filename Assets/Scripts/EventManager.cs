using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public delegate void LogInteraction(HarvestableLog log);
    public LogInteraction onLogInteraction;

    public delegate void ShowMushroominfo(MushroomData data);
    public ShowMushroominfo OnMushrromDisplay;

    private void Awake()
    {
        Instance = this;
    }

}
