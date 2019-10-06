using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed,
                  _jump;

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, _speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            rb.constraints |= RigidbodyConstraints.FreezePositionY; 
        }
    }


    public void jump()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.AddForce(new Vector3(0, _jump, 0), ForceMode.VelocityChange);
        isGrounded = false;
    }
}
