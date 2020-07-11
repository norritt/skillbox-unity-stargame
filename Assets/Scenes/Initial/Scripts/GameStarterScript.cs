using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
