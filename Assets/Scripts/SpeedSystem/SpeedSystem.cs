using UnityEngine;

public sealed class SpeedSystem : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _accelerationRate;

    public static SpeedSystem instance { get; private set; }

    public float currentSpeed { get; private set; }
    
    private void IncreaseSpeedOverTime()
    {
        currentSpeed += _accelerationRate * Time.deltaTime;
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
        currentSpeed = _minSpeed;
    }

    private void Update()
    {
        IncreaseSpeedOverTime();
    }
}
