using UnityEngine;


public class PooledObject : MonoBehaviour
{
    [System.NonSerialized]
    ObjectPool poolInstanceForPrefab;

    public ObjectPool Pool { get; set; }

    public T GetPooledInstance<T>() where T : PooledObject
    {
        if (!poolInstanceForPrefab)
        {
            poolInstanceForPrefab = ObjectPool.GetPool(this);
        }
        return (T)poolInstanceForPrefab.GetObject();
    }

    public void ReturnToPool()
    {
        if (Pool)
        {
            Pool.AddObject(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}