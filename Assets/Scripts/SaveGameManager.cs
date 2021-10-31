using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    public float highTime = 0;
   

    const string savedHighScoreKey = "savedHighScore";

    const string savedHighTimeKey = "savedHighTime";

    bool gameSaved = false;

    //string highScore;
    //string highTime;

    void Awake()
    {
        
    }


    void Start()
    {


        highScore = PlayerPrefs.GetInt(savedHighScoreKey, 0);
        highTime = PlayerPrefs.GetFloat(savedHighTimeKey, 0f);

    }

    // Update is called once per frame
    void Update()
    {

       
        if (GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "Mission Failed" ||
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "Mission Accomplished")
        {
            if (!gameSaved)
            {

                SaveScore();

                Debug.Log("score saved");

                gameSaved = true;
            }

           

        }
        
    }

    public void SaveScore()
    {

        
        int currentScore = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
        if (currentScore > highScore)
        {

            //PlayerPrefs.GetInt(savedHighScore) = currentScore;
            PlayerPrefs.SetInt(savedHighScoreKey, currentScore);
            PlayerPrefs.Save();

            PlayerPrefs.SetFloat(savedHighTimeKey, Time.timeSinceLevelLoad);
            PlayerPrefs.Save();


        }

        if (currentScore == highScore && Time.timeSinceLevelLoad < highTime)
        {

            //PlayerPrefs.GetInt(savedHighScore) = currentScore;
            //PlayerPrefs.SetInt(savedHighScoreKey, currentScore);
            //PlayerPrefs.Save();

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
