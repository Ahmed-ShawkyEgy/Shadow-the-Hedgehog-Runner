using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{
    public void returnToPool()
    {
        BlueSpherePool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdatePower(10);
            AudioManager.Instance.Play("PowerUpPickUp");
            returnToPool();
        }
    }
}
