using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed,
                  _horizontalSpeed,
                  _jump,
                  _gravitationalModifier  ;

    [SerializeField]
    private Camera _firstPersonCamera, _thirdPersonCamera;

    private Vector3 _normalSpeed, _highSpeed;
    private bool _isGrounded, _isInvinvible;
    private int _activeCamera;
    private Rigidbody rb;
    private Lanes targetLane;
    private Animator animator;
    private IEnumerator invincibleCoRoutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

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
        if (_isGrounded)
        {
            //rb.velocity = (isInvinvible) ? _highSpeed : _normalSpeed;
        }
        else
        {
            Vector3 velocity = rb.velocity;
            velocity.y -= _gravitationalModifier * Time.deltaTime;
            rb.velocity = velocity;
        }
        //Debug.Log(rb.velocity);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * ((_isInvinvible) ? _speed*2:_speed) * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
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

    public void TriggerInvinvible()
    {
        if (invincibleCoRoutine == null)
        {
            _isInvinvible = true;
            animator.SetTrigger("isInvincible");
            invincibleCoRoutine = stopInvincible();
            StartCoroutine(invincibleCoRoutine);
        }
        else
        {
            StopCoroutine(invincibleCoRoutine);
            invincibleCoRoutine = stopInvincible();
            StartCoroutine(invincibleCoRoutine);
        }
    }

    private IEnumerator stopInvincible()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("stopInvinvible");
        _isInvinvible = false;
        invincibleCoRoutine = null;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && _isGrounded == false)
        {
            _isGrounded = true;
            rb.constraints |= RigidbodyConstraints.FreezePositionY;
            rb.velocity = _normalSpeed;
            transform.Translate(0, 0.1f, 0);
            //animator.SetTrigger("isFall");
        }
    }


    public void jump()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.AddForce(Vector3.up * _jump, ForceMode.VelocityChange);
        _isGrounded = false;
        animator.SetTrigger("isJump");
    }

    public bool isInvincible()
    {
        return _isInvinvible;
    }
}
