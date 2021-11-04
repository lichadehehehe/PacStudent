using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordBank : MonoBehaviour
{
    
    //read txt file, append words into the word bank
    List<string> originalWords = System.IO.File.ReadLines("Assets/Scripts/wordlist10000.txt").ToList();

    private List<string> workingWords = new List<string>();

    private void Awake()
    {   
        //declare the range of the array list
        workingWords.AddRange(originalWords);
        //shuffle the working words arraylist to get random result
        Shuffle(workingWords);
        //convert all words to lower case
        ConverToLower(workingWords);

    }

    //shuffle words in the array list
    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {

            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;


        }


    }

    //convert word to lower case
    private void ConverToLower(List<string> list)
    {

        for (int i = 0; i < list.Count; i++)
        {

            list[i] = list[i].ToLower();

        }

    }
    

    public string GetWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count != 0)
        {

            newWord = workingWords.Last();
            workingWords.Remove(newWord);


        }

        return newWord;


    }

   
}
