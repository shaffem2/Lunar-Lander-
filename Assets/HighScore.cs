using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    TextMeshProUGUI highScoreText;
    public int highScore;


    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();

        if (GameManager.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", GameManager.score);
        }

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore");    // Displays High Score
    }
}
