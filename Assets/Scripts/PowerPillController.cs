using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPillController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {   
        //if the player eat the power pallet
        if (other.gameObject.CompareTag("Player"))
        {
            
            //set all the enemies into the scared state
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("RedEnemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("GreenEnemy").GetComponent<Animator>().SetBool("Scared", true);
            GameObject.FindGameObjectWithTag("BlueEnemy").GetComponent<Animator>().SetBool("Scared", true);

            //start the coroutine
            StartCoroutine(myCouroutine());


            //play the levelup and scared bgm
            //scared bgm is the Reclaim the Mainland
            GameObject.FindGameObjectWithTag("LevelUpBGM").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("ScaredBGM").GetComponent<AudioSource>().Play();

            //make the powerpallet disapear away from game view
            gameObject.transform.position = new Vector3 (999,999,999);

        }
    }


    IEnumerator myCouroutine()
    {   
        //the follwing code is to avoid more than one "scare state ghost" function is called
        //powerpallet function is enabled one at a time
        //if a powerpallet is eaten while another powerpallet eaten less than 10 seconds before, the function will be reset 
        GameObject[] taggedPalletGameObject = GameObject.FindGameObjectsWithTag("Tagging");

        foreach (GameObject tagged in taggedPalletGameObject)
        {

            tagged.SetActive(false);

        }


        gameObject.tag = "Tagging";

        //stop the BGM
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();

        //enabled the countdown and count from 10 to 0
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

        //resume all the ghosts to the normal state
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("RedEnemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("GreenEnemy").GetComponent<Animator>().SetBool("Scared", false);
        GameObject.FindGameObjectWithTag("BlueEnemy").GetComponent<Animator>().SetBool("Scared", false);

        //disable countdown ui.text
        GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().enabled = false;

        //resume the bgm
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();


    }
}
