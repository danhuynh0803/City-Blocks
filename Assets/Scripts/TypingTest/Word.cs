using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int currentTypedIndex;  // Used to check if the next letter matches what we type 

    public Word (string word)
    {
        this.word = word;
        currentTypedIndex = 0;
    }

    public char GetNextLetter()
    {
        return word[currentTypedIndex];
    }

    public void IncrementTypeIndex()
    {
        currentTypedIndex++;

        // Remove the letter that is currently on screen
    }

    public bool WordTyped()
    {
        bool wordTyped = (currentTypedIndex >= word.Length);
        if (wordTyped)
        {
            // Remove the word on screen
        }

        return wordTyped;
    }
}
