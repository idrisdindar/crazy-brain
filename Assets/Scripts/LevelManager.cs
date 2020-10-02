using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private float scoreCoolDownTime = 0f;
    internal static LevelManager instance = null;


    internal int gameScore = 0;
    private float tempTime = 0f;
    internal bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject  );
        }

        tempTime = scoreCoolDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && UIHandler.instance.gameStarted)
        {
            if(tempTime <= 0)
            {
                tempTime = scoreCoolDownTime;
                gameScore++;
                scoreText.SetText("Score: " +gameScore.ToString());
            }
            else
            {
                tempTime -= Time.deltaTime;
            }
        }
        else
        {
            if (gameScore > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", gameScore);
            }

        }
    }
}
