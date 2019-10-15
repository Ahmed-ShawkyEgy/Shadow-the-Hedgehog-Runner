using UnityEngine;

public class Bomb : MonoBehaviour
{
    public void returnToPool()
    {
        BombPool.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            returnToPool();
            AudioManager.Instance.Play("Explosion");
            if(!other.gameObject.GetComponent<Player>().isInvincible())
                GameManager.Instance.EndGame();
        }
    }
}
