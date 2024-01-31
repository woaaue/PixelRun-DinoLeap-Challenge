using UnityEngine;

public sealed class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private IJumpable _jumpable;

    private void Start()
    {
        _jumpable = _object.GetComponent<IJumpable>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
        {
            _jumpable.Jump();
        }
    }
}
