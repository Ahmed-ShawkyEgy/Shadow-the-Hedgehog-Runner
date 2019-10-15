using UnityEngine;

public class Platform : MonoBehaviour
{
    public void returnToPool()
    {
        PlatformPool.Instance.ReturnToPool(this);
    }
}
