using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondSceneController : MonoBehaviour
{
    // Start is called before the first frame update

    string[] textMessage = { "Breaking news: " ,
     "BALLISTIC MISSILE THREAT INBOUND.", "All units, ready to engage.", "Fire at will, THIS IS NOT A DRILL."};

    int messageNumber = 0;


    void Awake()
    {
        
       
    }
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject.FindGameObjectWithTag("GameWord").GetComponent<UnityEngine.UI.Text>().text = textMessage[messageNumber];
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            if (messageNumber <= 3)
            {

                messageNumber++;

            }

            
            if (messageNumber > 3 )
            {

                SceneManager.LoadSceneAsync("ThirdScene", LoadSceneMode.Single);


            }
            

        }

    }

    
}
