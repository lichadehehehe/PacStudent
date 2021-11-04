using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    public float highTime = 0;
   
    //declare the highscore and hightime key string
    const string savedHighScoreKey = "savedHighScore";

    const string savedHighTimeKey = "savedHighTime";


    bool gameSaved = false;

    


    void Start()
    {

        //get the high score and high time from playerpref
        highScore = PlayerPrefs.GetInt(savedHighScoreKey, 0);
        highTime = PlayerPrefs.GetFloat(savedHighTimeKey, 0f);

    }

    // Update is called once per frame
    void Update()
    {

        // if gameover
        if (GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "Mission Failed" ||
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "Mission Accomplished")
        {   
            //if game has not saved yet, do the savegame funtion
            //the gameSaved bool is to avoid savescore function being called indefinately
            if (!gameSaved)
            {

                SaveScore();

                gameSaved = true;
            }

        }
        
    }

    public void SaveScore()
    {

        //get the score by int.parse the ui.text of score gameobject
        int currentScore = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
        
        //if currentscore is higher than the highscore, do the save
        if (currentScore > highScore)
        {

            
            PlayerPrefs.SetInt(savedHighScoreKey, currentScore);
            PlayerPrefs.Save();

            PlayerPrefs.SetFloat(savedHighTimeKey, Time.timeSinceLevelLoad);
            PlayerPrefs.Save();


        }

        //if the currentscore is same but time lower, also do the save
        if (currentScore == highScore && Time.timeSinceLevelLoad < highTime)
        {

            PlayerPrefs.SetFloat(savedHighTimeKey, Time.timeSinceLevelLoad);
            PlayerPrefs.Save();

        }

    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }
}
