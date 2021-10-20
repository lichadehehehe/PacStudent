using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]

public class PacStudentController : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameObject item;
    //private Tweener tweener;
    private List<GameObject> itemList;
    private LevelGenerator levelGenerator;
    int[,] levelMap;

    GameObject pacStudent;

    private Vector3 movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 1.5f;
    //int [,] levelMap = levelGenerator.getNumArray();

    //Animator anim;

    public AudioSource footStepSource;

    //Collision collision;
    Vector3 tempPosition;

    //public int collisionCounter = 0;

    //public int tempCounter = 0;

    //public bool collided = false;

    //float Xdistance = 0;

    //float Ydistance = 0;

    Vector3 previousPosition;


    //private float nextActionTime = 0.0f;
    //public float period = 1f;

    void Awake()
    {
        int[,] levelMap = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelGenerator>().levelMap;
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



        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Left");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Up");
            anim.ResetTrigger("Down");
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Down");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Up");
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Up");
            anim.ResetTrigger("Right");
            anim.ResetTrigger("Left");
            anim.ResetTrigger("Down");

        }



        GetMovementVector();
        CharacterPostion();
       
        FootstepAudio();
    }

   

    void GetMovementVector()
    {
       

        if (Input.GetAxis("Horizontal") > 0)
        {

            movement.x++;
           

        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            movement.x--;


        }

        if (Input.GetAxis("Vertical") > 0)
        {

            movement.y++;


        }

        if (Input.GetAxis("Vertical") < 0)
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
        if (tempPosition.x - previousPosition.x > 0.1 || tempPosition.y - previousPosition.y > 0.1)
        {
            if (!footStepSource.isPlaying)
            {

                footStepSource.Play();

                Debug.Log("moving");

            }

        }

        else if (tempPosition.x - previousPosition.x < 0.1 || tempPosition.y - previousPosition.y < 0.1)
        {
            if (footStepSource.isPlaying)
            {
                footStepSource.Stop();

                Debug.Log("not moving");

            }

        }

    }

    IEnumerator MyCoroutine()
    {

    marker:

        //yield return null;
        tempPosition = gameObject.transform.position;
        Debug.Log("tempPosition: " + tempPosition);
        yield return new WaitForSecondsRealtime(0.4f);
        previousPosition = gameObject.transform.position;
        Debug.Log("previousPosition" + previousPosition);
        yield return new WaitForSecondsRealtime(0.4f);

        goto marker;

    }
}















