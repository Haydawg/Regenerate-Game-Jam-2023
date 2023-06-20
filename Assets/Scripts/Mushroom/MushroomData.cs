using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "My Assets/Mushroom")]
public class MushroomData : ScriptableObject
{
    public Sprite image;
    public string name;
    public Season plantingSeason;
    public string description;
}
