using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    private TextMeshProUGUI timeDisplay, distanceDisplay;
    [SerializeField]
    private Player player;
    [SerializeField]
    private SimpleHealthBar powerBar1 , powerBar2;
    [SerializeField]
    private int maxPower;

    private float distanceTravelled , lastPosition;
    private float timer;
    private int currentPower;

    // Start is called before the first frame update
    void Start()
    {
        currentPower = 0;
        distanceTravelled = 0;
        timer = 60;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistanceTravelled();
        UpdateTimer();
        if (timer <= 0)
            EndGame();
    }

    public void EndGame()
    {
        MenueManager.Instance.LaunchGameOverMenue();
    }

    public void UpdatePower(int power)
    {
        
        currentPower += power;
        currentPower = Mathf.Min(currentPower, maxPower);
        powerBar1.UpdateBar(currentPower, maxPower);
        powerBar2.UpdateBar(currentPower, maxPower);
        if (currentPower >= maxPower)
        {
            currentPower = 0;
            powerBar1.UpdateBar(currentPower, maxPower);
            powerBar2.UpdateBar(currentPower, maxPower);
            player.TriggerInvincible();
        }
    }

    public void UpdateTimer(int seconds)
    {
        timer += seconds;
    }

    private void UpdateDistanceTravelled()
    {
        distanceTravelled += player.transform.position.z - lastPosition;
        lastPosition = player.transform.position.z;
        distanceDisplay.text = (distanceTravelled / 10).ToString("F1");
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0);
        timeDisplay.text = timer.ToString("F0");
    }

}
