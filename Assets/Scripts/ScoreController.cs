using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private static int score;                   // Player 1's score
    private static int highscore;               // Current high score, resets if program is turned off
    private static int scoreMultiplier;

    public Text scoreText;
    public Text scoreShadowText;
    public Text highscoreText;
    public Text highscoreShadowText;
    public Text scoreMultiplierText;
    public Text scoreMultiplierShadowText;

    public static bool hasChain;

    void Awake()
    {
        score = 0;
        scoreMultiplier = 1;
        highscore = 11151992;   // Win condition score
        //highscore = 5;        // For testing win condition
    }

    void Update()
    {
        scoreText.text = "Score: " + score;               
        scoreShadowText.text = "Score: " + score;         
        highscoreText.text = "High Score: " + highscore;       
        highscoreShadowText.text = "High Score: " + highscore;  

        if (!hasChain)
        {
            scoreMultiplierText.color = Color.white;
        } 
        else
        {
            scoreMultiplierText.color = Color.green;
        }

        scoreMultiplierText.text = "" + scoreMultiplier;       
        scoreMultiplierShadowText.text = "" + scoreMultiplier;
    }

    public static void incrementMultiplier()
    {
        scoreMultiplier = Mathf.Clamp(scoreMultiplier *= 2, 1, 1024);
    }

    public static void resetMultiplier()
    {
        hasChain = false;
        scoreMultiplier = 1;
    }

    public static void RestartScore()
    {
        score = 0;
    }

    public static void incrementScore(int pointValue)
    {
        score += scoreMultiplier * pointValue;
    }

    public static void decrementScore(int pointValue)
    {
        score -= scoreMultiplier * pointValue;
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

