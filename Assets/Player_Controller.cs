using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Vector3 velocity;
    public Rigidbody2D rb;
    public float speed = 5.0f;

    private void Start()
    {
        velocity = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            velocity.y = speed;
        }
            
        if (Input.GetKeyUp("w"))
            velocity.y = 0;

        if (Input.GetKeyDown("s"))
            velocity.y = -1 * speed;
        if (Input.GetKeyUp("s"))
            velocity.y = 0;

        if (Input.GetKeyDown("a"))
            velocity.x = -1 * speed;
        if (Input.GetKeyUp("a"))
            velocity.x = 0;

        if (Input.GetKeyDown("d"))
            velocity.x = speed;
        if (Input.GetKeyUp("d"))
            velocity.x = 0;
        rb.velocity = velocity;
    }
}