using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToPool()
    {
        BlueSpherePool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdatePower(1);
            AudioManager.Instance.Play("PowerUpPickUp");
            returnToPool();
        }
    }
}
