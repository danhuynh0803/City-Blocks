using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject GameOverPanel;							// Display when timer reaches 0
	public GameObject playerSpawnPoint;							// Player1's spawnpoint
    public float respawnDelay; 

	public Text timer; 											// Time remaining
	public Text timerShadow;		
	public Text p1Score;										// Player1's score
	public Text p1ScoreShadow;

	public float gameTimer;
	private float currentTime;
	private bool hasUpdatedScore = false;
	private bool isGameOver = false;

	void Start () {
        GameOverPanel.SetActive(false);
		currentTime = gameTimer;
		hasUpdatedScore = false;
		isGameOver = false;
		ScoreController.RestartScore ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isGameOver) {
			DisplayFinalText (hasUpdatedScore);
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

	
	private void GameOver() 
	{		
		Time.timeScale = 0.0f;
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
}
