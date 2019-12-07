using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    public GameObject projectile;
    public GameObject crossHairs;
    public ParticleSystem batteryPoof;
    public ParticleSystem laserBlast;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public float playerHealth = 2f;
    
   
    public float horizontalInput;
    public float ceilingPos = 1.5f;
    public float floorPos = 0.5f;
    public float xBound = 2.1f;
    public bool gameOver = false;
    // public bool isGameActive = false;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;
    private float crosshrinterval;
    public bool cHActive = false;

    public float gameTimer;

    private CrosshairBehave crosshrScript;
    private GameManager gameManagerScript; 
    private SpawnManager spawnManagerScript;
    private AudioManager audioManagerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        crosshrScript = GameObject.Find("Crosshairs").GetComponent<CrosshairBehave>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverUI();
        if (!gameOver)
        {
        PlayerMovement();
        PlayerBounding();
        HealthDrain();
        
        // this starts a timer that increases
        gameTimer += Time.deltaTime;
        }
        // this will begin crosshair behavior tree if it is not already active and game timer is above 15
        if(!cHActive && gameTimer > 15f && !gameOver)
        {   
        Invoke("CrosshairsStart",0);
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && playerHealth > .6f && !gameOver)
        {
            // this spawns a projectile on keypress with anti-spam protection if health is above 30%
            nextFire = Time.time + fireRate;
            playerHealth -= .2f;
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            Instantiate(laserBlast, transform.position, laserBlast.transform.rotation);
        }  else if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && playerHealth < .6f)
        {
            // this shows that health value is insufficient to spawn projectile
            Debug.Log("No Power");
        }
        
    }

    void HealthDrain()
    {
        // Slowly drains player health during gameplay
        
        playerHealth -= Time.deltaTime * .1f;
        
        // Triggers GameOver and Player Destruction if health drains to 0
        if (playerHealth < 0.0f)
        {
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("No Battery");
        }
        // Caps player max health at a total of 2
        if (playerHealth > 2)
        {
            playerHealth = 2f;
        }
    }

    void PlayerMovement()
    {
    // allows player to move left/right
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        
    // allows player to jump to the ceiling
        if(Input.GetKeyDown(KeyCode.W))
        {
            
            transform.position = new Vector3(transform.position.x, ceilingPos, transform.position.z);
        }
    // allows player to jump to the floor
        if(Input.GetKeyDown(KeyCode.S))
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
            GameOverExplode();
            GameOverUI();
        }
    }

    void CrosshairsStart()
    {
        // begins random countdown to begin crosshair behavior
        cHActive = true;
        crosshrinterval = Random.Range(10,20);
        Invoke("CrosshairsActive",crosshrinterval);
        
    }

    void CrosshairsActive()
    {
        // sets crosshairs as active and starts countdown to deactivate
        crossHairs.gameObject.SetActive(true);
        StartCoroutine(MissileActive());
        
    }

    IEnumerator MissileActive()
    {
        // this lets the crosshairs behave for 15 seconds and then deactivates them
        yield return new WaitForSeconds(15);
        crossHairs.gameObject.SetActive(false);
        cHActive = false;
    }

    public void GameOverUI()
    {
        // this activates Game Over Menu on game over
        if (gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        } 
    }
    
    public void GameOverExplode()
    {
        Invoke("Kill", 0.1f);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

}
