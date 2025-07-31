using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private Dictionary<GameObject, GameObjectPool> prefabToPool = new();
    private Dictionary<GameObject, GameObjectPool> instanceToPool = new();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Register(GameObject prefab, int preload = 20)
    {
        if (!prefabToPool.ContainsKey(prefab))
        {
            GameObjectPool pool = new GameObjectPool(prefab, preload, this.transform);
            prefabToPool[prefab] = pool; //map prefab to the pool
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        if (!prefabToPool.ContainsKey(prefab))
            Register(prefab);

        GameObject obj = prefabToPool[prefab].Get();
        instanceToPool[obj] = prefabToPool[prefab];
        return obj;
    }

    public void Despawn(GameObject obj)
    {
        if (instanceToPool.TryGetValue(obj, out var pool))
        {
            pool.Release(obj);
        }
        else
        {
            Debug.LogWarning("Trying to return unknown object to pool.");
            Destroy(obj);
        }
    }
}
