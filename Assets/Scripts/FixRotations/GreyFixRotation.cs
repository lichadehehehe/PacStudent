using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyFixRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        gameObject.transform.position =
            new Vector3(GameObject.FindGameObjectWithTag("Enemy").transform.position.x + 0.2f,
                         GameObject.FindGameObjectWithTag("Enemy").transform.position.y + 0.8f,
                         0);
    }
}
