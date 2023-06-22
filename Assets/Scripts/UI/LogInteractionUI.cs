using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LogInteractionUI : MonoBehaviour
{
    public static LogInteractionUI Instance;
    [SerializeField] Button inoculateButton;
    [SerializeField] Button waterButton;
    [SerializeField] Button closeButton;

    [SerializeField] private GameObject interactionPanel;

    [SerializeField] private Transform[] mushroomSpots;
    [SerializeField] private Image wateredImage;
    [SerializeField] private Image logImage;

    [SerializeField] InWorldMushroom mushroomHarvestPrefab;
    public HarvestableLog log;
    public bool planting;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        EventManager.Instance.onLogInteraction += LogInteraction;
    }

    private void OnEnable()
    {
        waterButton.onClick.AddListener(WaterLog);
        inoculateButton.onClick.AddListener(InoculateLog);
    }
    private void OnDisable()
    {
        waterButton.onClick.RemoveListener(WaterLog);
        EventManager.Instance.onLogInteraction -= LogInteraction;
    }
    public void closeUI()
    {
        StartCoroutine(CloseInteractionScreen());
    }

    public void LogInteraction(HarvestableLog harvestableLog)
    {

        interactionPanel.SetActive(true);

        log = harvestableLog;
        logImage.sprite = log.GetComponent<SpriteRenderer>().sprite;
        if(log.planted)
        {
            for(int i = 0; i < log.mushroomCount; i++)
            {
                foreach (Transform child in mushroomSpots[i]) 
                {
                    Destroy(child.gameObject);
                }
                InWorldMushroom inWorldMushroom = Instantiate(mushroomHarvestPrefab, mushroomSpots[i]);
                inWorldMushroom.Init(log.mushroomGrowing, log.canHarvest);
                
            }
        }
        if (log.isWatered)
        {
            wateredImage.fillAmount = 0.9f;
        }
        else
        {
            wateredImage.fillAmount = 0.1f;
        }
    }

    public void UpdateAllUI()
    {
        if (log.planted)
        {
            for (int i = 0; i < log.mushroomCount; i++)
            {
                foreach (Transform child in mushroomSpots[i])
                {
                    Destroy(child.gameObject);
                }
                InWorldMushroom inWorldMushroom = Instantiate(mushroomHarvestPrefab, mushroomSpots[i]);
                inWorldMushroom.Init(log.mushroomGrowing, log.canHarvest);

            }
        }
        if (log.isWatered)
        {
            wateredImage.fillAmount = 0.9f;
        }
        else
        {
            wateredImage.fillAmount = 0.1f;
        }
    }

    public void WaterLog()
    {
        if(log)
        {
            log.isWatered = true;
            wateredImage.fillAmount = 0.9f;
        }
    }

    public void InoculateLog()
    {
        planting = true;
        Inventory.Instance.gameObject.SetActive(true);
    }
    IEnumerator CloseInteractionScreen()
    {
        FadeToBlack.Instance.StartFade(1);
        yield return new WaitForSeconds(1);
        interactionPanel.SetActive(false);
    }
}
