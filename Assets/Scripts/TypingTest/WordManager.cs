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
    private bool hasMultiplierChain;

    private Powerup powerupController;

    void Start()
    {
        wordSpawner = FindObjectOfType<WordSpawner>();
        wordGenerator = FindObjectOfType<WordGenerator>();
        powerupController = FindObjectOfType<Powerup>();

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
        // Kill each word when it falls below specified vertical position
        if (wordList.Count > 0)
        {
            // Check if the first word is out of bounds 
            Word firstWord = wordList[0];
            if (firstWord.display.transform.position.y < killLayer.position.y)
            {
                if (firstWord == activeWord)
                    RemoveActiveWord();
                else
                {
                    firstWord.display.RemoveWord();
                    wordList.Remove(firstWord);
                }

                // Missed a word so reset the multiplier back to one
                ScoreController.resetMultiplier();
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
        if (!letter.Equals('[') && !letter.Equals(']'))
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
                        ScoreController.hasChain = true;
                        if (!hasMultiplierChain)
                        {
                            hasMultiplierChain = true; // Start chaining the words for multiplier                        
                        }
                        else
                        {
                            ScoreController.incrementMultiplier();
                        }
                        //ScoreController.incrementScore(activeWord.points);
                        RemoveActiveWord();
                    }
                }
                // Change text to red to indicate incorrect letter
                else
                {
                    activeWord.display.SetIncorrectColor();
                    SoundController.Play((int)SFX.Wrong);
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
                        activeWord.display.IncreaseFontSize(10);
                        hasActiveWord = true;
                        word.IncrementTypeIndex();
                        break;
                    }
                }
            }
        }
    }

    private void RemoveActiveWord()
    {
        hasActiveWord = false;

        // Active the powerup for that word
        powerupController.ActivatePowerup(activeWord.lineNumFunction, activeWord); // pass the index
        ScoreController.incrementScore(activeWord.points);  // Get points for typing the word correctly
        activeWord.display.RemoveWord();
        wordList.Remove(activeWord);
    }
  
}
