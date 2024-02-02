using UnityEngine;

public sealed class RestartWindow : MonoBehaviour
{
    [SerializeField] private GameObject _restartWindow;

    private void Start()
    {
        FindObjectOfType<Character>().DiedCharacterEvent += OnDiedCharacterEvent;
    }

    public void OnDiedCharacterEvent(bool value)
    {
        if (value)
            _restartWindow.SetActive(true);
    }

    private void OnDestroy()
    {
        FindObjectOfType<Character>().DiedCharacterEvent -= OnDiedCharacterEvent;
    }
}
