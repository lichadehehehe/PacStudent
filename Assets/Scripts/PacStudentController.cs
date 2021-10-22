using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
       
        FootstepAudio();
        //ParticleManagement();
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


    void ParticleManagement()
    {
        ParticleSystem extraCollisionParticles = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<ParticleSystem>();
        AudioSource collosionSound = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<AudioSource>();


        if (tempPosition.x - previousPosition.x < 0.00000001 && tempPosition.y - previousPosition.y < 0.00000001)
        {

            extraCollisionParticles.Emit(500);
            Debug.Log("start collision emition");

            if (!collosionSound.isPlaying)
            {

                collosionSound.Play();


            }
            

        }

        //else //if (tempPosition.x - previousPosition.x >= 0.00001 || tempPosition.y - previousPosition.y >= 0.00001)
       // {

            //extraCollisionParticles.Stop();
            //Debug.Log("stop collision emition");
            //collosionSound();
       // }

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
}















