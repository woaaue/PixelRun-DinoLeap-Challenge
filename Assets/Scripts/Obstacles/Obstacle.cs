using UnityEngine;
using System.Collections;

public sealed class Obstacle : MonoBehaviour
{
    private float _speed;
    private bool _isLive;
    private Vector2 _position;
    private Coroutine _startCoroutine;

    private void InitializeSpeed()
    {        
        _speed = SpeedSystem.instance.currentSpeed;
    }

    private void Start()
    {
        transform.position = transform.parent.position;
        _position = transform.position;
    }

    private void OnEnable()
    {
        _isLive = true;

        InitializeSpeed();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_startCoroutine == null && _isLive)
        {
            _startCoroutine = StartCoroutine(LiveTimeRoutine());
        }
        else
        {
            if (_startCoroutine != null && !_isLive)
            {
                StopCoroutine(_startCoroutine);

                _startCoroutine = null;

                gameObject.SetActive(false);
            }
        }

    }

    private IEnumerator LiveTimeRoutine()
    {
        yield return new WaitForSecondsRealtime(10f);

        _isLive = false;
    }

    private void OnDisable()
    {
        transform.position = _position;
    }
}
