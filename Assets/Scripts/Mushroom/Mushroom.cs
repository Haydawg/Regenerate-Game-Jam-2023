using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mushroom
{
    public MushroomData mushroomData;
    public int amount;

    public Mushroom(MushroomData mushroomData, int amount)
    {
        this.mushroomData = mushroomData;
        this.amount = amount;
    }
}
