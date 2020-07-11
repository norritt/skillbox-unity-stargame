using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;

    public Text ScoreText;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        Instance = this;
    }

    // Update is called once per frame
    internal void IncreaseScore(int increment)
    {
        _score += increment;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $"Score: {_score}";
    }

    internal void CloseGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
