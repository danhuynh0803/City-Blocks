using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> wordList;
    public Transform killLayer;         // Kills the active word when it passes this point

    private WordSpawner wordSpawner;
    private WordGenerator wordGenerator;

    private Word activeWord;
    private bool hasActiveWord;

    void Start()
    {
        wordSpawner = FindObjectOfType<WordSpawner>();
        wordGenerator = FindObjectOfType<WordGenerator>();

        // For testing if words are parsed properly
        /*
        foreach (Word word in wordList)
        {
            Debug.Log(word.word);
        }
        */
    }

    private void Update()
    {
        // Kill active word when it falls below specified vertical position
        if (hasActiveWord)
        {
            if (activeWord.display.transform.position.y < killLayer.position.y)
            {
                RemoveActiveWord();
            }
            
        }
    }

    public void AddWord()
    {   
        wordList.Add(wordGenerator.GetRandomWord());
    }

    public void AddWord(string newWord)
    {
        wordList.Add(new Word(newWord, wordSpawner.SpawnWord()));
    }

    public void TypeLetter (char letter)
    {
        if (hasActiveWord)
        {
            // Check if the letter is next
            if (char.ToLower(activeWord.GetNextLetter()) == char.ToLower(letter))
            {
                activeWord.IncrementTypeIndex();
                //Debug.Log(activeWord.WordTyped());
                if (activeWord.WordTyped())
                {
                    RemoveActiveWord();
                }
            }
            // Change text to red to indicate incorrect letter
            else
            {
                activeWord.display.SetIncorrectColor();
            }
        }
        else
        {
            foreach (Word word in wordList)
            {
                // Find the next active word
                if (char.ToLower(word.GetNextLetter()) == char.ToLower(letter))
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.IncrementTypeIndex();
                    break;
                }
            }
        }
    }

    private void RemoveActiveWord()
    {
        hasActiveWord = false;
        activeWord.display.RemoveWord();
        wordList.Remove(activeWord);
    }
  
}
