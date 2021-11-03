using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MyCoroutine()
    {
        
    marker:


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

        goto marker;
    }
}
