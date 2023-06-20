using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableLog : MonoBehaviour
{
    MushroomData mushroomGrowing;
    public bool canHarvest;
    public bool planted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Harvest()
    {
        if(canHarvest)
        {
            Inventory.Instance.AddMushroom(mushroomGrowing, Random.Range(1, 3));
        }
    }

    public void Plant(MushroomData mushroom)
    {
        if (mushroomGrowing = null)
        {
            if(Inventory.Instance.RemoveMushroom(mushroom,1))
            {
                mushroomGrowing = mushroom;
            }
        }
    }

    public void MushroomGrow()
    {
        if(planted)
        {
            canHarvest = true;
        }
    }
}
