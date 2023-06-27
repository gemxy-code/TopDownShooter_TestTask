using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Awake()
    {
        _score = 0;
    }
    private void OnEnable()
    {
        EventBus.OnEnemyDied += TakeScore;
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDied -= TakeScore;
    }

    private void TakeScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }
}
