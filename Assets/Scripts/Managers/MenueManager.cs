using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueManager : Singleton<MenueManager>
{

    [SerializeField]
    private GameObject pauseMenueUI, gameOverMenue;

    private bool isPaused , isGameOver;

    void Update()
    {
        if(!isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LaunchGameOverMenue()
    {
        gameOverMenue.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenueUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenueUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Retry()
    {
        Resume();
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenue()
    {

    }

    public bool isGamePaused()
    {
        return isPaused;
    }
}
