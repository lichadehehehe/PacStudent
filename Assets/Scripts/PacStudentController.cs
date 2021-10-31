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
        if (!gameOver)
        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = FormatTime(Time.timeSinceLevelLoad - 4f).ToString();


        Animator anim = gameObject.GetComponent<Animator>();
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;
        if (gameObject.transform.position.x < -5.456f)
        {
            float originalY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(-5.456f + levelMap.GetUpperBound(1) * 0.4f * 2, originalY, 0);


        }

        if (gameObject.transform.position.x > -5.456f + levelMap.GetUpperBound(0) * 0.4f * 2)
        {

            float originalY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(-5.456f, originalY, 0);



        }

        if (Input.GetKeyDown(KeyCode.D) && isInputEnabled)
        {
            anim.SetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }



        if (Input.GetKeyDown(KeyCode.A) && isInputEnabled)
        {
            anim.SetTrigger("Left");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }



        if (Input.GetKeyDown(KeyCode.S) && isInputEnabled)
        {
            anim.SetTrigger("Down");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
        }



        if (Input.GetKeyDown(KeyCode.W) && isInputEnabled)
        {
            anim.SetTrigger("Up");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Down");

        }



        GetMovementVector();
        CharacterPostion();
       


        if (!gameOver)
        FootstepAudio();
        

        if (GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text == "0" ||
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text == "99:99:99" ||
            (GameObject.FindGameObjectsWithTag("coin").Length == 1 && GameObject.FindGameObjectsWithTag("LoveLiveROC").Length == 1))
        {

            if (!gameOver)
            {

                StartCoroutine(GameOverCoroutine());
                

               
                gameOver = true;

            }

            if (Input.GetKeyDown(KeyCode.Return))
            {


                SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);


            }
        }


    }

   

    void GetMovementVector()
    {
       

        if (Input.GetAxis("Horizontal") > 0 && isInputEnabled)
        {

            movement.x++;
           

        }

        if (Input.GetAxis("Horizontal") < 0 && isInputEnabled)
        {
            movement.x--;


        }

        if (Input.GetAxis("Vertical") > 0 && isInputEnabled)
        {

            movement.y++;


        }

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

        AudioSource footStepSource = gameObject.GetComponent<AudioSource>();
        ParticleSystem theAshParticles = gameObject.GetComponent<ParticleSystem>();
        


        if (tempPosition.x - previousPosition.x > 0.1 || tempPosition.y - previousPosition.y > 0.1)
        {


            theAshParticles.Play();
            //extraCollisionParticles.Stop();
            //Debug.Log("moving");


            if (!footStepSource.isPlaying)
            {

                footStepSource.Play();
                

            }

        }

        else if (tempPosition.x - previousPosition.x < 0.1 && tempPosition.y - previousPosition.y < 0.1)
        {

            theAshParticles.Stop();
            //extraCollisionParticles.Emit(500);
           // Debug.Log("not moving");


            if (footStepSource.isPlaying)
            {
                footStepSource.Stop();
                

            }

        }
        
       
    }


    

    IEnumerator MyCoroutine()
    {

    marker:

        //yield return null;
        tempPosition = gameObject.transform.position;
        //Debug.Log("tempPosition: " + tempPosition);
        yield return new WaitForSecondsRealtime(0.4f);
        previousPosition = gameObject.transform.position;
        //Debug.Log("previousPosition" + previousPosition);
        yield return new WaitForSecondsRealtime(0.4f);

        goto marker;

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

    IEnumerator GameOverCoroutine()
    {

        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().enabled = false;
        GameObject.FindGameObjectWithTag("ScaredBGM").GetComponent<AudioSource>().enabled = false;
        //GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = "Press enter for main menu";

        //GameObject.FindGameObjectWithTag("Lose").GetComponent<AudioSource>().Play();


        if (GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text == "0")
        {
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "Mission Failed";
            GameObject.FindGameObjectWithTag("Lose").GetComponent<AudioSource>().Play();

            //Debug.Log(GameObject.FindGameObjectWithTag("Lose"));


        }


        else
        {
            GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "Mission Accomplished";
            GameObject.FindGameObjectWithTag("Win").GetComponent<AudioSource>().Play();


        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleSystem>().Stop();
        GameObject.FindGameObjectWithTag("EditorOnly").active = false;
        GameObject.FindGameObjectWithTag("ExplosionParticle").active = false;

        


        yield return null;
        // SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);



    }
}















