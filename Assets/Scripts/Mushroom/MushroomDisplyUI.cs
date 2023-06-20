using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MushroomDisplyUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Mushroom mushroom;
    [SerializeField] Image background;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color highlightColor;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI season;
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
        name.text = mushroom.mushroomData.name;
        season.text = mushroom.mushroomData.plantingSeason.ToString();
        number.text = mushroom.amount.ToString();
    }
    
    
    // Update is called once per frame
    private void OnMouseOver()
    {
        background.color = highlightColor;
        Debug.Log("Hover");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = highlightColor;
        HoverTootip.Instance.ShowToolTip(mushroom.mushroomData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = backgroundColor;
        HoverTootip.Instance.HideToolTip();
    }
}
