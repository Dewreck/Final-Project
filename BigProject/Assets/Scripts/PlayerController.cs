using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    public GameObject projectile;
    public GameObject crossHairs;

    public float playerHealth = 2f;
    
    // public float spinSpeed = 50f;
    public float horizontalInput;
    public float ceilingPos = 1.5f;
    public float floorPos = 0.5f;
    public float xBound = 2.1f;
    public bool gameOver = false;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

    public float gameTimer;

    private CrosshairBehave crosshrScript;
    // Start is called before the first frame update
    void Start()
    {
        crosshrScript = GameObject.Find("Crosshairs").GetComponent<CrosshairBehave>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerBounding();
        HealthDrain();

        gameTimer += Time.deltaTime * 1f;
        
        Crosshairs();

        

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && playerHealth > .6f)
        {
            nextFire = Time.time + fireRate;
            playerHealth -= .2f;
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }

    void HealthDrain()
    {
        if (!gameOver)
        {
        playerHealth -= Time.deltaTime * .1f;
        }

        if (playerHealth < .6f)
        {
            Debug.Log("Battery Low");
        }
        if (playerHealth < 0.0f)
        {
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("No Battery");
        }

        if (playerHealth > 2)
        {
            playerHealth = 2f;
        }
    }

    void PlayerMovement()
    {
    // allows player to move left/right
        if(!gameOver)
        {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
    // allows player to jump to the ceiling
        if(Input.GetKeyDown(KeyCode.W) && !gameOver)
        {
            transform.position = new Vector3(transform.position.x, ceilingPos, transform.position.z);
        }
    // allows player to jump to the floor
        if(Input.GetKeyDown(KeyCode.S) && !gameOver)
        {
            transform.position = new Vector3(transform.position.x, floorPos, transform.position.z);
        }
    }

    void PlayerBounding()
    {
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

    void Crosshairs()
    {
        if(gameTimer > 30f && gameTimer < 40f)
        {
            crossHairs.gameObject.SetActive(true);
        }else
        {
            crossHairs.gameObject.SetActive(false);
        }

        if (gameOver == true)
        {
            crossHairs.gameObject.SetActive(false);
        }
    }
    
}
