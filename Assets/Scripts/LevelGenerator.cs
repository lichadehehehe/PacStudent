using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    // declare the map array
    public bool isCountingDown = false;

    public int[,] levelMap =
 {
 {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
 {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
 {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
 {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
 {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
 {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
 {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
 {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
 {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
 {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
 {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
 };


    public bool gameStart = false;

    void Awake()
    {

        GameObject.FindGameObjectWithTag("ICBMCountdown").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().enabled = false;
        StartCoroutine(MyCoroutine());

    }
    void Start()
    {
        //disable all manual map assets
        GameObject.Find("AllMapAssets").SetActive(false);
        
        //load the prefabs outside game camera
        GameObject coin = (GameObject)Instantiate(Resources.Load("coinPrefab"));
        GameObject roc = (GameObject)Instantiate(Resources.Load("rocPrefab"));
        GameObject wall = (GameObject)Instantiate(Resources.Load("wallPrefab"));

        //declare an empty gameobject
        GameObject nullObject = (GameObject)Instantiate(Resources.Load("emptyPrefab"));

        //set the initial coordinates of the top left asset
        float initialX = -5.456f;
        float initialY = 5.803f;
        //use a double for loop to generate the level map
        for (int outerLoop = 0; outerLoop <= levelMap.GetUpperBound(0); outerLoop++)
        {
            for (int innerLoop = 0; innerLoop <= levelMap.GetUpperBound(1); innerLoop++)
            {
                //for each next element in the levelMap array, increment the x coordinate by 0.4 and subtract the y coordinate by 0.4
                Instantiate(LevelTranslater(levelMap[outerLoop, innerLoop]),
                    new Vector3(initialX + innerLoop * 0.4f, initialY - outerLoop * 0.4f, 0), Quaternion.identity);
                //Debug.Log(LevelTranslater(levelMap[outerLoop, innerLoop]));
                //Debug.Log(levelMap[outerLoop, innerLoop]);
            }

        }

        
            //use a double for loop to generate the top right level map
            
        for (int outerLoop = 0; outerLoop <= levelMap.GetUpperBound(0); outerLoop++)
        {
            for (int innerLoop = levelMap.GetUpperBound(1); innerLoop >=0; innerLoop--)
            {
                //for each next element in the levelMap array, increment the x coordinate by 0.4 and subtract the y coordinate by 0.4
                Instantiate(LevelTranslater(levelMap[outerLoop, innerLoop]),
                    new Vector3(initialX - (innerLoop - levelMap.GetUpperBound(1)) * 0.4f + (levelMap.GetUpperBound(1) + 1) * 0.4f, 
                                initialY - outerLoop * 0.4f , 0), Quaternion.identity);
                //Debug.Log(LevelTranslater(levelMap[outerLoop, innerLoop]));
                //Debug.Log(levelMap[outerLoop, innerLoop]);
            }

        }
        

        //use a double for loop to generate the bottom left level map

        for (int outerLoop = levelMap.GetUpperBound(0) - 1; outerLoop >= 0; outerLoop--)
        {
            for (int innerLoop = 0; innerLoop <= levelMap.GetUpperBound(1); innerLoop++)
            {
                //for each next element in the levelMap array, increment the x coordinate by 0.4 and subtract the y coordinate by 0.4
                Instantiate(LevelTranslater(levelMap[outerLoop, innerLoop]),
                    new Vector3(initialX + innerLoop * 0.4f,
                                initialY + ((outerLoop + 1f) - levelMap.GetUpperBound(0)) * 0.4f - (levelMap.GetUpperBound(0) + 1) * 0.4f, 0), 
                                Quaternion.identity);
                //Debug.Log(LevelTranslater(levelMap[outerLoop, innerLoop]));
                //Debug.Log(levelMap[outerLoop, innerLoop]);
            }

        }

        //use a double for loop to generate the bottom right level map

        for (int outerLoop = levelMap.GetUpperBound(0) - 1; outerLoop >= 0; outerLoop--)
        {
            for (int innerLoop = levelMap.GetUpperBound(1); innerLoop >= 0; innerLoop--)
            {
                //for each next element in the levelMap array, increment the x coordinate by 0.4 and subtract the y coordinate by 0.4
                Instantiate(LevelTranslater(levelMap[outerLoop, innerLoop]),
                    new Vector3(initialX - (innerLoop - levelMap.GetUpperBound(1)) * 0.4f + (levelMap.GetUpperBound(1) + 1) * 0.4f,
                                initialY + ((outerLoop + 1f) - levelMap.GetUpperBound(0)) * 0.4f - (levelMap.GetUpperBound(0) + 1) * 0.4f, 0),
                                Quaternion.identity);
                //Debug.Log(LevelTranslater(levelMap[outerLoop, innerLoop]));
                //Debug.Log(levelMap[outerLoop, innerLoop]);
            }

        }


        //LevelTranslater() reads the 2d array of LevelMap and return a gameObject
        GameObject LevelTranslater(int levelInt)
        {

            switch (levelInt)
            {

                case 0:
                    return nullObject;


                case 1:
                case 2:
                case 3:
                case 4:
                case 7:
                    return wall;


                case 5:
                    return coin;


                case 6:
                    return roc;


                default:
                    return nullObject;

            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MyCoroutine()
    {

        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "3";
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "2";
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "1";
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("theTimer").GetComponent<UnityEngine.UI.Text>().text = "GO!";
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>().enabled = true;
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();


        gameStart = true;

    }



}
