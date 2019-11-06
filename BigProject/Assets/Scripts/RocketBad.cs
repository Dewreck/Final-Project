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
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 14f)
        {
            Destroy(gameObject);
            crosshrScript.rocketCount ++;
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            crosshrScript.rocketCount ++;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerControllerScript.gameOver = true;
        }
    }
}
