using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Mushroom> mushrooms = new List<Mushroom>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

    public void AddMushroom(MushroomData mushroomData, int amount)
    {
        if(SearchInventory(mushroomData, 1))
        {
            foreach (Mushroom m in mushrooms)
            {
                if (mushroomData.name == m.mushroomData.name)
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
        if(SearchInventory(mushroom,amount))
        {
            foreach (Mushroom m in mushrooms)
            {
                if (mushroom.name == m.mushroomData.name)
                {
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
            Debug.Log(m.mushroomData.name);
            Debug.Log(mushroom.name);
            Debug.Log(m.amount);
            Debug.Log(amount);

            if (m.mushroomData.name == mushroom.name && m.amount >= amount)
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
