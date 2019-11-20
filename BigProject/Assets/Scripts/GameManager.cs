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

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay();
    }

    public void ScoreDisplay()
    {
        if (!playerControllerScript.gameOver)
        {
        score += Time.deltaTime * 4;
        }
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
