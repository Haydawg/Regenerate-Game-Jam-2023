using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MushroomInfoDisplay : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image mushroomImage;
    [SerializeField] private Image juvenilleImage;
    [SerializeField] private TextMeshProUGUI mushroomType;
    [SerializeField] private TextMeshProUGUI harvestSeasonText;
    [SerializeField] private TextMeshProUGUI inoculateSeasonText;
    [SerializeField] private TextMeshProUGUI mushroomInformation;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnMushrromDisplay += DisplayData;
    }

    public void DisplayData(MushroomData data)
    {
        infoPanel.SetActive(true);
        mushroomImage.sprite = data.image;
        juvenilleImage.sprite = data.juvenileImage;
        mushroomType.text = data.type;
        harvestSeasonText.text = "Harvest Season: " + data.harvestSeason.ToString();
        inoculateSeasonText.text = "Inoculation: " + data.plantingSeason.ToString();
        mushroomInformation.text = data.description;
    }
}
