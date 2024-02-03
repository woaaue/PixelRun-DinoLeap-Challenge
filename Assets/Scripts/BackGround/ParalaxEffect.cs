using UnityEngine;

public sealed class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject _endPoint;
    [SerializeField] private GameObject _startPoint;

    private void Update()
    {
        if (transform.position.x <= _endPoint.transform.position.x)
            transform.position = _startPoint.transform.position;

        transform.Translate(new Vector2(-SpeedSystem.instance.currentSpeed * Time.deltaTime, transform.position.y), Space.World);
    }
}
