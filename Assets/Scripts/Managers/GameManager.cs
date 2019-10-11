﻿using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistanceTravelled();
        UpdateTimer();
    }

    public void EndGame()
    {
        MenueManager.Instance.LaunchGameOverMenue();
    }

    public void UpdatePower(int power)
    {
        
        currentPower += power;
        currentPower = Mathf.Max(currentPower, maxPower);
        powerBar1.UpdateBar(currentPower, maxPower);
        powerBar2.UpdateBar(currentPower, maxPower);

        if(power >= maxPower)
        {
            currentPower = 0;
            powerBar1.UpdateBar(currentPower, maxPower);
            powerBar2.UpdateBar(currentPower, maxPower);
            Debug.Log("Max Power");
            player.TriggerInvinvible();
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
        timeDisplay.text = timer.ToString("F0");
    }

}
