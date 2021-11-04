using System;
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

    bool ICBMDestroyed = false;

    bool liveReduced = false;

    int wordIdentifier;

    void Start()
    {
        SetCurrentWord();
        wordIdentifier = UnityEngine.Random.Range(1, 88888);
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
        if (!GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().gameOver)
        CheckInput();
        //Debug.Log(transform.parent.transform.position);
        
        if (transform.parent.transform.position.y < -1.9 && !ICBMDestroyed && !liveReduced
            && !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().gameOver)
        {
            

            gameObject.GetComponent<ParticleSystem>().Emit(100);
            int lives = Int32.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text);

            lives--;

            GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text = lives.ToString();

            liveReduced = true;

            //Destroy(wordOutput);

            wordOutput.enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = 0;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();


        }

        if (transform.parent.transform.position.y < -10)
        {

            Destroy(transform.parent.gameObject);


        }



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
        if (IsCorrectLetter(typedLetter) && 
            (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier == 0 
            || GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier == wordIdentifier))
        
        {

            Removeletter();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = wordIdentifier;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
            gameObject.GetComponent<ParticleSystem>().Emit(1);

            if (IsWordComplete())
            
            {
                //SetCurrentWord();
                gameObject.GetComponent<ParticleSystem>().Emit(50);
                Destroy(wordOutput);

                wordOutput.enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //Destroy(gameObject);
                ICBMDestroyed = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdSceneController>().currentWordIdentifier = 0;

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
