using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private static int score;                   // Player 1's score
    private static int highscore;               // Current high score, resets if program is turned off

    public Text scoreText;
    public Text scoreShadowText;
    public Text highscoreText;
    public Text highscoreShadowText;

    void Awake()
    {
        score = 0;
        highscore = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;               // Display score
        scoreShadowText.text = "Score: " + score;         // Display the black highlight around score
        highscoreText.text = "High Score: " + highscore;       // Display highscore
        highscoreShadowText.text = "High Score: " + highscore; // Display the black highlight around highscore
    }

    public static void RestartScore()
    {
        score = 0;
    }

    public static void incrementScore(int pointValue)
    {
        score += pointValue;
    }

    public static void decrementScore(int pointValue)
    {
        score -= pointValue;
    }

    public static int getScore()
    {
        return score;
    }

    public static bool isHighScore()
    {
        if (score > highscore)
        {
            return true;
        }
        return false;
    }

    public static void updateHighScore()
    {
        highscore = score;
    }
}

