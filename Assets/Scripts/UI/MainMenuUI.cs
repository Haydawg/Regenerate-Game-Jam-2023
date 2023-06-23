using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;

    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject settingsPanel;
    // Start is called before the first frame update

    private void OnEnable()
    {
        startButton.onClick.AddListener(delegate { EventManager.Instance.onLoadScene?.Invoke(1); });
        quitButton.onClick.AddListener(delegate { EventManager.Instance.Quit?.Invoke(); });
        controlsButton.onClick.AddListener(delegate { controlsPanel.SetActive(true); });
        settingsButton.onClick.AddListener(delegate { settingsPanel.SetActive(true); });
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(delegate { EventManager.Instance.onLoadScene?.Invoke(1); });
        quitButton.onClick.RemoveListener(delegate { EventManager.Instance.Quit.Invoke(); });
        controlsButton.onClick.RemoveListener(delegate { controlsPanel.SetActive(true); });
        settingsButton.onClick.RemoveListener(delegate { settingsPanel.SetActive(true); });
    }
}
