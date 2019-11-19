using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBad : MonoBehaviour
{
    private float speed = 15f;
    public int rocketCount = 0;
    private CrosshairBehave crosshrScript;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        crosshrScript = GameObject.Find("Crosshairs").GetComponent<CrosshairBehave>();
    }

    // Update is called once per frame
    void Update()
    {
        // this moves projectile along the z axis and destroys it if it goes out of bounds
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 14f)
        {
            Destroy(gameObject);
            // this increases rocket count by one once destroyed
            crosshrScript.rocketCount ++;
        }

        
    }
    // this destroys both objects on collision with rocket and barrier
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            crosshrScript.rocketCount ++;
        }
        //this destroys both objects on collision with rocket and player and triggers gameover
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerControllerScript.gameOver = true;
            playerControllerScript.GameOverUI();
        }
    }
}
