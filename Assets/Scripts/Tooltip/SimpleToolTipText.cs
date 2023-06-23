using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SimpleToolTipText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tooltip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverTootip.Instance.ShowToolTip(tooltip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        HoverTootip.Instance.HideToolTip();
    }
}
