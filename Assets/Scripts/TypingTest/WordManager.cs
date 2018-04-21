using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> wordList;
    public TextAsset wordFile;  // A text file that will be read in and stored in the words list

    private Word activeWord;
    private bool hasActiveWord;

    void Start()
    {
        ParseWordFile();   
    
        
        // For testing if words are parsed properly
        foreach (Word word in wordList)
        {
            Debug.Log(word.word);
        }
        
    }
    
    public Word GetRandomWord()
    {
        int index = Random.Range(0, wordList.Count);
        return wordList[index];
    }

    public void TypeLetter (char letter)
    {
        if (hasActiveWord)
        {
            // Check if the letter is next
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.IncrementTypeIndex();
            }
        }
        else
        {
            foreach (Word word in wordList)
            {
                // 
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.IncrementTypeIndex();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            wordList.Remove(activeWord);
        }
    }

    // Parse and add the words from the word text file into the word list
    private void ParseWordFile()
    {
        string[] wordLines = wordFile.text.Split('\n');
        foreach (string newWord in wordLines)
        {
            // Add only if the word has a length
            if (newWord.Length > 0)
            {
                wordList.Add(new Word(newWord));
            }
        }
    }
}
