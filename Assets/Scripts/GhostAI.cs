using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    Rigidbody rb;

    // movement speed
    [SerializeField] float speed;

    // possible movent directions
    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 0;

    // doesn't have to be serialized
    [SerializeField] Vector2 currentDir;

    // how far to look ahead
    [SerializeField] float rayDistance;

    // which layers to raycast for
    [SerializeField] LayerMask rayLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start moving in a directions
        currentDir = directions[directionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // raycast
        RaycastHit hitInfo;
        //bool hit = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        bool hit = Physics.Raycast(transform.position, currentDir, out hitInfo, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        // visably debug the ray
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        // if walls and pacman layer are selected, will return true for either
        if (hit)
        {
            Debug.Log("hit");
            Debug.Log(hitInfo.collider.gameObject);
            // check if wall ahead
            if (hitInfo.collider.gameObject.CompareTag("Impassable"))
            {
                ChangeDirection();
                Debug.Log("Wall hit");
            }

            // check if pacman ahead
            if (hitInfo.collider.gameObject.CompareTag("PacMan"))
            {
                // deal damage;
                print("pacman ahead!");
            }



        }
    }


    void ChangeDirection()
    {
        // randomly select between -1 and 1;
        directionIndex += Random.Range(0, 2) * 2 - 1;

        // keeps index from exceeding 3
        int clampedIndex = directionIndex % directions.Length;

        // keep index positive
        if (clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        // temporary freeze movement before set the new direction
        rb.velocity = Vector2.zero;

        // set the current direction from the directions array
        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {
        // move in current direction
        rb.AddForce(currentDir * speed);
    }
}