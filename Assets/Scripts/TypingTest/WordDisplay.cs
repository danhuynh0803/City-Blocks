using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

    public Text text;
    public Text shadowText;
    public float fallSpeed = 20.0f;
    //public float destroyTimer = 30.0f;      // Amount of time before the word disappeared
    public Color textColor = Color.yellow;
    public float time;

    private void Start()
    {
        //Destroy(this.gameObject, destroyTimer);
    }

    // Set the text to display a word
    public void SetWordText(string word)
    {
        text.text = word;
        shadowText.text = word;
    }

    public void IncreaseFontSize(int increaseAmount)
    {
        text.fontSize += increaseAmount;
        shadowText.fontSize += increaseAmount;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        shadowText.text = shadowText.text.Remove(0, 1);
        text.color = textColor;
    }

    // When player types wrong letter
    public void SetIncorrectColor()
    {
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
