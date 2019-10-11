using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : Singleton<PauseMenue>
{

    [SerializeField]
    private GameObject pauseMenueUI;

    private bool isPaused;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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

    public bool isGamePaused()
    {
        return isPaused;
    }
}
