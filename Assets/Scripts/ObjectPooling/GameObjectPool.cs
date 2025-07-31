using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool : MonoBehaviour
{
    private readonly GameObject prefab;
    private readonly Queue<GameObject> pool = new();
    private readonly Transform parent;

    public GameObjectPool(GameObject prefab, int preload = 0, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < preload; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        GameObject obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(prefab, parent);
        if (obj.TryGetComponent<IPoolable>(out IPoolable component)) component.OnSpawn();
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        if (obj.TryGetComponent<IPoolable>(out IPoolable component)) component.OnReturnToPool();
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
