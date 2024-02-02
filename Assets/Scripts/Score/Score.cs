using TMPro;
using System;
using UnityEngine;

public sealed class Score : MonoBehaviour
{
    [SerializeField] private Character _eventCharacter;
    [SerializeField] private TextMeshProUGUI _textScore;

    private float _startScore;
    private float _startSpeed;
    private bool _stopScoring;
    private float _earningPoints;
    private float _multiplierScore;


    private string ConvertScoreToText(float score)
    {
        return Convert.ToString((int)score);
    }

    private float ConvertTextToScore(string text)
    {
        return float.Parse(text);
    }

    private void OnDiedCharacterEvent(bool value)
    {
        _stopScoring = value;
    }

    private void IncreasePointMultiplier()
    {
        if (SpeedSystem.instance.currentSpeed - _startSpeed >= 1)
        {
            _multiplierScore += .02f;
            _startSpeed = SpeedSystem.instance.currentSpeed;
        }
    }

    private void Start()
    {
        _startScore = 1f;
        _multiplierScore = .02f;
        _earningPoints = _startScore;
        _startSpeed = SpeedSystem.instance.currentSpeed;
        _textScore.text = ConvertScoreToText(_startScore);
        FindObjectOfType<Character>().DiedCharacterEvent += OnDiedCharacterEvent;
    }

    private void Update()
    {
        IncreasePointMultiplier();
        
        _textScore.text = ConvertScoreToText(_earningPoints + _multiplierScore);
    }

    private void FixedUpdate()
    {
        if (!_stopScoring)
            _earningPoints += _multiplierScore;
    }
}
