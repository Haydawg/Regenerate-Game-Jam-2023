using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MushroomDisplyUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Mushroom mushroom;
    [SerializeField] Image background;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color highlightColor;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI type;
    [SerializeField] TextMeshProUGUI number;

    // Start is called before the first frame update
    void Start()
    {
        background.color = backgroundColor;
        if(mushroom != null)
        {
            UpdateUI(mushroom);
        }
    }

    public void UpdateUI(Mushroom mushroom)
    {
        this.mushroom = mushroom;
        image.sprite = mushroom.mushroomData.image;
        type.text = mushroom.mushroomData.type;
        number.text = mushroom.amount.ToString();
    }
    
    
    // Update is called once per frame
    private void OnMouseOver()
    {
        background.color = highlightColor;
        Debug.Log("Hover");
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(LogInteractionUI.Instance.planting)
        {
            Debug.Log("ui");
            LogInteractionUI.Instance.log.Plant(mushroom.mushroomData);
            InventoryUI.Instance.gameObject.SetActive(false);
            LogInteractionUI.Instance.planting = false;
        }
        else
        {
            EventManager.Instance.OnMushrromDisplay?.Invoke(mushroom.mushroomData);
        }
    }
}
