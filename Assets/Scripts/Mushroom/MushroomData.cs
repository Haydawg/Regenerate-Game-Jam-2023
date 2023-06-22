using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "My Assets/Mushroom")]
public class MushroomData : ScriptableObject
{
    public Sprite image;
    public Sprite juvenileImage;
    public string type;
    public Season plantingSeason;
    public Season harvestSeason;
    public string description;
}
