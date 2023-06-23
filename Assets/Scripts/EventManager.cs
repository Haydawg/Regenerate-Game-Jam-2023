using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public delegate void LogInteraction(HarvestableLog log);
    public LogInteraction onLogInteraction;

    public delegate void LoadScene(int sceneID);
    public LoadScene onLoadScene;

    public delegate void ShowMushroominfo(MushroomData data);
    public ShowMushroominfo OnMushrromDisplay;

    public UnityEvent EndGame;
    public UnityEvent Quit;
    public UnityEvent PauseGame;
    public UnityEvent ShowSettins;

    private void Awake()
    {
        Instance = this;
    }

}
