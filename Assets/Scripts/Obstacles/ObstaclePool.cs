using UnityEngine;

public sealed class ObstaclePool : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private Obstacle _prefab;

    private PoolObject<Obstacle> _pool;

    private void Awake()
    {
        _pool = new PoolObject<Obstacle>(_prefab, _poolCount, transform);
    }

    public Obstacle GetObstacle()
    {
        return _pool?.GetFreeElement();
    }
}
