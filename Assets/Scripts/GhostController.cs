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
                GameObject[] ghostTags = GameObject.FindGameObjectsWithTag("UI");

                foreach (GameObject i in ghostTags)
                {
                    i.transform.rotation = Quaternion.identity;


                }
            }

            else if (gameObject.GetComponent<Animator>().GetBool("Scared") == true)
            {

                AvoidPlayer();
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

    

    private void ChasePlayer()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        

            float AngleRad = Mathf.Atan2(GameObject.FindGameObjectWithTag("Player").transform.position.y - gameObject.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

          
        
    }

    private void AvoidPlayer()
    {

        agent.SetDestination(tempPosition);

        

            float AngleRad = Mathf.Atan2(tempPosition.y - gameObject.transform.position.y, tempPosition.x - gameObject.transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

           


    }
}
