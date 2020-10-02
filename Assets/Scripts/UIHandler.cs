using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI = null;
    [SerializeField] private TextMeshProUGUI highScoreText = null;
    [SerializeField] private GameObject gamePlayUI = null;
    [SerializeField] private TextMeshProUGUI gameScoreDisplayText = null;
    internal static UIHandler instance = null;
    internal bool gameStarted = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        highScoreText.SetText("Best Score: " + PlayerPrefs.GetInt("Highscore").ToString());
    }

    public void StartGameButton()
    {
        gameStarted = true;
    }

    public void RetryButtton()
    {
        SceneManager.LoadScene(0);
    }

    internal void GameOver()
    {
        gameOverUI.SetActive(true);
        gamePlayUI.SetActive(false);
        gameScoreDisplayText.SetText("Score: " + LevelManager.instance.gameScore.ToString());
    }
}
