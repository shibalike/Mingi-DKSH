using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    /*  Vector3 position;
      public float speed = 1.0f;

      int rightpress = 0;
      int leftpress = 0;
      int uppress = 0;
      int downpress = 0;

      void Start()
      {
        position = transform.position;
      }

      void Update()
      {


          if(Input.GetKeyDown("w"))
              uppress = 1;
          if(Input.GetKeyUp("w"))
              uppress = 0;

          if (Input.GetKeyDown("s"))
              downpress = 1;
          if (Input.GetKeyUp("s"))
              downpress = 0;

          if (Input.GetKeyDown("a"))
              leftpress = 1;
          if (Input.GetKeyUp("a"))
              leftpress = 0;

          if (Input.GetKeyDown("d"))
              rightpress = 1;
          if (Input.GetKeyUp("d"))
              rightpress = 0;

          if (uppress == 1)
              position.y += speed * Time.deltaTime;
          if(downpress == 1)
              position.y -= speed * Time.deltaTime;
          if(leftpress == 1)
              position.x -= speed * Time.deltaTime;
          if(rightpress == 1)
              position.x += speed * Time.deltaTime;
          transform.position = position;
      }*/

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
            velocity.y = speed;
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