using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   //start coroutine
        StartCoroutine(MyCoroutine());
    }

    
    IEnumerator MyCoroutine()
    {
        
    marker:

        //initiate missiles
        //set the missiles randomly above the screen and make them drop down due to gravity in rigidbody
        //missiles droped each 1.5f

        GameObject missile1 = (GameObject)Instantiate(Resources.Load("StartGreyGhost"));
        
        missile1.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(1.5f);

        
        GameObject missile2 = (GameObject)Instantiate(Resources.Load("StartBlueGhost"));
        missile2.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(1.5f);

        GameObject missile3 = (GameObject)Instantiate(Resources.Load("StartGreenGhost"));
        missile3.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(1.5f);
        GameObject missile4 = (GameObject)Instantiate(Resources.Load("StartRedGhost"));
        missile4.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(1.5f);

        //repeat the coroutine by goto marker
        goto marker;
    }
}
