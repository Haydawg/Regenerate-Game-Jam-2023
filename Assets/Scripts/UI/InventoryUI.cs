using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    [SerializeField] MushroomDisplyUI UIprefab;
    [SerializeField] Inventory inventory;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] List<MushroomDisplyUI> disply = new List<MushroomDisplyUI>();
    

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void UpdateUI()
    {

        foreach (MushroomDisplyUI mushroomDisplyUI in disply)
        {
            Destroy(mushroomDisplyUI.gameObject);           
        }
        disply.Clear();
        if (inventory.mushrooms.Count == 0) return;
        foreach (Mushroom mushroom in inventory.mushrooms)
        {
            MushroomDisplyUI mushroomDisplyUI = Instantiate(UIprefab, inventoryPanel.transform);
            disply.Add(mushroomDisplyUI);
            mushroomDisplyUI.UpdateUI(mushroom);
        }
    }

    public void OpenInventory()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }
}
