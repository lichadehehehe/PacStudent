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


        GameObject missile1 = (GameObject)Instantiate(Resources.Load("GreyGhost"));

        missile1.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);


        
        GameObject missile2 = (GameObject)Instantiate(Resources.Load("BlueGhost"));
        missile2.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);

        GameObject missile3 = (GameObject)Instantiate(Resources.Load("GreenGhost"));
        missile3.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);
        GameObject missile4 = (GameObject)Instantiate(Resources.Load("RedGhost"));
        missile4.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + 14 * 0.4f), 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);

        goto marker;
    }
}
