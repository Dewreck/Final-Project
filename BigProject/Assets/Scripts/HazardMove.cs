﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMove : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazardCeil;
    public GameObject msgBottom;
    public GameObject msgTop;

    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("HazBegin",5);
        Invoke("HazCeilBegin",9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void HazBegin()
    {
            if(playerControllerScript.gameOver == false)
            {
            msgBottom.transform.position = new Vector3(-2.5f,-2.5f,-3);
            
            Invoke("HazardHurt", 2);
            }
    }

    void HazCeilBegin()
    {
            if(playerControllerScript.gameOver == false)
            {
            msgTop.transform.position = new Vector3(-2.5f,7.5f,-3);
            
            Invoke("HazardCeilHurt", 2);
            }
    }

    void HazardReturn()
    {
        hazard.transform.position = new Vector3(0, -1, transform.position.z);

        Invoke("HazBegin", 5);
    }

    void HazardHurt()
    {
        hazard.transform.position = new Vector3(0, 0, transform.position.z);
        msgBottom.transform.position = new Vector3(0,0,-15);
        Invoke("HazardReturn", 0.5f);
    }

    void HazardCeilHurt()
    {
        hazardCeil.transform.position = new Vector3(0,2, transform.position.z);
        msgTop.transform.position = new Vector3(0,0,-15);
        Invoke("HazardCeilReturn", 0.5f);
    }

    void HazardCeilReturn()
    {
        hazardCeil.transform.position = new Vector3(0, 3, transform.position.z);

        Invoke("HazCeilBegin", 5);
    }
}
