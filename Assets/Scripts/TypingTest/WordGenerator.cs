using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    public TextAsset wordFile;          // A text file that will be read in and stored in the words list

    public List<string> stringList;

    private WordSpawner wordSpawner;

    private void Awake()
    {
        ParseWordFile();
        wordSpawner = FindObjectOfType<WordSpawner>();
    }

    public Word GetRandomWord()
    {
        int index = Random.Range(0, stringList.Count);
        Word newWord;

        // Control color based on what index the word was chosen at
        // All words from lines 1-15 are green (powerup related awards)
        if (index < 15)
            newWord = new Word(stringList[index], wordSpawner.SpawnWord(), Color.green);
        else
            newWord = new Word(stringList[index], wordSpawner.SpawnWord(), Color.yellow);

        return newWord;
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
                stringList.Add(newWord);
            }
        }
    }
}
