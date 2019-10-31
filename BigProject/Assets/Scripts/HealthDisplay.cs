using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
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
        healthAmnt = playerControllerScript.playerHealth;
        if (!playerControllerScript.gameOver)
        {
            transform.localScale = new Vector3(healthAmnt,0.18f,0.05f);
        }

        if (healthAmnt < 0.6f)
        {
            var cubeColor = gameObject.GetComponent<Renderer>();
            cubeColor.material.SetColor("_Color", Color.red);
        }else
        {
            var cubeColor = gameObject.GetComponent<Renderer>();
            cubeColor.material.SetColor("_Color", Color.green);
        }
    }
}
