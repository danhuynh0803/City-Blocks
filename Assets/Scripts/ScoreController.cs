using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

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
    private static GameObject newHighScoreT;
    public GameObject newHighScoreText;

    public static bool hasChain;

    void Awake()
    {
        score = 0;
        scoreMultiplier = 1;
        //highscore = 100;
        highscore = 5151992;
        //Load();
        // For testing win condition
    }
    void Start()
    {
        newHighScoreT = newHighScoreText;

    }
    void Update()
    {
        scoreText.text = "Score: " + score;               
        scoreShadowText.text = "Score: " + score;         
        highscoreText.text = "Goal: 0" + highscore;       
        highscoreShadowText.text = "Goal: 0" + highscore;  

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
        //Save(score);
        highscore = score;
        if (newHighScoreT.gameObject != null)
            newHighScoreT.gameObject.SetActive(true);
    }
    public static void Save(int highScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "/LD41PlayerInfo.dat");
        PlayerData data = new PlayerData(highScore);
        bf.Serialize(saveFile, data);
        saveFile.Close();
    }
    public static void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        try
        {
            FileStream saveFile = File.Open(Application.persistentDataPath + "/LD41PlayerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(saveFile);
            saveFile.Close();
            if (data.highScore > highscore)
            {
                highscore = data.highScore;
            }
        }
        catch(FileNotFoundException e)
        {
            Debug.Log("not found");
            Save(0);
        }
    }
}
[Serializable]
public class PlayerData
{
    public int highScore; 
    public PlayerData(int highScore)
    {
        this.highScore = highScore;
    }
}

