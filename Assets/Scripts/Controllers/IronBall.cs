using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBall : MonoBehaviour
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
        IronBallPool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdateTimer(-2);
            returnToPool();
        }
    }
}
