using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject GameOverPanel;							// Display when lives reach 0
    public GameObject WinPanel;
	public GameObject playerSpawnPoint;							// Player1's spawnpoint
    public float respawnDelay;
    public int initialLife;
    private int life;
    public int maxLife;
	public Text timer; 											// Time remaining
	public Text timerShadow;		
	public Text p1Score;										// Player1's score
	public Text p1ScoreShadow;
    public Text lifePoint;                                      // Life
    public Text lifePointShadow;

    private MainMenu mainMenu;

	public float gameTimer;
	private float currentTime;
	private bool hasUpdatedScore = false;
	public static bool isGameOver = false;
    
    public int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }

    void Start () {
        mainMenu = FindObjectOfType<MainMenu>();
        Life = initialLife;
        SetLifeText();
        GameOverPanel.SetActive(false);
		currentTime = gameTimer;
		hasUpdatedScore = false;
		isGameOver = false;
		ScoreController.RestartScore ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetLifeText();

		if (isGameOver)
        {
			//DisplayFinalText (hasUpdatedScore);
		}
        if (ScoreController.isHighScore())
        {
            Win();
        }
	}
	
	public void Respawn() 
	{
		StartCoroutine("RespawnCo");
	}
	
	public IEnumerator RespawnCo() 
	{
        /*
		player.GetComponent<Renderer>().enabled = false; 
		yield return new WaitForSeconds(respawnDelay);
		
		player.enabled = true; 
		player.GetComponent<Renderer>().enabled = true; 
		player.GetComponent<Rigidbody> ().velocity = Vector3.zero;				// Reset ball to zero velocity
		player.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;		// Reset ball to zero angular velocity


		player.transform.position = playerSpawnPoint.transform.position;
        */

        yield return new WaitForSeconds(0);
	}

	public void waitDelay() 
	{ 
		StartCoroutine(wait ());
	}
	
	IEnumerator wait() 
	{ 
		yield return new WaitForSeconds(respawnDelay);
	}

    // Win condition
    public void Win()
    {
        mainMenu.LoadWinScene();
        //WinPanel.SetActive(true);
    }
	
	public void GameOver() 
	{
        isGameOver = true;
        Time.timeScale = 0.0f;
        if(ScoreController.isHighScore())
        {
            ScoreController.updateHighScore();
        }
		GameOverPanel.SetActive (true);
	}
		
	private void DisplayFinalText(bool isHighScore) 
	{
		if (isHighScore) {
			timer.text = "New High Score: " + ScoreController.getScore();
			timerShadow.text = "New High Score: " + ScoreController.getScore();
			isHighScore = true;
		} else { 
			// Display player's score when timer reaches 0				
			timer.text = "Final Score: " + ScoreController.getScore();
			timerShadow.text = "Final Score: " + ScoreController.getScore();
		}
	}

    public void AddLife()
    {
        Life = Mathf.Clamp(Life + 1, 0, maxLife);
    }

    public void LoseLife(int lose)
    {
        Life = Mathf.Clamp(Life - lose, 0, maxLife);
    }

    public void SetLifeText()
    {
        lifePoint.text = "Life: " + Life;
        lifePointShadow.text = "Life: " + Life;
    }
}
