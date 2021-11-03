using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSaveGameManager : MonoBehaviour
{
    public int score = 0;

    public float highTime = 0;

    const string secondHighTimeKey = "secondSavedHighTime";

    bool gameSaved = false;

    void Start()
    {
        
        highTime = PlayerPrefs.GetFloat(secondHighTimeKey, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text == "Game Over \n Press Enter to retry. \n Press Esc for main menu.")
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



        if (Time.timeSinceLevelLoad > highTime)
        {

            //PlayerPrefs.GetInt(savedHighScore) = currentScore;
            //PlayerPrefs.SetInt(savedHighScoreKey, currentScore);
            //PlayerPrefs.Save();

            PlayerPrefs.SetFloat(secondHighTimeKey, Time.timeSinceLevelLoad);
            PlayerPrefs.Save();


        }



    }
}
