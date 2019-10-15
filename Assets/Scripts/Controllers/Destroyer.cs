using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;
    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = _camera.position.z;
        transform.position = pos;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            other.gameObject.GetComponent<Platform>().returnToPool();
            Spawner.Instance.OnPlatformDestroyed();
        }
        else if(other.gameObject.tag == "Coin")
        {
            other.gameObject.GetComponent<Coin>().returnToPool();
        }
        else if(other.gameObject.tag == "Blue Sphere")
        {
            other.gameObject.GetComponent<BlueSphere>().returnToPool();
        }
        else if(other.gameObject.tag == "Bomb")
        {
            other.gameObject.GetComponent<Bomb>().returnToPool();
        }
        else if(other.gameObject.tag == "Iron Ball")
        {
            other.gameObject.GetComponent<IronBall>().returnToPool();
        }
    }
}
