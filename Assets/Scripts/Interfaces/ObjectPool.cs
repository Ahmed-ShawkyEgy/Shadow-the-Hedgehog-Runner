using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : Singleton<ObjectPool<T>> where T : Component
{
    [SerializeField]
    private T prefab;
    private Queue<T> queue = new Queue<T>();

    public T GetObject()
    {
        if (queue.Count == 0)
            Add();
        return queue.Dequeue();
    }

    public void ReturnToPool(T obj)
    {
        if(obj.gameObject.activeSelf)
        {
            obj.gameObject.SetActive(false);
            queue.Enqueue(obj);
        }
    }

    private void Add()
    {
        T obj = GameObject.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        queue.Enqueue(obj);
    }
}
