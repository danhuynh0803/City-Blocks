using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> wordList;
    public Transform killLayer;         // Kills the active word when it passes this point

    private WordSpawner wordSpawner;
    private WordGenerator wordGenerator;
    [SerializeField]
    private List<Word> activeWord;
    private bool hasActiveWord;
    private bool hasMultiplierChain;

    private Powerup powerupController;

    void Start()
    {
        activeWord = new List<Word>();
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
                foreach (Word word in activeWord.ToList())
                {
                    if (firstWord == word)
                    {
                        activeWord.Remove(word);
                    }
                }
                firstWord.display.RemoveWord();
                wordList.Remove(firstWord);

                // Missed a word so reset the multiplier back to one
                ScoreController.resetMultiplier();
            }     
        }        
    }

    public void AddWord()
    {   
        wordList.Add(wordGenerator.GetRandomWord());
    }

    public void AddWord(string newString)
    {
        Word word = new Word(newString, wordSpawner.SpawnWord(), Color.green);
        wordList.Add(word);
    }

    public void TypeLetter (char letter)
    {
        if (!letter.Equals('[') && !letter.Equals(']'))
        {
            List<Word> Removingwords = new List<Word>();
            if (activeWord.Count>0)
            {
                foreach (Word active in activeWord.ToList())
                {
                    // Check if the letter is next
                    if (char.ToLower(active.GetNextLetter()) == char.ToLower(letter))
                    {
                        active.IncrementTypeIndex();
                        //Debug.Log(activeWord.WordTyped());
                        if (active.WordTyped())
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
                            RemoveActiveWord(active);
                        }
                    }
                    // Change text to red to indicate incorrect letter
                    else
                    {
                        active.display.SetIncorrectColor();
                        SoundController.Play((int)SFX.Wrong);
                    }
                }
            }
            foreach (Word word in wordList)
            {
                // Find the next active word
                if (char.ToLower(word.GetNextLetter()) == char.ToLower(letter))
                {
                    if(!activeWord.Contains(word))
                    {
                        activeWord.Add(word);
                        word.display.IncreaseFontSize(10);
                        word.IncrementTypeIndex();
                    }
                }
            }
        }
    }

    private void RemoveActiveWord(Word active)
    {
        activeWord.Remove(active);
        // Active the powerup for that word
        powerupController.ActivatePowerup(active.lineNumFunction, active); // pass the index
        ScoreController.incrementScore(active.points);  // Get points for typing the word correctly
        active.display.RemoveWord();
        wordList.Remove(active);
    }
  
}
