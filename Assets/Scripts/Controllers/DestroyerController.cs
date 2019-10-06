using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
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
            PlatformManager.Instance.DestroyPlatform(other.gameObject);
        }
    }
}
