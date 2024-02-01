using UnityEngine;

public sealed class SpeedSystem : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerationRate;
    [SerializeField] private float _testSpeed;

    public static SpeedSystem instance { get; private set; }
    public float currentSpeed { get; private set; }
    
    private float _speed;

    private void IncreaseSpeedOverTime()
    {
        _speed += _accelerationRate * Time.deltaTime;

        currentSpeed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(this);
    }

    private void Start()
    {
        _speed = _minSpeed;
    }

    private void Update()
    {
        IncreaseSpeedOverTime();

        _testSpeed = currentSpeed;
    }
}
