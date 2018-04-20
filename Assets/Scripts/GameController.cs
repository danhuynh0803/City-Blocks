using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject pauseMenu;
    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
                Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }
    public void Restart(string stageName)
    {
        SceneManager.LoadScene(stageName, LoadSceneMode.Single);
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
