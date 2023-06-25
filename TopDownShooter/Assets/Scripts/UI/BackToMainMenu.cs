using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    private string _mainMenuScene = "MainMenu";

    public void Back()
    {
        SceneManager.LoadScene(_mainMenuScene);
    }
}
