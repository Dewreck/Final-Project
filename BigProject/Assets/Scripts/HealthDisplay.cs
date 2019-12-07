using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
// This Script manages the size, color, and behaviorof the Health bar
    
    private PlayerController playerControllerScript;
    private float healthAmnt;
    private

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // this changes size of health bar in relation to player health value
        healthAmnt = playerControllerScript.playerHealth;
        if (!playerControllerScript.gameOver)
        {
            transform.localScale = new Vector3(healthAmnt,0.18f,0.05f);
        }
        //this changes color of health bar to red if health value is <30%
        if (healthAmnt < 0.6f)
        {
            var cubeColor = gameObject.GetComponent<Renderer>();
            cubeColor.material.SetColor("_Color", Color.red);
        }else
        // this changes color of health bar back to green if health value is >30% 
        {
            var cubeColor = gameObject.GetComponent<Renderer>();
            cubeColor.material.SetColor("_Color", Color.green);
        }
    }
}
