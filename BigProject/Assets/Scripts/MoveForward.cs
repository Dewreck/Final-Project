using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 7.0f;
    private float backBound = -15f;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    // this moves objects along the z axis while game is in play
        if(!playerControllerScript.gameOver)
        {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    // this destroys all moving objects that reach the back bound
        if(transform.position.z < backBound)
        {
            Destroy(gameObject);
        }

        if (playerControllerScript.gameTimer > 20f)
        {
            speed = 9f;
        }
        if (playerControllerScript.gameTimer > 35f && playerControllerScript.gameTimer < 35.1f)
        {
            speed = 11f;
        }
        if (playerControllerScript.gameTimer > 50f && playerControllerScript.gameTimer < 45.1f)
        {
            speed = 13f;
        }
        if (playerControllerScript.gameTimer > 65f)
        {
            speed = 15f;
        }
    }
}
