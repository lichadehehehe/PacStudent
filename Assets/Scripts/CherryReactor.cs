using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryReactor : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {   
        // if the cherry collides with the player gameobject
        if (other.gameObject.CompareTag("Player"))
        {   
            //get the current score by int.parse the text string from the score ui text gameobject 
            int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
            //add 100 points
            count = count + 100;
            string countString = count.ToString();
            //update the score string
            GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = countString;
            //if the cherry is eaten, disabled the gameobject
            gameObject.active = false;

        }
    }
}
