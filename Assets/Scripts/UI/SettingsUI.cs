using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] SettingsMenu settingsManager;
    [SerializeField] private Scrollbar mainAudioScrollbar;
    [SerializeField] private TextMeshProUGUI mainAudioVolume;
    [SerializeField] private Button closeSettings;

    private void Awake()
    {

        closeSettings.onClick.AddListener(Hide);
        mainAudioScrollbar.onValueChanged.AddListener(delegate
        {
            settingsManager.SetMainAudioVolume(mainAudioScrollbar.value);
            mainAudioVolume.text = (mainAudioScrollbar.value * 100).ToString().Split(".")[0];
        });
    }

    private void Start()
    {
        EventManager.Instance.ShowSettins.AddListener(delegate { Show(); });
        InitUI();
        gameObject.SetActive(false);
    }

    public void InitUI()
    {
        mainAudioVolume.text = (settingsManager.GetMainAudioVolume() * 100).ToString().Split(".")[0];
        mainAudioScrollbar.SetValueWithoutNotify(settingsManager.GetMainAudioVolume());
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}


