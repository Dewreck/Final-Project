using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //This script controls the behavior of the playermade laser projectiles

    public float speed = 15f;
    public ParticleSystem laserBlast;
    private AudioManager audioManagerScript;
   

    // Start is called before the first frame update
    void Start()
    {
        audioManagerScript = GameObject.Find("Main Camera").GetComponent<AudioManager>();
        audioManagerScript.ProjectileShootSound();
    }

    // Update is called once per frame
    void Update()
    {
        // this moves projectile along the z axis and destroys it if it goes out of bounds
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 14f)
        {
            Destroy(gameObject);
        }
        
        
    }

    //this destroys both projectile and barrier object on collision
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Instantiate(laserBlast, transform.position, laserBlast.transform.rotation);
            audioManagerScript.ProjectileHitSound();
            Destroy(gameObject);
            Destroy(other.gameObject); 
             
        }
    }

    
}
