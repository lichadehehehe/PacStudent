using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip oneDeadAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
