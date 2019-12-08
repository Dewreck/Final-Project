using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
// This Script manages certain aspects of the UI and Particle effects that don't work within PlayerController

    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    private PlayerController playerControllerScript;
    private float score;
    public GameObject deathExplosion;
    private int explosionPlayback;
    private Vector3 explodeLocation;
    public static bool gameStart = false;
    

    // Start is called before the first frame update

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        explosionPlayback = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay();

        DeathExplosion();
    }

    public void ScoreDisplay()
    {
        //this adds score based on time elapsed and displays it
        if (!playerControllerScript.gameOver)
        {
            score += Time.deltaTime * 4;
        }
        scoreText.text = "Score: " + Mathf.Round(score);

        if (!playerControllerScript.gameOver)
        {
            score += Time.deltaTime * 4;
        }
        scoreText2.text = "Score: " + Mathf.Round(score);
    }

    public void DeathExplosion()
    {
        // this plays the player explosion effect once on the player's location
        if (playerControllerScript.gameOver &&  explosionPlayback == 0)
        {
            explodeLocation = GameObject.Find("Player").transform.position;
            explosionPlayback = 1;
            Instantiate(deathExplosion, explodeLocation, deathExplosion.transform.rotation);
        }
    }

    //this lets the Restart button refresh the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
