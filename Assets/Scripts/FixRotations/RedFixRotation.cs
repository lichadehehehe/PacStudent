using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFixRotation : MonoBehaviour
{
    

    void Update()
    {
        gameObject.transform.position =
            new Vector3(GameObject.FindGameObjectWithTag("RedEnemy").transform.position.x + 0.1f,
                         GameObject.FindGameObjectWithTag("RedEnemy").transform.position.y + 0.8f,
                         0); 
    }
    
}
