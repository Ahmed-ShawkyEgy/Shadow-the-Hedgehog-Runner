using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0),120*Time.deltaTime);
    }

    public void returnToPool()
    {
        CoinPool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdateTimer(10);
            returnToPool();
        }
    }
}
