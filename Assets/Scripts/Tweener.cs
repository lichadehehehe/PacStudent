using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Tweener : MonoBehaviour
{
    public Tween activeTween;
    Vector3 point3 = new Vector3(-5.09f, 3.9f, 0f);
    Vector3 point2 = new Vector3(-5.09f, 5.41f, 0f);
    Vector3 point1 = new Vector3(-0.7f, 5.41f, 0f);
    Vector3 point0 = new Vector3(-0.7f, 3.9f, 0f);

    
    private int nextPointIndex = 0;
    //public List<Tween> activeTweens = new List <Tween>();
    void Start()
    {
        //AddTween();
    }

    // Update is called once per frame
    void Update()
    {


        //foreach (Tween debug in activeTweens)
        //Debug.Log(debug);
        //float EndPosX = Tween.EndPos.right;
        //int listLength = activeTweens.Count;
        //foreach (Tween activeTween in activeTweens.ToList())
        //{
        /*
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) >0.1f)
            {
                activeTween.Target.position =
                Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, easeInCubic((Time.time - activeTween.StartTime) / activeTween.Duration));
                //Debug.Log("object moved");
                //activeTweens.Remove(activeTween);
            }

            else
            {


                activeTween.Target.position = activeTween.EndPos;
            //Debug.Log("object not moved");
            //activeTweens.Remove(activeTween);
            activeTween = null;
            }

        */






        //moveLeft();
        //moveUp();
        //moveRight();
        //moveDown();



        // Vector3 point3 = new Vector3(-5.09f, 3.9f, 0);
        //activeTween.Target.position =
        //     Vector3.Lerp(activeTween.StartPos, point3, (Time.time - activeTween.StartTime) / activeTween.Duration);



       



}

    public void AddTween(Transform targetObject, Vector3 StartPos, Vector3 EndPos, float duration)
    {

        // for pre-100 band
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, StartPos, EndPos, Time.time, duration);

        }
        

        //TweenExists(targetObject);
        /* i gave up trying on the 100 band
        if (!TweenExists(targetObject))
        {

            activeTweens.Add(new Tween(targetObject, StartPos, EndPos, Time.time, duration));
            //Debug.Log("object moved");
            return true;
            
        }

        else
        {
            //Debug.Log("object not moved");
            return false;

            
        }

        //return false;
        */
    }

    public float easeInCubic(float x)
        {
           return x * x * x;
        }

    

    

    public void moveLeft()
    {
        Vector3 point3 = new Vector3(-5.09f, 3.9f, 0);
        activeTween.Target.position =
               Vector3.Lerp(activeTween.StartPos, point3, (Time.time - activeTween.StartTime) / activeTween.Duration);

    }

    public void moveUp()
    {
        Vector3 point2 = new Vector3(-5.09f, 5.41f, 0);
        activeTween.Target.position =
               Vector3.Lerp(activeTween.StartPos, point2, (Time.time - activeTween.StartTime) / activeTween.Duration);

    }

    public void moveRight()
    {
        Vector3 point1 = new Vector3(-0.7f, 5.41f, 0f);
        activeTween.Target.position =
               Vector3.Lerp(activeTween.StartPos, point1, (Time.time - activeTween.StartTime) / activeTween.Duration);

    }

    public void moveDown()
    {
        Vector3 point0 = new Vector3(-0.7f, 3.9f, 0f);
        activeTween.Target.position =
               Vector3.Lerp(activeTween.StartPos, point0, (Time.time - activeTween.StartTime) / activeTween.Duration);

    }

    /*
    public bool TweenExists(Transform target)
    {
        //int listLength = activeTweens.Count;

        //bool value;
        //foreach(Tween tweenObject in activeTweens)
        //{

        List<Transform> transformList = new List<Transform>();
        
        foreach(Tween tweenObject in activeTweens)
        {
            transformList.Add(tweenObject.Target);
            //Debug.Log(tweenObject.Target);
            //Debug.Log(tweenObject);
            //Debug.Log(transformList[0]);

        }

            if (transformList.Contains(target))
            {
            //issue transformlist is not appended
            //issue is now solved
            Debug.Log(transformList[0]);
            Debug.Log(target);
            Debug.Log("true");
            return true;
            

            }

            else
            {
            //Debug.Log(transformList[0]);
            //Debug.Log(target);
            Debug.Log("false");
            return false;
            }

            //return value;

        //}
            
            //return value;
       
    }
    */
}
