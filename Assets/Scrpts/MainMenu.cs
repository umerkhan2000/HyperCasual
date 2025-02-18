using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button levelSelectButton;
    public Button quitButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        levelSelectButton.onClick.AddListener(OpenLevelSelect);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        int lastLevel = PlayerPrefs.GetInt("LastLevel", 1);
        SceneManager.LoadScene("SampleScene");
    }

    void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}