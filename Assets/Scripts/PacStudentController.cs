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


    void Awake()
    {
        int[,] levelMap = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelGenerator>().levelMap;
        GameObject pacStudent = GameObject.FindGameObjectWithTag("Player");

        //get the initial position of the levelgenerator, make the pacstudent to the top left corner of the map

        Vector3 initialPacPosition = new Vector3(-5.456f + 0.4f, 5.803f - 0.4f, 0);
        pacStudent.transform.position = initialPacPosition;
        
        /*
        for (int outerLoop = 0; outerLoop <= levelMap.GetUpperBound(0); outerLoop++)
        {
            for (int innerLoop = 0; innerLoop <= levelMap.GetUpperBound(1); innerLoop++)
            {
                //for each next element in the levelMap array, increment the x coordinate by 0.4 and subtract the y coordinate by 0.4
                //Instantiate(LevelTranslater(levelMap[outerLoop, innerLoop]),
                    //new Vector3(initialX + innerLoop * 0.4f, initialY - outerLoop * 0.4f, 0), Quaternion.identity);
                //Debug.Log(LevelTranslater(levelMap[outerLoop, innerLoop]));
                //Debug.Log(levelMap[outerLoop, innerLoop]);
            }
        }
        */

    }
    void Start()
    {
        levelGenerator = GetComponent<LevelGenerator>();
        //tweener = GetComponent<Tweener>();
       // Debug.Log(tweener);
        //itemList = new List<GameObject>();
        //itemList.Add(item);

        //levelGenerator.levelMap

        
    }

    // Update is called once per frame
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
       // CharacterRotation();
    }

    /*
    private void LoopAddTween(string key)
    {
        bool added = false;
        GameObject pacStudent = GameObject.FindGameObjectWithTag("Player");
        //foreach (pacStudent)
        //{
        if (key == "a")
            {
                added = tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
                Debug.Log("a pressed");
            }
                
            if (key == "d")
            {
            added = tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
            }
            if (key == "s")
            {
            added = tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(0.0f, 0.5f, -2.0f), 0.5f);
            }
            if (key == "w")
            {
            added = tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(0.0f, 0.5f, 2.0f), 0.5f);
            }

            //if (added)
                //break;
        //}
    }

    
    private Vector3 levelPositionIndicator(int x, int y)
    {
        Vector3 thePosition = new Vector3();

        //thePosition = levelMap[x, y];



        return thePosition;
    }
    */

    void GetMovementVector()
    {
        //get the horizontal and vertical movement via the input
        //movement.x = Input.GetAxis("Horizontal") ;
        //movement.z = Input.GetAxis("Vertical");
        
        if (Input.GetAxis("Horizontal") > 0)
        {

            movement.x++;
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            
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
        //move the character to the desire posision 
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
    }



    void CharacterRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }



}
