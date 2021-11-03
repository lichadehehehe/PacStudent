using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdSceneController : MonoBehaviour
{

    public int currentWordIdentifier = 0;

    public bool gameOver = false;

    bool emitted = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text) == 0)
        {

            gameOver = true;
            //Debug.Log("GameOver");
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<UnityEngine.UI.Text>().text = "Game Over \n Press Enter to retry. \n Press Esc for main menu.";
            
            if (Input.GetKeyDown(KeyCode.Return))
            {

                SceneManager.LoadSceneAsync("ThirdScene", LoadSceneMode.Single);


            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {


                SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);


            }


            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleSystem>().Stop();


        }

        if (gameOver && !emitted)
        {

            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(500);
            emitted = true;

        }

        if (!gameOver)
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = FormatTime(Time.timeSinceLevelLoad).ToString();
    }

    IEnumerator MyCoroutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    
        marker:
        if (!gameOver)
        {
            GameObject missile1 = (GameObject)Instantiate(Resources.Load("GreyGhost"));

            missile1.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 14 * 0.4f), 5.803f, 0f);
            //missile1.GetComponent<Rigidbody>().AddForce( player.transform.position * 200f);

            yield return new WaitForSecondsRealtime(2f);



            GameObject missile2 = (GameObject)Instantiate(Resources.Load("BlueGhost"));
            missile2.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 14 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);

            GameObject missile3 = (GameObject)Instantiate(Resources.Load("GreenGhost"));
            missile3.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 14 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);
            GameObject missile4 = (GameObject)Instantiate(Resources.Load("RedGhost"));
            missile4.transform.position = new Vector3(UnityEngine.Random.Range(-3.456f, -5.456f + 14 * 0.4f), 5.803f, 0f);

            yield return new WaitForSecondsRealtime(2f);

            goto marker;

        }

        
    }

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
