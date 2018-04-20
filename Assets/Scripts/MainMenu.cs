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


    void Start()
    {
        menuStack = new Stack<GameObject>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuStack.Count > 0)
            {
                GameObject frontMenu = menuStack.Peek();
                frontMenu.SetActive(false);
                menuStack.Pop();
            }
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
