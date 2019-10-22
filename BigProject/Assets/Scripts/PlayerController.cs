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
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // allows player to move left/right
        if(gameOver == false)
        {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
    // allows player to jump to the ceiling
        if(Input.GetKeyDown(KeyCode.W) && gameOver == false)
        {
            transform.position = new Vector3(transform.position.x, ceilingPos, transform.position.z);
        }
    // allows player to jump to the floor
        if(Input.GetKeyDown(KeyCode.S) && gameOver == false)
        {
            transform.position = new Vector3(transform.position.x, floorPos, transform.position.z);
        }
    // bounds player on the left
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    // bounds player on the right
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
    // triggers a Game Over on barrier collision
        if(collision.gameObject.CompareTag("Barrier"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        } 
    // triggers Game over and Player destruction on hazard collision    
        if(collision.gameObject.CompareTag("Hazard"))
        {
            gameOver = true;
            Debug.Log("Ouch!");
            Destroy(gameObject);
        }
    }

    
}
