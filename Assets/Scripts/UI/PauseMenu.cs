using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public Button returnButton;
    [SerializeField] public Button quitButton;
    [SerializeField] public Button restartSceneButton;
    [SerializeField] public Button settingsButton;

    private void OnEnable()
    {
        settingsButton.onClick.AddListener(delegate { EventManager.Instance.ShowSettins?.Invoke(); });
        quitButton.onClick.AddListener(delegate { EventManager.Instance.Quit?.Invoke(); });
        restartSceneButton.onClick.AddListener(delegate { EventManager.Instance.onLoadScene?.Invoke(1); });
        returnButton.onClick.AddListener(UnPauseGame);
    }

    private void OnDisable()
    {
        quitButton.onClick.RemoveListener(delegate { EventManager.Instance.Quit?.Invoke(); });
        restartSceneButton.onClick.RemoveListener(delegate { EventManager.Instance.onLoadScene?.Invoke(1); });
        returnButton.onClick.AddListener(UnPauseGame);

    }

    public void Start()
    {
        EventManager.Instance.PauseGame.AddListener(PauseGame);
        gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
