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
        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("MainMenue");

    }

    public void StartGame()
    {
        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("GamePlay");
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

        turnSoundOff.SetActive(false);
        turnSoundOn.SetActive(false);
        if (AudioManager.Instance.isSoundEnabled())
            turnSoundOff.SetActive(true);
        else
            turnSoundOn.SetActive(true);
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
        AudioManager.Instance.setSoundEnabled(true);
        AudioManager.Instance.Play("MainMenue");
    }

    public void TurnSoundOff()
    {
        turnSoundOn.SetActive(true);
        turnSoundOff.SetActive(false);
        AudioManager.Instance.setSoundEnabled(false);
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
