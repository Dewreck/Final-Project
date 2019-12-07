using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RocketBad : MonoBehaviour
{
    private float speed = 15f;
    private CrosshairBehave crosshrScript;
    private PlayerController playerControllerScript;
    public ParticleSystem rocketBoom;
    public AudioClip rocketFlyby;
    private AudioSource rocketAudio;
    private AudioManager audioManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rocketAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        crosshrScript = GameObject.Find("Crosshairs").GetComponent<CrosshairBehave>();
        audioManagerScript = GameObject.Find("Main Camera").GetComponent<AudioManager>();
        rocketAudio.PlayOneShot(rocketFlyby, 0.2f);
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
            
        }

        
    }
    // this destroys both objects on collision with rocket and barrier
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        { 
            Instantiate(rocketBoom, transform.position, rocketBoom.transform.rotation);
            audioManagerScript.RocketHitSound();
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
        //this destroys both objects on collision with rocket and player and triggers gameover
        if (other.gameObject.CompareTag("Player"))
        {
            playerControllerScript.gameOver = true;
            Destroy(gameObject);
            audioManagerScript.RocketHitSound();
            playerControllerScript.GameOverExplode();
            playerControllerScript.GameOverUI();   
        }
    }

}
