using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip oneDeadAudio;

    private Vector3 movement;

    private float movementSqrMagnitude;
    //public float walkSpeed = 1.5f;

    bool initialStatus = true;

    public NavMeshAgent agent;

    Vector3 tempPosition;

    // public LayerMask whatIsGround, whatIsPlayer;
    // public LayerMask whatIsGround, whatIsPlayer;

    private void Awake()
    {
        tempPosition = transform.position;   
    }
    

    // Update is called once per frame
    void Update()
    {


        transform.rotation = Quaternion.identity;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().gameStart)
        {

            if (gameObject.GetComponent<Animator>().GetBool("Scared") == false)
            {
                ChasePlayer();

            }

            else if (gameObject.GetComponent<Animator>().GetBool("Scared") == true)
            {

                AvoidPlayer();


            }


        }
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.GetComponent<Animator>().GetBool("Scared") == false)
        {
            Debug.Log("playerNuked");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Dead");
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(1000);
          
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();
            
          

            StartCoroutine(myCouroutine());


        }

        if (other.gameObject.CompareTag("Player") && gameObject.GetComponent<Animator>().GetBool("Scared") == true)
        {
            Debug.Log("ICBMDestroyed");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
         
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(1000);

            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().clip = oneDeadAudio;
            



            StartCoroutine(destroyedCouroutine());


        }


    }

    IEnumerator myCouroutine()
    {

        //Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().isInputEnabled = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return new WaitForSecondsRealtime(3f);
        //Time.timeScale = 1;
        //SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        int livesLeft = int.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text);
        livesLeft--;
        GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text = livesLeft.ToString();
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-5.456f + 0.4f, 5.803f - 0.4f, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Left");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().isInputEnabled = true;
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();
        gameObject.GetComponent<BoxCollider>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;

    }

    IEnumerator destroyedCouroutine()
    {
        int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
        count = count + 300;
        string countString = count.ToString();

        GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = countString;

        yield return new WaitForSecondsRealtime(5f);
       
       
       
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<Animator>().ResetTrigger("Dead");
        gameObject.GetComponent<Animator>().SetTrigger("Undead");
        //gameObject.GetComponent<Animator>().ResetTrigger("Undead");
        gameObject.GetComponent<Animator>().SetBool("Scared", false);

    }

    void GetMovementVector()
    {
        
        // first ghost grey
        if (gameObject.tag == "Enemy")
        {
            if (initialStatus)
            movement.y++;

            /*
            void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.CompareTag("Impassable") && gameObject.GetComponent<Animator>().GetBool("Scared") == false) ;

            }

            */
            
            if (GameObject.FindGameObjectWithTag("GreyFront").GetComponent<HitDetecter>().hit == true)
            {
                initialStatus = false;

                if (GameObject.FindGameObjectWithTag("GreyLeft").GetComponent<HitDetecter>().hit == true)
                {

                    gameObject.transform.Rotate(0.0f, 0.0f, 270.0f, Space.Self);
                    Debug.Log("Lefthit");
                    movement.x--;


                }

                if (GameObject.FindGameObjectWithTag("GreyRight").GetComponent<HitDetecter>().hit == true)
                {

                    gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    Debug.Log("Righthit");
                    movement.x++;

                }

                if (GameObject.FindGameObjectWithTag("GreyLeft").GetComponent<HitDetecter>().hit == true && 
                    GameObject.FindGameObjectWithTag("GreyRight").GetComponent<HitDetecter>().hit == true)
                {

                    gameObject.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
                    Debug.Log("BothHit");
                    movement.y--;
                }

                else
                {
                    
                    int caseNumber = Random.Range(1, 3);
                    Debug.Log("BothHit");

                    if (caseNumber == 1)
                    {

                        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);

                        Debug.Log("RandomLeft");
                        movement.x--;

                    }

                    else
                    {

                        gameObject.transform.Rotate(0.0f, 0.0f, 270.0f, Space.Self);
                        Debug.Log("RandomRight");
                        movement.x++;
                    }

                }



            }
            


        }

        //second ghost red
        if (gameObject.tag == "RedEnemy")
        {


            if (initialStatus)
                movement.x--;


        }

        //third ghost green
        if (gameObject.tag == "GreenEnemy")
        {
            if (initialStatus)
                movement.y++;


        }

        //fourth ghost blue 
        if (gameObject.tag == "BlueEnemy")
        {
            if (initialStatus)
                movement.y--;


        }
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movementSqrMagnitude = movement.sqrMagnitude;
    }

    /*
    void CharacterPostion()
    {

        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

    }
    */

    private void ChasePlayer()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        GameObject [] renderes = GameObject.FindGameObjectsWithTag("RocketRender");

        foreach (GameObject i in renderes)
        {
            //
            //
            //i.transform.LookAt(new Vector3(0, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z));
            //i.transform.rotation = new Vector3(0f, 0f, 8f);

            float AngleRad = Mathf.Atan2(GameObject.FindGameObjectWithTag("Player").transform.position.y - i.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.x - i.transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            i.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

           // Debug.Log("rotate");


        }
        
    }

    private void AvoidPlayer()
    {

        agent.SetDestination(tempPosition);

        GameObject[] renderes = GameObject.FindGameObjectsWithTag("RocketRender");

        foreach (GameObject i in renderes)
        {
            //
            //
            //i.transform.LookAt(new Vector3(0, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z));
            //i.transform.rotation = new Vector3(0f, 0f, 8f);

            float AngleRad = Mathf.Atan2(tempPosition.y - i.transform.position.y, tempPosition.x - i.transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            i.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

           // Debug.Log("rotateHome");


        }


    }
}
