using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _record;

    private void OnEnable()
    {
        ScoreManager.OnScoreSended += DownloadScore;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreSended -=  DownloadScore;
    }

    private void DownloadScore(int score)
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            _record = PlayerPrefs.GetInt("Record");
        }
        else
        {
            _record = 0;
        }
        if (score > _record) 
        {
            _scoreText.text = "Новый рекорд: " + score;
            PlayerPrefs.SetInt("Record", score);
        }
        else
        {
            _scoreText.text = "Набрано очков: " + score;
        }        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MainGameManager.MainMenuScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
