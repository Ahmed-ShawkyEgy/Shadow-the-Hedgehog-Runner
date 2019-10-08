using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI timeDisplay, distanceDisplay;
    [SerializeField]
    private GameObject ball;

    private float distanceTravelled , lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        distanceTravelled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += ball.transform.position.z - lastPosition;
        lastPosition = ball.transform.position.z;
        distanceDisplay.text = (distanceTravelled/10).ToString("F1");
    }
}
