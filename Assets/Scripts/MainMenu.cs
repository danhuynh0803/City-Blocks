using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject controlMenu;
    public GameObject soundMenu;
    public GameObject credit;
    public GameObject loadingScreen;
    [Header("In Game Only")]
    public GameObject pauseMenu;

    public Stack<GameObject> menuStack;

    private bool isPaused;

    void Start()
    {
        isPaused = false;
        menuStack = new Stack<GameObject>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Close any open windows that is NOT the main pause menu
            if (menuStack.Count > 0)
            {
                GameObject frontMenu = menuStack.Peek();
                frontMenu.SetActive(false);
                menuStack.Pop();
            }
            // If only the pause menu is open, this allows players to exit by clicking escape
            else if (menuStack.Count == 0 && isPaused)
            {
                isPaused = false;
            }
            // Opens the pause menu using escape
            else if (menuStack.Count == 0 && !isPaused)
            {
                isPaused = true;
            }
        }

        // Handle opening/closing of pause menu
        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void LoadMainMenuScene()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void LoadStage1Scene()
    {
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
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

    public void ToggleControlMenu(bool boolean)
    {
        if (boolean)
            menuStack.Push(controlMenu);
        else
            menuStack.Pop(); 
        controlMenu.SetActive(boolean);
    }
    public void ToggleSoundlMenu(bool boolean)
    {
        if (boolean)
            menuStack.Push(soundMenu);
        else
            menuStack.Pop();
        soundMenu.SetActive(boolean);
    }
    public void ToggleCredit(bool boolean)
    {
        if (boolean)
            menuStack.Push(credit);
        else
            menuStack.Pop();
        credit.SetActive(boolean);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
