using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _record;
    private string _mainMenuScene = "MainMenu";
    
    

    private void OpenMenuWindow(int score)
    {
        gameObject.SetActive(true);
        if (PlayerPrefs.HasKey("Record"))
        {
            _record = PlayerPrefs.GetInt("Record");
        }
        else
        {
            _record = 0;
        }
        if (score >  _record) 
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
        SceneManager.LoadScene(_mainMenuScene);
    }

    public void ReloadScene()
    {
        gameObject.SetActive(false);
        //...
    }

}
