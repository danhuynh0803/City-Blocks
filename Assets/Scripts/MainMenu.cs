using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject controlMenu;
    public GameObject soundMenu;
    public GameObject creditMenu;
    public GameObject loadingScreen;
    public GameObject soundController;
    public GameObject levelController;
    [Header("In Game Only")]
    public GameObject pauseMenu;

    public Stack<GameObject> menuStack;

    private bool isPaused;
    private Fading fadeController;

    void Start()
    {
        isPaused = false;
        menuStack = new Stack<GameObject>();
        fadeController = FindObjectOfType<Fading>();
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
        if (isPaused && !LevelController.isGameOver)
        {
            Pause();
        }
        else
        {
            if(!LevelController.isGameOver)
                Resume();
        }
    }

    public void LoadMainMenuScene()
    {
        if (loadingScreen != null)
        {
            //loadingScreen.SetActive(true);
            //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            isPaused = false;
            StartCoroutine(ChangeScene("MainMenu"));
        }
    }

    public void LoadStage1Scene()
    {
        if (loadingScreen != null)
        {
            StartCoroutine(ChangeScene("Stage1"));
            soundController.GetComponent<AudioSource>().PlayOneShot(soundController.GetComponent<SoundController>().sfxClips[0]);
        }
    }

    IEnumerator ChangeScene(string sceneName)
    {
        float fadeTime = fadeController.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Pause()
    {
        if (pauseMenu != null)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
    }
    public void Restart(string stageName)
    {
        SceneManager.LoadScene(stageName, LoadSceneMode.Single);
    }

    public void Resume()
    {
        if (pauseMenu != null)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }

    public void ToggleControlMenu(bool boolean)
    {
        if (controlMenu != null)
        {
            if (boolean)
                menuStack.Push(controlMenu);
            else
                menuStack.Pop();
            controlMenu.SetActive(boolean);
        }
    }
    public void ToggleSoundlMenu(bool boolean)
    {
        if (soundMenu != null)
        {
            if (boolean)
                menuStack.Push(soundMenu);
            else
                menuStack.Pop();
            soundMenu.SetActive(boolean);
        }
    }
    public void ToggleCredit(bool boolean)
    {
        if (creditMenu != null)
        {
            if (boolean)
                menuStack.Push(creditMenu);
            else
                menuStack.Pop();
            creditMenu.SetActive(boolean);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
