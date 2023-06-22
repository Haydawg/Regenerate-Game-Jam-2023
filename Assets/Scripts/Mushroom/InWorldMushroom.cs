using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InWorldMushroom : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler ,IPointerDownHandler
{
    [SerializeField] MushroomData data;
    bool readyToHarvest;

    [SerializeField] Material outlineMat;
    Material originalMat;
    [SerializeField] private SimpleToolTipText tooltip;

    private void Start()
    {
        originalMat = GetComponent<Image>().material;
    }

    public void Init(MushroomData data, bool readyToHarvest)
    {
        this.data = data;
        this.readyToHarvest = readyToHarvest;
        if (readyToHarvest)
        {
            GetComponent<Image>().sprite = data.image;
            tooltip.tooltip = "Click to harvest";
        }
        else
        {
            GetComponent<Image>().sprite = data.juvenileImage;
            tooltip.tooltip = "Juvenile Mushroom";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().material = outlineMat;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().material = originalMat;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (readyToHarvest)
        {
            Inventory.Instance.AddMushroom(data, 1);
            readyToHarvest = false;
            LogInteractionUI.Instance.log.canHarvest = false;
            GetComponent<Image>().sprite = data.juvenileImage;
            tooltip.tooltip = "Juvenile Mushroom";
        }
    }
}
