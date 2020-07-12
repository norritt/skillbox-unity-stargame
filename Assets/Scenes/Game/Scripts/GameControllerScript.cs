using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;

    public Text ScoreText;
    public Button AgainButton;
    public Button MenuButton;
    public GameObject MenuScreen;

    private int _score = 0;

    void Start()
    {
        _score = 0;
        MenuScreen.SetActive(false);
        Instance = this;
        MenuButton.onClick.AddListener(CloseGame);
        AgainButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    internal void IncreaseScore(int increment)
    {
        _score += increment;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $"Score: {_score}";
    }

    internal void OpenMenu()
    {
        MenuScreen.SetActive(true);
    }

    private void CloseGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
