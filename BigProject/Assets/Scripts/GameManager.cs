using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    private PlayerController playerControllerScript;
    private float score;
    public GameObject deathExplosion;
    private int explosionPlayback;
    private Vector3 explodeLocation;

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
    }

    public void DeathExplosion()
    {
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
}
