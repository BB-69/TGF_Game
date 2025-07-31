public interface IPoolable
{
    void OnReturnToPool();
    void OnSpawn();
}