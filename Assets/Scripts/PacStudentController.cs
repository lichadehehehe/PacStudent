using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacStudentController : MonoBehaviour
{
    
    private List<GameObject> itemList;
    private LevelGenerator levelGenerator;
    int[,] levelMap;

    GameObject pacStudent;

    private Vector3 movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 1.5f;
 

    public AudioSource footStepSource;


    Vector3 tempPosition;

    Vector3 previousPosition;

    ParticleSystem theAshParticles;

    public bool isInputEnabled = true;

    bool gameOver = false;


    void Awake()
    {
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;
        GameObject pacStudent = GameObject.FindGameObjectWithTag("Player");

        //get the initial position of the levelgenerator, make the pacstudent to the top left corner of the map

        Vector3 initialPacPosition = new Vector3(-5.456f + 0.4f, 5.803f - 0.4f, 0);
        pacStudent.transform.position = initialPacPosition;

     

    }
    void Start()
    {
        levelGenerator = GetComponent<LevelGenerator>();
        
        StartCoroutine(MyCoroutine());

    }


    void Update()
    {   
        //if the gmae is not gameover yet, display timer back the time.timesincelevelload function
        if (!gameOver)
        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = FormatTime(Time.timeSinceLevelLoad - 4f).ToString();


        Animator anim = gameObject.GetComponent<Animator>();
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;

        //if the pacstudent go through the teleporter
        if (gameObject.transform.position.x < -5.456f)
        {
            float originalY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(-5.456f + levelMap.GetUpperBound(1) * 0.4f * 2, originalY, 0);


        }

        //if the pacstudent go through the teleporter
        if (gameObject.transform.position.x > -5.456f + levelMap.GetUpperBound(0) * 0.4f * 2)
        {

            float originalY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(-5.456f, originalY, 0);


        }

        // if D is prssed, set the pac animator to "right"
        if (Input.GetKeyDown(KeyCode.D) && isInputEnabled)
        {
            anim.SetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }


        //if A is pressed, set the pac animator to "left"
        if (Input.GetKeyDown(KeyCode.A) && isInputEnabled)
        {
            anim.SetTrigger("Left");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }


        //if the S is pressed, set the pac animator to "down"
        if (Input.GetKeyDown(KeyCode.S) && isInputEnabled)
        {
            anim.SetTrigger("Down");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
        }


        //if the w is pressed, set the pac animator to "up"
        if (Input.GetKeyDown(KeyCode.W) && isInputEnabled)
        {
            anim.SetTrigger("Up");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Down");

        }


        //enabled the pac movement functions
        GetMovementVector();
        CharacterPostion();
       

        //if the game is not over yet, play footstep audio
        if (!gameOver)
        FootstepAudio();
        
        //if the pacstudent lives is zero, or timer exceeds 99:99:99, or all pallets are eaten, gameover
        if (GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text == "0" ||
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "99:99:99" ||
            (GameObject.FindGameObjectsWithTag("coin").Length == 1 && GameObject.FindGameObjectsWithTag("LoveLiveROC").Length == 1))
        {
            //do the gameover coroutine
            if (!gameOver)
            {

                StartCoroutine(GameOverCoroutine());
                
                //use bool value to check to avoid the coroutine being called indefinately
                gameOver = true;

            }
            //if player preseed return key, return to main menu
            if (Input.GetKeyDown(KeyCode.Return))
            {

                SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);

            }
        }


    }

   

    void GetMovementVector()
    {
       
        //make pac go right if D is pressed
        if (Input.GetAxis("Horizontal") > 0 && isInputEnabled)
        {

            movement.x++;
           
        }

        //make pac go left if A is pressed
        if (Input.GetAxis("Horizontal") < 0 && isInputEnabled)
        {
            movement.x--;

        }

        //make pac go up if W is pressed
        if (Input.GetAxis("Vertical") > 0 && isInputEnabled)
        {

            movement.y++;

        }

        //make pac go down if S is pressed
        if (Input.GetAxis("Vertical") < 0 && isInputEnabled)
        {
            movement.y--;

        }

        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movementSqrMagnitude = movement.sqrMagnitude;
    }


    void CharacterPostion()
    {
        
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

    }

    void FootstepAudio()
    {
        //get the footstep audio and particles gameobjects
        AudioSource footStepSource = gameObject.GetComponent<AudioSource>();
        ParticleSystem theAshParticles = gameObject.GetComponent<ParticleSystem>();
        

        //check the pac is moving or not by checking their position values
        //if the pac is moving
        if (tempPosition.x - previousPosition.x > 0.1 || tempPosition.y - previousPosition.y > 0.1)
        {

            //play the ash particles
            theAshParticles.Play();
            
            //play the foot step audio
            if (!footStepSource.isPlaying)
            {

                footStepSource.Play();
                

            }

        }

        //if the pac is not moving
        else if (tempPosition.x - previousPosition.x < 0.1 && tempPosition.y - previousPosition.y < 0.1)
        {
            //stop the ash particles
            theAshParticles.Stop();
            
            //stop the foot step audio
            if (footStepSource.isPlaying)
            {
                footStepSource.Stop();
                

            }

        }
        
       
    }


    //the following coroutine is to check the position of the pac to determine whether it is moving or not
    IEnumerator MyCoroutine()
    {

    marker:

        
        tempPosition = gameObject.transform.position;
        
        yield return new WaitForSecondsRealtime(0.4f);
        previousPosition = gameObject.transform.position;
        
        yield return new WaitForSecondsRealtime(0.4f);

        goto marker;

    }

    //format the time float value in minute, seconds, milliseconds
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

    //the following coroutine will be enbaled if gameover
    IEnumerator GameOverCoroutine()
    {
        //stop the bgm from playing
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().enabled = false;
        GameObject.FindGameObjectWithTag("ScaredBGM").GetComponent<AudioSource>().enabled = false;
        
        //if the gameover is because of the player's defeat
        if (GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text == "0")
        {   
            //display mission failed text
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "Mission Failed";
            //play the defeat bgm (national anthem of the soviet union)
            GameObject.FindGameObjectWithTag("Lose").GetComponent<AudioSource>().Play();

        }

        //if the gameover is becuase of all pallets are eaten
        else
        {   
            //display mission accomplisehd text
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "Mission Accomplished";
            //play the win bgm (internationale)
            GameObject.FindGameObjectWithTag("Win").GetComponent<AudioSource>().Play();


        }

        //disable pacstudent's components
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("extraParticleController").active = false;
        GameObject.FindGameObjectWithTag("ExplosionParticle").active = false;

        


        yield return null;

        // i could have implemented the "wait for 3 seconds and went back to main menu function
        // but i made two ending music at the gameover scene on flStudio so i did not implement it
        // win bgm is the national anthem of the soviet union
        // lose bgm is the internationale

        // yield return WaitForSeconds(3f);
        // SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);


    }
}















