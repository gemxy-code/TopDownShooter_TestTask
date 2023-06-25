using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;
    private int _record;

    private string _startGameScene = "GameScene";    

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Record"))
        { 
            _record = PlayerPrefs.GetInt("Record");
        }
        else
        {
            _record = 0;
        }            
        _recordText.text += _record;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_startGameScene);
    }
}
