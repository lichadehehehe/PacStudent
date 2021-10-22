using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update
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

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Dead");
            GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>().Emit(1000);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();
            
            //ParticleSystem extraCollisionParticles = gameObject.GetComponent<ParticleSystem>();
            //AudioSource collosionSound = gameObject.GetComponent<AudioSource>();

            //extraCollisionParticles.Emit(500);

            //collosionSound.Play();
            //int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
            // count++;
            //string countString = count.ToString();

            //GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetTrigger("Scared");
            //GameObject.FindGameObjectWithTag("RedEnemy").GetComponent<Animator>().SetTrigger("Scared");
            // GameObject.FindGameObjectWithTag("GreenEnemy").GetComponent<Animator>().SetTrigger("Scared");
            // GameObject.FindGameObjectWithTag("BlueEnemy").GetComponent<Animator>().SetTrigger("Scared");

            StartCoroutine(myCouroutine());



            //GameObject.FindGameObjectWithTag("LevelUpBGM").GetComponent<AudioSource>().Play();

            //GameObject.FindGameObjectWithTag("ScaredBGM").GetComponent<AudioSource>().Play();


            // gameObject.transform.position = new Vector3(999, 999, 999);

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

    }
}
