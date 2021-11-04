using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    
    //declare the bgm if one of the ghosts is dead
    public AudioClip oneDeadAudio;
    
    public NavMeshAgent agent;
    //declare the original position of the ghosts 
    Vector3 tempPosition;


    private void Awake()
    {   
        //get the original posion of the ghosts by calling the tempposion in Awake()
        tempPosition = transform.position;   
    }
    

    // Update is called once per frame
    void Update()
    {

        //fix the transform.rotation
        transform.rotation = Quaternion.identity;
        
        //if the gamestart status is true
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().gameStart)
        {
            // if the ghosts are not the in scare state
            if (gameObject.GetComponent<Animator>().GetBool("Scared") == false)
            {   
                //chase the player
                ChasePlayer();
                //get the ghosttags by the tag
                GameObject[] ghostTags = GameObject.FindGameObjectsWithTag("UI");

                //fix all the tags transform.rotation
                foreach (GameObject i in ghostTags)
                {
                    i.transform.rotation = Quaternion.identity;

                }
            }

            //if the ghosts are in the scare state
            else if (gameObject.GetComponent<Animator>().GetBool("Scared") == true)
            {
                //do not chase the player, go away
                AvoidPlayer();
                //get the tags and fix the transform rotation
                GameObject[] ghostTags = GameObject.FindGameObjectsWithTag("UI");

                foreach (GameObject i in ghostTags)
                {
                    i.transform.rotation = Quaternion.identity;


                }

            }


        }
        
        

    }

    private void OnTriggerEnter(Collider other)
    {   
        //if the ghosts collides with the player and are not the in the scared state
        if (other.gameObject.CompareTag("Player") && gameObject.GetComponent<Animator>().GetBool("Scared") == false)
        {
            //disabled the collider of the ghosts temporarily
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //disalbed the collider of the player temporarily
            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
            //set the player animator to the dead state
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Dead");
            //emit dead explision particles
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(1000);
            //play the explosion sound
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();
            //stop the BGM temporarily
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();
            //start coroutine
            StartCoroutine(myCouroutine());

        }

        //if the ghost collides with the player while in the scared state
        if (other.gameObject.CompareTag("Player") && gameObject.GetComponent<Animator>().GetBool("Scared") == true)
        {
            //disabled the collider of the ghosts temporarily
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //set the ghost animator to the dead state
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            //emit dead explision particles
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(1000);
            //play the explosion sound
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();
            //play the new BGM because one ghosts is dead
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().clip = oneDeadAudio;
            //start destroyed coroutine
            StartCoroutine(destroyedCouroutine());


        }


    }

    // the coroutine while ghosts collides with player while in the normal state
    IEnumerator myCouroutine()
    {

        //disabled player input temporarily
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().isInputEnabled = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        // wait for 3 seconds
        yield return new WaitForSecondsRealtime(3f);
        
        //get the remaining lives by int.parse the UI.text of live indicator
        int livesLeft = int.Parse(GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text);
        //reduce one life
        livesLeft--;
        //update the remaining lives
        GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>().text = livesLeft.ToString();
        //initilize the player back to the original position
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-5.456f + 0.4f, 5.803f - 0.4f, 0);
        //set the state of the player to be in the normal state
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Left");
        //enabled user input
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().isInputEnabled = true;
        //resume the bgm playing
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();
        //enabled the box collider of the ghosts
        gameObject.GetComponent<BoxCollider>().enabled = true;
        //enabled the box collider of the player
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;

    }

    // the coroutine if the ghosts are dead
    IEnumerator destroyedCouroutine()
    {   

        //get the score by int.parse the score ui text
        int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
        //add 300 to the score and convert it to string
        count = count + 300;
        string countString = count.ToString();
        //update the new score
        GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = countString;

        //wait for 5 seconds
        yield return new WaitForSecondsRealtime(5f);
       
        //enabled the ghosts collider
        gameObject.GetComponent<BoxCollider>().enabled = true;
        //set the ghosts animator state to be in the normal state 
        gameObject.GetComponent<Animator>().ResetTrigger("Dead");
        gameObject.GetComponent<Animator>().SetTrigger("Undead");
        //set teh ghost animator state to not be in the scared state
        gameObject.GetComponent<Animator>().SetBool("Scared", false);

    }

    
    //chase player function
    private void ChasePlayer()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        
        //make the rockets always face the player
        float AngleRad = Mathf.Atan2(GameObject.FindGameObjectWithTag("Player").transform.position.y - gameObject.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

    }

    //avoid player function while the ghosts are in the scared state
    private void AvoidPlayer()
    {
        //get the ghosts back to the original position
        agent.SetDestination(tempPosition);

        //make the rockets always face the destination
        float AngleRad = Mathf.Atan2(tempPosition.y - gameObject.transform.position.y, tempPosition.x - gameObject.transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

           
    }
}
