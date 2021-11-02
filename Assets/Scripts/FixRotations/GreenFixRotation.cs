using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFixRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        gameObject.transform.position =
            new Vector3(GameObject.FindGameObjectWithTag("GreenEnemy").transform.position.x + 0.1f,
                         GameObject.FindGameObjectWithTag("GreenEnemy").transform.position.y + 0.8f,
                         0);
    }
}
