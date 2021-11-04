using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSaveGameManager : MonoBehaviour
{
    public int score = 0;

    public float highTime = 0;

    //declare the save game key
    const string secondHighTimeKey = "secondSavedHighTime";

    bool gameSaved = false;

    void Start()
    {
        //get the playerpref value
        highTime = PlayerPrefs.GetFloat(secondHighTimeKey, 0f);
    }

   
    void Update()
    {   
        //if gameover
        if (GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text == "Game Over \n Press Enter to retry. \n Press Esc for main menu.")
        {   

            //save game
            if (!gameSaved)
            {

                SaveScore();

                gameSaved = true;
            }

        }
    }

    public void SaveScore()
    {
        //if the surviving time is longer than the high time, save it 
        if (Time.timeSinceLevelLoad > highTime)
        {

            PlayerPrefs.SetFloat(secondHighTimeKey, Time.timeSinceLevelLoad);
            PlayerPrefs.Save();

        }

    }
}
