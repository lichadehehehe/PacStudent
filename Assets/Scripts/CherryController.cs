using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    

    void Start()
    {
        // declare to start the coroutine in start()
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    
    IEnumerator MyCoroutine()
    {   //wait for 5 seconds
        yield return new WaitForSecondsRealtime(5f);
    marker:

        //initiate the cherry
        GameObject cherry = (GameObject)Instantiate(Resources.Load("AmericanOil"));
        
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;
        //randomly generate the cherry position based on the levelmap
        cherry.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + levelMap.GetUpperBound(1) * 0.4f), 5.803f + 1, 0f);

        //wait for 20 seconds, then repeat by goto marker command
        yield return new WaitForSecondsRealtime(20f);
        

        goto marker;

    }

    
}
