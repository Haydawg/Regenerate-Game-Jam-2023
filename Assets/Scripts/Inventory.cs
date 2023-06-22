using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public MushroomData[] data;
    public static Inventory Instance;
    public List<Mushroom> mushrooms = new List<Mushroom>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (MushroomData mushroomData in data)
        {
            AddMushroom(mushroomData, 1);
        }
    }

    public void AddMushroom(MushroomData mushroomData, int amount)
    {
        if(SearchInventory(mushroomData, 1))
        {
            foreach (Mushroom m in mushrooms)
            {
                if (mushroomData.type == m.mushroomData.type)
                {
                    m.amount += amount;
                    inventoryUI.UpdateUI();
                }
            }
        }
        else
        {
            Mushroom newMushroom = new Mushroom(mushroomData, amount);

            mushrooms.Add(newMushroom);
            inventoryUI.UpdateUI();
        }
    }

    public bool RemoveMushroom(MushroomData mushroom, int amount)
    {
        Debug.Log("0");
        if (SearchInventory(mushroom,amount))
        {
            foreach (Mushroom m in mushrooms)
            {
                Debug.Log("1");

                if (mushroom.type == m.mushroomData.type)
                {
                    Debug.Log("2");
                    m.amount -= amount;
                    inventoryUI.UpdateUI();
                    return true;
                }
            }
        }
        return false;
    }
    bool SearchInventory(MushroomData mushroom, int amount = 1)
    {
        Debug.Log(mushrooms.Count);
        
        foreach (Mushroom m in mushrooms)
        {
            if (m.mushroomData.type == mushroom.type && m.amount >= amount)
            {
                Debug.Log(true);
                return true;
            }
        }
        return false;
    }

    public void AddTestMushroom(MushroomData test)
    {
        AddMushroom(test, 1);
    }
}
