using UnityEngine;
using System.Collections;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private ObstaclePool _obstacle;

    private Coroutine _startCoroutine;

    private void GetSpawnObstacle()
    {
        var obstacle = _obstacle?.GetObstacle();

        if (obstacle == null)
            return;
    }

    private void Start()
    {
        if (_startCoroutine == null)
        {
            _startCoroutine = StartCoroutine(SpawnObstacleRoutine());
        }
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(_spawnInterval);

            GetSpawnObstacle();
        }

        yield break;
    }
}
