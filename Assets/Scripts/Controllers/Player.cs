using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed,
                  _horizontalSpeed,
                  _jump;

    [SerializeField]
    private Camera _firstPersonCamera, _thirdPersonCamera;

    private Vector3 _normalSpeed, _highSpeed;
    private bool isGrounded;
    private int _activeCamera;
    private Rigidbody rb;
    private Lanes targetLane;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetLane = Lanes.MiddleLane;

        _firstPersonCamera.enabled = false;
        _thirdPersonCamera.enabled = true;
        _activeCamera = 0;

        _normalSpeed = new Vector3(0, 0, _speed);
        _highSpeed = new Vector3(0, 0, _speed * 2);

        rb.velocity = _normalSpeed;
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            rb.velocity = _normalSpeed;
        }
        Debug.Log(rb.velocity.magnitude);
    }

    private void Update()
    {
        handleControls();
        moveToTargetLane();

    }

    private void moveToTargetLane()
    {
        Vector3 currentPos = transform.position, targetPos = currentPos;
        if(targetLane == Lanes.LeftLane)
        {
            targetPos.x = -3;
        }
        else if(targetLane == Lanes.MiddleLane)
        {
            targetPos.x = 0;
        }
        else if(targetLane == Lanes.RightLane)
        {
            targetPos.x = 3;
        }
        transform.position = Vector3.MoveTowards(currentPos,targetPos, _horizontalSpeed * Time.deltaTime);
    }

    private void handleControls()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (targetLane == Lanes.MiddleLane)
                targetLane = Lanes.LeftLane;
            else if (targetLane == Lanes.RightLane)
                targetLane = Lanes.MiddleLane;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (targetLane == Lanes.MiddleLane)
                targetLane = Lanes.RightLane;
            else if (targetLane == Lanes.LeftLane)
                targetLane = Lanes.MiddleLane;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            _thirdPersonCamera.enabled = false;
            _firstPersonCamera.enabled = false;
            if (_activeCamera == 0)
            {
                _firstPersonCamera.enabled = true;
            }
            else
            {
                _thirdPersonCamera.enabled = true;
            }
            _activeCamera = 1 - _activeCamera;
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            rb.constraints |= RigidbodyConstraints.FreezePositionY;
            rb.velocity = _normalSpeed;
        }
    }


    public void jump()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.AddForce(new Vector3(0, _jump, 0), ForceMode.VelocityChange);
        isGrounded = false;
    }
}
