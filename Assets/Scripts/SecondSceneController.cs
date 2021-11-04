using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondSceneController : MonoBehaviour
{
    

    string[] textMessage = { "Breaking news: " ,
     "BALLISTIC MISSILE THREAT INBOUND.", "All units, ready to engage.", "Fire at will, THIS IS NOT A DRILL."};

    int messageNumber = 0;


    // Update is called once per frame
    void Update()
    {   
        //if enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //while messagenumber less or equal to 3, inrement the messagenumber
            if (messageNumber <= 3)
            {

                messageNumber++;

            }

            //if meesagenumber greater than 3, load the level
            if (messageNumber > 3)
            {

                SceneManager.LoadSceneAsync("ThirdScene", LoadSceneMode.Single);


            }


        }

        //display the gametext
        if (messageNumber <= 3)
            GameObject.FindGameObjectWithTag("GameWord").GetComponent<UnityEngine.UI.Text>().text = textMessage[messageNumber];

    }

    
}
