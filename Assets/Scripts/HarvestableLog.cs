using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HarvestableLog : MonoBehaviour
{
    public MushroomData mushroomGrowing;
    public int mushroomCount;
    public bool canHarvest;
    public bool planted;
    public bool isWatered;
    // Start is called before the first frame update
    void Start()
    {
        SeasonManager.Instance.OnChangeSeason += MushroomGrow;

    }

    private void OnDisable()
    {
        SeasonManager.Instance.OnChangeSeason -= MushroomGrow;

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
        Debug.Log("Log");
        if (mushroomGrowing == null)
        {
            if(Inventory.Instance.RemoveMushroom(mushroom,1))
            {
                mushroomGrowing = mushroom;
                planted = true;
            }
        }
        
    }

    public void MushroomGrow(Season season)
    {
        if(planted)
        {
            if(mushroomGrowing != null)
            {
                if(isWatered && mushroomGrowing.harvestSeason == season)
                {
                    canHarvest = true;
                }
            }
        }

        DrainWater();
    }

    public void DrainWater()
    {
        isWatered= false;
    }

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            HoverTootip.Instance.ShowToolTip("Check Log");
        }
    }
    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            HoverTootip.Instance.HideToolTip();
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            FadeToBlack.Instance.StartFade(2);
            StartCoroutine(MoveToInteractionScreen(1));
        }
    }

    IEnumerator MoveToInteractionScreen(int time)
    {
        yield return new WaitForSeconds(time);
        EventManager.Instance.onLogInteraction?.Invoke(this);
    }
}
