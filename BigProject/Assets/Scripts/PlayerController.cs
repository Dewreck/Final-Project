using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    // public float spinSpeed = 50f;
    public float horizontalInput;
    public float ceilingPos = 1.5f;
    public float floorPos = 0.5f;
    public float xBound = 2.1f;
    public float flipRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, ceilingPos, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, floorPos, transform.position.z);
        }

        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        // if(Input.GetKeyDown(KeyCode.R))
        // {
            
        //    transform.rotation.z = 180;
        // }
    }

    // void Flip()
    // {
    //     transform.Rotate(Vector3.forward * Time.deltaTime * spinSpeed);

    //     if(transform.rotation.z < 180)
    //     {
    //         Flip();
    //     }
    // }
}
