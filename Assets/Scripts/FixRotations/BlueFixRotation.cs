using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFixRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        gameObject.transform.position =
            new Vector3(GameObject.FindGameObjectWithTag("BlueEnemy").transform.position.x - 0.6f,
                         GameObject.FindGameObjectWithTag("BlueEnemy").transform.position.y + 0.8f,
                         0);
    }
}
