using TMPro;
using System;
using UnityEngine;

public sealed class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;

    private float _startScore;
    private float _startSpeed;
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
    }

    private void Update()
    {
        IncreasePointMultiplier();
        
        _textScore.text = ConvertScoreToText(_earningPoints + _multiplierScore);
    }

    private void FixedUpdate()
    {
        _earningPoints += _multiplierScore;
    }
}
