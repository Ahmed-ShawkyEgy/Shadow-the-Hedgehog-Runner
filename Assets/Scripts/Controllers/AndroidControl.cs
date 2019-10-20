using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidControl : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Player _player;
    private Vector2 startTouchPosition, endTouchPosition;

    void Start()
    {
        _player = player.GetComponent<Player>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (( startTouchPosition.x - endTouchPosition.x > 30))
                _player.MoveLeft();

            if ((endTouchPosition.x - startTouchPosition.x > 30))
                _player.moveRight();
        }
    }
}
