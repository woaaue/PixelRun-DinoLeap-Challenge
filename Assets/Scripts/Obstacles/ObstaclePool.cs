using System.Collections.Generic;
using UnityEngine;

public sealed class ObstaclePool : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private Obstacle _firstPrefab;
    [SerializeField] private Obstacle _secondPrefab;
    [SerializeField] private Obstacle _thirdPrefab;

    private PoolObject<Obstacle> _firstPool;
    private PoolObject<Obstacle> _secondPool;
    private PoolObject<Obstacle> _thirdPool;
    private List<PoolObject<Obstacle>> _obstaclesPools;

    private void Awake()
    {
        _firstPool = new PoolObject<Obstacle>(_firstPrefab, _poolCount, transform);
        _secondPool = new PoolObject<Obstacle>(_secondPrefab, _poolCount, transform);
        _thirdPool = new PoolObject<Obstacle>(_thirdPrefab, _poolCount, transform);
        _obstaclesPools = new List<PoolObject<Obstacle>>();
        _obstaclesPools.Add(_firstPool);
        _obstaclesPools.Add(_secondPool);
        _obstaclesPools.Add(_thirdPool);
    }

    public Obstacle GetObstacle()
    {
        return _obstaclesPools[Random.Range(0,3)]?.GetFreeElement();
    }
}
