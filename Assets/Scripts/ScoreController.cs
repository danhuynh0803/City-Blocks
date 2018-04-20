using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private static int score;                   // Player 1's score
    private static int highScore;               // Current high score, resets if program is turned off

    public Text p1ScoreText;
    public Text p1ScoreShadowText;
    public Text p2ScoreText;
    public Text p2ScoreShadowText;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        p1ScoreText.text = "Score: " + ScoreController.score;               // Display player1's score
        p1ScoreShadowText.text = "Score: " + ScoreController.score;         // Display the black highlight around score
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
        return ScoreController.score;
    }

    public static bool isHighScore()
    {
        if (ScoreController.score > ScoreController.highScore)
        {
            return true;
        }
        return false;
    }

    public static void updateHighScore()
    {
        ScoreController.highScore = ScoreController.score;
    }
}

