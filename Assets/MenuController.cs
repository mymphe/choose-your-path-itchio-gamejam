using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("ProductionScene");
    }

    public void LoadHighscoreScreen()
    {
        Debug.Log("Highscore screen loaded.");
        SceneManager.LoadScene("Highscore");
    }

    public void ExitGame()
    {
        Debug.Log("Exit command received");
        Application.Quit();
    }
}
