using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    public TextAsset wordFile;          // A text file that will be read in and stored in the words list

    public List<string> stringList;

    private void Awake()
    {
        ParseWordFile();
    }

    public string GetRandomWord()
    {
        int index = Random.Range(0, stringList.Count);
        return stringList[index];
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
