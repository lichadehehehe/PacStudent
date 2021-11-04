using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdSceneController : MonoBehaviour
{
    //the unique word identifier to identify the currentword being typed
    public int currentWordIdentifier = 0;
    //declare gameover bool
    public bool gameOver = false;
    //explosion emition bool value check
    bool emitted = false;
    //defeat bgm played bool value check
    bool defeatPlayed = false;

    // Start is called before the first frame update
    void Start()
    {   
        //do the coroutine
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {   
        //if live indicater is 0 or time.text is 99:59
        if (Int32.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text) == 0 ||
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "99:59")
        {
            //gameover bool true
            gameOver = true;
            //stop the bgm
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

            //play the defeat bgm
            if (!defeatPlayed)
            {

                GameObject.Find("defeatSound").GetComponent<AudioSource>().Play();
                defeatPlayed = true;

            }
            
            //display the gameover text
            GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "Game Over \n Press Enter to retry. \n Press Esc for main menu.";
            
            //if user pressed return, reload the level
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadSceneAsync("ThirdScene", LoadSceneMode.Single);
            }

            //if user pressed esc, go back to main menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);
            }

            //disable the renderer of the player and stop the particle system
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleSystem>().Stop();


        }

        //emit the explosion particles
        if (gameOver && !emitted)
        {
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(500);
            emitted = true;
        }

        //if not gameover, display the timer
        if (!gameOver)
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = FormatTime(Time.timeSinceLevelLoad).ToString();
    }

    IEnumerator MyCoroutine()
    {
        //declare the player 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    
        marker:
        if (!gameOver)
        {   
            //initiate the missiles randomly above the screen
            //missiles dropped each 2 seconds
            GameObject missile1 = (GameObject)Instantiate(Resources.Load("GreyGhost"));

            missile1.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 20 * 0.4f), 5.803f, 0f);
 
            yield return new WaitForSecondsRealtime(2f);

            GameObject missile2 = (GameObject)Instantiate(Resources.Load("BlueGhost"));
            missile2.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 20 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);

            GameObject missile3 = (GameObject)Instantiate(Resources.Load("GreenGhost"));
            missile3.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 20 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);
            GameObject missile4 = (GameObject)Instantiate(Resources.Load("RedGhost"));
            missile4.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 20 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);

            //repeat coroutine 
            goto marker;

        }

        
    }

    //format time function to display the timer
    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00}:{1:00}", minutes, seconds);
        return timeText;
    }
}
