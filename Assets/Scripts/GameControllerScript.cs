using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;

    public Button StartButton;
    public Text ScoreText;
    public GameObject Menu;

    private bool _isStarted = false;
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        Instance = this;
        StartButton.onClick.AddListener(
            () =>
            {
                Menu.SetActive(false);
                _isStarted = true;
            });
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public bool IsStarted()
    {
        return _isStarted;
    }

    public void StartGame()
    {
        _isStarted = true;
    }
}
