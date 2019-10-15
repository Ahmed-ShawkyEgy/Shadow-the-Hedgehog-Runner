using UnityEngine;

public class IronBall : MonoBehaviour
{
    public void returnToPool()
    {
        IronBallPool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdateTimer(-10);
            AudioManager.Instance.Play("Buzzer");
            returnToPool();
        }
    }
}
