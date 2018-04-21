using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> wordList;
   
    private WordSpawner wordSpawner;
    private WordGenerator wordGenerator;

    private Word activeWord;
    private bool hasActiveWord;

    void Start()
    {
        wordSpawner = FindObjectOfType<WordSpawner>();
        wordGenerator = FindObjectOfType<WordGenerator>();

        // For testing if words are parsed properly
        foreach (Word word in wordList)
        {
            Debug.Log(word.word);
        }
        
    }
    
    public void AddWord()
    {
        wordList.Add(new Word(wordGenerator.GetRandomWord(), wordSpawner.SpawnWord()));
    }

    public void TypeLetter (char letter)
    {
        if (hasActiveWord)
        {
            // Check if the letter is next
            if (char.ToLower(activeWord.GetNextLetter()) == char.ToLower(letter))
            {
                activeWord.IncrementTypeIndex();
                Debug.Log(activeWord.WordTyped());
                if (activeWord.WordTyped())
                {
                    hasActiveWord = false;
                    wordList.Remove(activeWord);
                }
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

        /*
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            wordList.Remove(activeWord);
        }
        */
    }
  
}
