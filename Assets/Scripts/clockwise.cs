using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockwise : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 point3 = new Vector3(-5.09f, 3.83f, 0f);
    Vector3 point2 = new Vector3(-5.09f, 5.41f, 0f);
    Vector3 point1 = new Vector3(-0.7f, 5.41f, 0f);
    Vector3 point0 = new Vector3(-0.7f, 3.83f, 0f);

    Vector3 rotation0 = new Vector3(0f, 0f, 90f);
    Vector3 rotation1 = new Vector3(0f, 0f, 0f);
    Vector3 rotation2 = new Vector3(0f, 0f, 270f);
    Vector3 rotation3 = new Vector3(0f, 0f, 180f);
    

    int nextPointIndex = 0;
    int nextRotationIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] points = { point3, point2, point1, point0 };
        
        Vector3[] rotations = { rotation0, rotation1, rotation2, rotation3 };
        var reachedNextPoint = transform.position == points[nextPointIndex];

        if (reachedNextPoint)
        {
            nextPointIndex++;
            nextRotationIndex++;
            if (nextPointIndex >= points.Length)
            {
                nextPointIndex = 0;
                nextRotationIndex = 0;
            }
        }

        // transform.position = Vector3.MoveTowards(transform.position, points[nextPointIndex], speed * Time.deltaTime);

        transform.position =
             Vector3.MoveTowards(transform.position, points[nextPointIndex], 2.0f * Time.deltaTime);
        Debug.Log(nextPointIndex);
        transform.Rotate(rotations[nextRotationIndex]);
        Debug.Log(nextRotationIndex);
        Debug.Log(rotations[nextRotationIndex]);
    }
}
