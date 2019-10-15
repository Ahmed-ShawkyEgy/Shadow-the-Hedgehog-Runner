using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _particleSystem;

    private void PlayEffect()
    {
        GameObject obj = Instantiate(_particleSystem);
        obj.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayEffect();
        }
    }
}