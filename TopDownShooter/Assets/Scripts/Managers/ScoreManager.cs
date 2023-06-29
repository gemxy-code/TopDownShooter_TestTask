using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public static event Action <int> OnScoreSended;

    private int _score;

    private void Awake()
    {
        _score = 0;
    }
    private void OnEnable()
    {
        EventBus.OnEnemyDied += TakeScore;
        EventBus.OnGameOver += SendScore;
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDied -= TakeScore;
        EventBus.OnGameOver -= SendScore;
    }

    private void TakeScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }

    private void SendScore() => OnScoreSended?.Invoke(_score);
}
