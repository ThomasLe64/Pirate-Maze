using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject PauseButton;

    void Start()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void onPauseClick()
    {
        PauseMenu();
        PauseButton.SetActive(false);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
