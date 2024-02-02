using UnityEngine;
using System.Collections;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private ObstaclePool _obstacle;

    private bool _stopGame;
    private Coroutine _startCoroutine;

    private void GetSpawnObstacle()
    {
        var obstacle = _obstacle?.GetObstacle();

        if (obstacle == null)
            return;
    }

    private void OnDiedCharacterEvent(bool value)
    {
        _stopGame = value;
    }

    private void Start()
    {
        if (_startCoroutine == null)
        {
            _startCoroutine = StartCoroutine(SpawnObstacleRoutine());
        }

        FindObjectOfType<Character>().DiedCharacterEvent += OnDiedCharacterEvent;
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        while(!_stopGame)
        {
            yield return new WaitForSecondsRealtime(_spawnInterval);

            GetSpawnObstacle();
        }

        yield break;
    }

    private void OnDestroy()
    {
        StopCoroutine(_startCoroutine);
    }
}
