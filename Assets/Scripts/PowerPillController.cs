using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPillController : MonoBehaviour
{

    //public AudioClip scaredClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator myCouroutine()
    {
            GameObject[] taggedPalletGameObject = GameObject.FindGameObjectsWithTag("Tagging");

        foreach(GameObject tagged in taggedPalletGameObject)
        {


            tagged.SetActive(false);

        }


            gameObject.tag = "Tagging";
    
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().enabled = true;
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "10";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "9";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "8";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "7";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "6";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "5";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "4";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "3";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "2";
            yield return new WaitForSecondsRealtime(1f);
            GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().text = "1";
            yield return new WaitForSecondsRealtime(1f); 
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("RedEnemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("GreenEnemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("BlueEnemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().enabled = false;
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();

        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("EatenScared");
            //ParticleSystem extraCollisionParticles = gameObject.GetComponent<ParticleSystem>();
            //AudioSource collosionSound = gameObject.GetComponent<AudioSource>();

            //extraCollisionParticles.Emit(500);

            //collosionSound.Play();
            //int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
            // count++;
            //string countString = count.ToString();

            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("RedEnemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("GreenEnemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("BlueEnemy").GetComponent<Animator>().SetBool("Scared", true);

            StartCoroutine(myCouroutine());



            GameObject.FindGameObjectWithTag("LevelUpBGM").GetComponent<AudioSource>().Play();

            GameObject.FindGameObjectWithTag("ScaredBGM").GetComponent<AudioSource>().Play();


            gameObject.transform.position = new Vector3 (999,999,999);

        }
    }
}
