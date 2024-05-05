using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject gameOverScreen;
    //[SerializeField] private Text scoreText; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        DisablePlayerControls();
        ShowGameOverScreen();
    }

    private void DisablePlayerControls()
    {
        // Assuming Rocket has a script that controls movement which we disable
        rocket.GetComponent<Rocket>().enabled = false;
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        //scoreText.text = "Score: " + CalculateScore();
    }

    //private int CalculateScore()
    //{
    //    // Implement score calculation logic
    //}
}
