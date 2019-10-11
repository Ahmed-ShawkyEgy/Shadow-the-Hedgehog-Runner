using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueManager : Singleton<MainMenueManager>
{

    [SerializeField]
    private GameObject startMenue, optionsMenue, creditsMenue, howToMenue;
    [SerializeField]
    private GameObject turnSoundOff, turnSoundOn;


    // Start is called before the first frame update
    void Start()
    {
        DisplayMainMenue();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void DisplayMainMenue()
    {
        disableAllMenues();
        startMenue.SetActive(true);
    }

    public void DisplayOptionsMenue()
    {
        disableAllMenues();
        optionsMenue.SetActive(true);
    }

    public void DisplayCreditsMenue()
    {
        disableAllMenues();
        creditsMenue.SetActive(true);
    }

    public void DisplayHowToMenue()
    {
        disableAllMenues();
        howToMenue.SetActive(true);
    }

    public void TurnSoundOn()
    {
        turnSoundOn.SetActive(false);
        turnSoundOff.SetActive(true);
    }

    public void TurnSoundOff()
    {
        turnSoundOn.SetActive(true);
        turnSoundOff.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void disableAllMenues()
    {
        startMenue.SetActive(false);
        optionsMenue.SetActive(false);
        creditsMenue.SetActive(false);
        howToMenue.SetActive(false);
    }
}
