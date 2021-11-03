using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    void Start()
    {
        SetCurrentWord();
    }


    private void SetCurrentWord()
    {

        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);

    }

    private void SetRemainingWord(string newString)
    
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;

    }


    // Update is called once per frame
    void Update()
    {   
        
        CheckInput();
        
    }

    void CheckInput()
    {

        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);



            }


        }


    }

    void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        
        {

            Removeletter();
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();

            if (IsWordComplete())
            
            {
                //SetCurrentWord();
                gameObject.GetComponent<ParticleSystem>().Emit(100);
                Destroy(wordOutput);

            }

        }



    }

    bool IsCorrectLetter(string letter)

    {
        
        
        return remainingWord.IndexOf(letter) == 0;
        
        
    }



    void Removeletter()
    {

        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);

    }

    bool IsWordComplete()
    {

        return remainingWord.Length == 0;


    }


}
