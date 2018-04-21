using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

    public Text text;
    public Text shadowText;
    public float fallSpeed = 500.0f;

    // Set the text to display a word
    public void SetWordText(string word)
    {
        text.text = word;
        shadowText.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        shadowText.text = shadowText.text.Remove(0, 1);
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
