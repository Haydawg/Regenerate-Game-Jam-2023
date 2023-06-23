using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        EventManager.Instance.onLoadScene += LoadScene;
        EventManager.Instance.Quit.AddListener(Quit);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.Instance.PauseGame?.Invoke();
        }
    }
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
