using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject cherry;

    //float initialX = -5.456f;
    //float initialY = 5.803f;

    Vector3 upperLeftScreen = new Vector3(0, Screen.height, 0);
    Vector3 upperRightScreen = new Vector3(Screen.width, Screen.height, 0);
    Vector3 lowerLeftScreen = new Vector3(0, 0, 0);
    Vector3 lowerRightScreen = new Vector3(Screen.width, 0, 0);
    Vector3 throughCenterScreenTilEndPoint = new Vector3(Screen.width / 2 + 20 , Screen.height / 2 + 20 , 0);

    private Tweener tweener;

    void Awake()
    {
        

    }


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
        yield return new WaitForSecondsRealtime(5f);
    marker:

        
        GameObject cherry = (GameObject)Instantiate(Resources.Load("AmericanOil"));
        
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;

        cherry.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + levelMap.GetUpperBound(1) * 0.4f), 5.803f + 1, 0f);

    


        yield return new WaitForSecondsRealtime(20f);
        

        goto marker;

    }

    
}
