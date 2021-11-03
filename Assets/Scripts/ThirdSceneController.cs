using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSceneController : MonoBehaviour
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    marker:


        GameObject missile1 = (GameObject)Instantiate(Resources.Load("GreyGhost"));

        missile1.transform.position = new Vector3(0, 5.803f + 1, 0f);
        //missile1.GetComponent<Rigidbody>().AddForce( player.transform.position * 200f);

        yield return new WaitForSecondsRealtime(5f);



        GameObject missile2 = (GameObject)Instantiate(Resources.Load("BlueGhost"));
        missile2.transform.position = new Vector3(0, 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);

        GameObject missile3 = (GameObject)Instantiate(Resources.Load("GreenGhost"));
        missile3.transform.position = new Vector3(0, 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);
        GameObject missile4 = (GameObject)Instantiate(Resources.Load("RedGhost"));
        missile4.transform.position = new Vector3(0, 5.803f + 1, 0f);

        yield return new WaitForSecondsRealtime(5f);

        goto marker;
    }
}
