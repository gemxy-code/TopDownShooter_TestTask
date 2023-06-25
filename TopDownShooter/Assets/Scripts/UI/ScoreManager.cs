using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    private void TakeScore(int score)
    {
        _score += score;
    }
}
