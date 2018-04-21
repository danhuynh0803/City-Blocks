using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Total lives")]
    public static int maxLives = 3;
    private int lives;

    /*
    [Header("Spawn Settings")]
    public Transform playerSpawn; // Where the player is respawned
    public float invincibleDuration = 1.2f;
    private bool isInvincible;
    public float deathDuration = 1.5f;
    private bool isDead;
    Rigidbody rb;
    */

	void Start ()
    {
      
	}
	
	void Update ()
    {
        // This handles the user input for typing test portion
        foreach (char letter in Input.inputString)
        {
            Debug.Log(letter);
        } 
	}

    // This gets the next word being typed in
    void WordInput()
    {

    }
}
