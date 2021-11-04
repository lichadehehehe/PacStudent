using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPalletController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {   
        //if the normal pallet collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            //get the remaining score by int.parse the ui.text of score
            int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
            //add 1 score
            count ++;
            string countString = count.ToString();
            //update the score
            GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = countString;

            //disable the pallet if its eaten
            gameObject.active = false;

        }
    }
}
