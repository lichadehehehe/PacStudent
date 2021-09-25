using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] item;
    public Tweener tweener;

    //public List<GameObject> itemList;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        //itemList.Add(item[0]);

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject gameItem = item[0];
        /*if (Input.GetKeyDown("a"))
        {
            //Debug.Log("A pressed");
            Vector3 endPos = new Vector3 (-2.0f, 0.5f, 0.0f);
            //foreach(GameObject tweenItem in itemList)
            //{

                
                    //tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 1.5f);
                
              
                if (tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 1.5f))
                //{
                    //Debug.Log("tween added");
                   // break;
                    
              //  }
                /*
                else
                {
                    Debug.Log("Do nothing");

                }
               
            }
           


        }
        if (Input.GetKeyDown("d"))
        {
            Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            foreach (GameObject tweenItem in itemList)
            {

                //tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 1.5f);

                if (tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 1.5f))
                {

                    break;

                }

                else
                {



                }


            }

        }

        if (Input.GetKeyDown("s"))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            foreach (GameObject tweenItem in itemList)
            {
                //tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 0.5f);

                if (tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 0.5f))
                {

                    break;


                }

                else
                {



                }
            }
        }

        if (Input.GetKeyDown("w"))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            foreach (GameObject tweenItem in itemList)
            {

                //tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 0.5f);

                if (tweener.AddTween(tweenItem.transform, tweenItem.transform.position, endPos, 0.5f))
                {

                    break;

                }
                else
                {




                }
            }
                   


        }
        
        */
        /*
        if (Input.GetKeyDown("a"))
        {
        */
            Vector3 endPos = new Vector3(-2.0f, 0.5f, 0.0f);
            tweener.AddTween(item[0].transform, item[0].transform.position, endPos, 1.5f);


        //}
        //if (Input.GetKeyDown("d"))
        //{
            //Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            tweener.AddTween(item[0].transform, item[0].transform.position, endPos, 1.5f);


        //}

        //if (Input.GetKeyDown("s"))
        //{
            //Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            tweener.AddTween(item[0].transform, item[0].transform.position, endPos, 0.5f);


        //}

        //if (Input.GetKeyDown("w"))
        //{
            //Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            tweener.AddTween(item[0].transform, item[0].transform.position, endPos, 0.5f);


        //}
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone;
            //GameObject cloneItem = item[0];
            Vector3 clonePosition = new Vector3(0f, 0.5f, 0f);
            Quaternion cloneRotation = new Quaternion(0, 0, 0, 0);
            clone = Instantiate(item[0], clonePosition, cloneRotation);
            
            itemList.Add(clone);

        }
        */
    }
}
