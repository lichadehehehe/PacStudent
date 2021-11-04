using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHighScore : MonoBehaviour
{
    
    //declare the playerpref keys
    const string savedHighScoreKey = "savedHighScore";

    const string savedHighTimeKey = "savedHighTime";

    const string secondHighTimeKey = "secondSavedHighTime";
    void Start()
    {
        //get the save playerpref values
        int highScore = PlayerPrefs.GetInt(savedHighScoreKey, 0);
        float highTime = PlayerPrefs.GetFloat(savedHighTimeKey, 0f);
        float secondHighTime = PlayerPrefs.GetFloat(secondHighTimeKey, 0f);
        //display the palyerpref values
        GameObject.FindGameObjectWithTag("highScore").GetComponent<UnityEngine.UI.Text>().text = "High Score: " + highScore.ToString();
        GameObject.FindGameObjectWithTag("highTime").GetComponent<UnityEngine.UI.Text>().text = "Time: " + FormatTime(highTime);
        GameObject.Find("SecondHighTime").GetComponent<UnityEngine.UI.Text>().text = "Time: " + FormatTime(secondHighTime);
    }

    //the format time function to format flaot time value
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

