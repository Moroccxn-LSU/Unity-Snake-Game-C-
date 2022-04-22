//  C# Snake Game
//  By: Adam Elkhanoufi
//  04/21/2022
//
//  Script for the Scoring mechanics

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem location;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        location = this;
    }

    private void Start()
    {
        scoreText.text = "Score\n" + score.ToString();
    }

    public void addPoint()
    {
        score += 1;
        scoreText.text = "Score\n" + score.ToString();
    }

    public void resetPoints()
    {
        if (highscore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "High\nScore\n" + highscore.ToString();

        score = 0;
        scoreText.text = "Score\n" + score.ToString();
    }
}
