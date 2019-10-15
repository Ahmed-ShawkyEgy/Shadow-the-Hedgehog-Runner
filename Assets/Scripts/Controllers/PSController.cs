using UnityEngine;

public class PSController : MonoBehaviour
{
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps.isStopped)
            Destroy(this.gameObject);
    }
}
