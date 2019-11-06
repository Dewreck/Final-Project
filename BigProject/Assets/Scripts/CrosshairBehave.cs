using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehave : MonoBehaviour
{
    public float speed;
    private Rigidbody crossHrRb;
    private GameObject player;

    private float yBoundUp = 1.9f;
    private float yBoundDown = 0.1f;
    private float xBound = 1.9f;

    public GameObject rocket;
    private Vector3 spawnPos;
    public int rocketCount = 0;

    public float fireRate = 0.3f;
    public float nextFire;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        crossHrRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!playerControllerScript.gameOver)
        {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        crossHrRb.AddForce(lookDirection * speed);
        }
        

        Bounding();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            spawnPos = new Vector3(transform.position.x,transform.position.y,-20.0f);
            Debug.Log("Locked On");
            Instantiate(rocket, spawnPos, rocket.transform.rotation);
        }
    }

    void Bounding()
    {
        if(transform.position.y > yBoundUp)
        {
            transform.position = new Vector3(transform.position.x, yBoundUp, transform.position.z);
        }
        if(transform.position.y < yBoundDown)
        {
            transform.position = new Vector3(transform.position.x, yBoundDown, transform.position.z);
        }
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }
}
