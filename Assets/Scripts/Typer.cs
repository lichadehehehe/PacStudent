using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    //declare the word bank to be used by typings
    public WordBank wordBank = null;
    //declare the word display
    public Text wordOutput = null;
    //declare the empty string of the remaining word
    private string remainingWord = string.Empty;
    //declare the empty string of the currentword
    private string currentWord = string.Empty;
    
    bool ICBMDestroyed = false;

    bool liveReduced = false;
    //declare the wordIdentifier
    int wordIdentifier;

    void Start()
    {   
        //set current word
        SetCurrentWord();
        //randomly generate an int word identifier 
        wordIdentifier = UnityEngine.Random.Range(1, 88888);
    }

    //set currentword and get the word from the word bank
    private void SetCurrentWord()
    {
        
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);

    }

    //if user typed something, set the remaining word
    private void SetRemainingWord(string newString)
    
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;

    }


    // Update is called once per frame
    void Update()
    {
        //if not gameover, do the checkinput function
        if (!GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().gameOver)
        CheckInput();
        
        //if the missiles dropped onto player and not destroyed and not yet gameover
        if (transform.parent.transform.position.y < -1.9 && !ICBMDestroyed && !liveReduced
            && !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().gameOver)
        {
            
            //emit the explosion particle
            gameObject.GetComponent<ParticleSystem>().Emit(100);
            //get the remaining lives 
            int lives = Int32.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text);
            //deduct 1 life
            lives--;
            //update life
            GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text = lives.ToString();
            
            liveReduced = true;

            //if user typed out all letters, disable the text 
            wordOutput.enabled = false;

            //reset the current word identifier to 0
            //this is to make sure only one word can be typed at a time
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = 0;
            //disable the spriterender of the missile
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //play the explosion bgm
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();

        }

        //destroy the missiles of they are dropped all the way down
        if (transform.parent.transform.position.y < -10)
        {

            Destroy(transform.parent.gameObject);

        }

    }

    void CheckInput()
    {
        //if user type in any key, check whether is the correct letter
        if (Input.anyKeyDown)
        {   
            //get the input key
            string keysPressed = Input.inputString;
            
            //make sure only one letter can be typed at a time
            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);

            }

        }

    }

    void EnterLetter(string typedLetter)
    {   
        //if the enter letter is correct
        //if the currentwordidentifier is either 0 or this word's identifier
        if (IsCorrectLetter(typedLetter) && 
            (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier == 0 
            || GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier == wordIdentifier))
        
        {
            //remove the typed letter
            Removeletter();
            //set the currentWordIdentifier to be this wordIdentifier
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = wordIdentifier;
            //play the key typed sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
            //emit one particle
            gameObject.GetComponent<ParticleSystem>().Emit(1);

            //if word is complete
            if (IsWordComplete())    
            {
                //emit 50 particles from the explosion particle system
                gameObject.GetComponent<ParticleSystem>().Emit(50);
                //disable the wordoutput uitext
                wordOutput.enabled = false;
                //disable the spriterendere of the missile
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                
                ICBMDestroyed = true;
                //reset the current word identifier to 0
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = 0;

            }

        }



    }

    bool IsCorrectLetter(string letter)

    {
        //if the corret letter is typed
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
