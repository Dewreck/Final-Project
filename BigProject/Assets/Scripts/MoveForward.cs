﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 7.0f;
    private float backBound = -15f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if(transform.position.z < backBound)
        {
            Destroy(gameObject);
        }

    }
}
