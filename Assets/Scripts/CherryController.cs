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
    
    marker:


        GameObject cherry = (GameObject)Instantiate(Resources.Load("AmericanOil"));
        
        int[,] levelMap = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelGenerator>().levelMap;

        cherry.transform.position = new Vector3(Random.Range(-5.456f, -5.456f + levelMap.GetUpperBound(1) * 0.4f), 5.803f + 1, 0f);

    


        yield return new WaitForSecondsRealtime(20f);
        //Instantiate(cherry, new Vector3(initialX + Random.Range(0, Screen.width), initialY + Random.Range(0, Screen.height), 0), Quaternion.identity);

        //cherry.transform.position = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0);

       // tweener.AddTween(cherry.transform, new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0 ), throughCenterScreenTilEndPoint, 1.5f);

        //cherry.transform.position =
             //Vector3.MoveTowards(cherry.transform.position, throughCenterScreenTilEndPoint, 2.0f * Time.deltaTime);

        //yield return new WaitForSecondsRealtime(5f);

        goto marker;

    }

    
}
