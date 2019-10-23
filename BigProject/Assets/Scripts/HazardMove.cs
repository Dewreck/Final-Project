using System.Collections;
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
    // this starts the floor hazard path
        Invoke("HazBegin",5);
    //this starts the ceiling hazard path
        Invoke("HazCeilBegin",9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
// displays a warning message on the floor
    void HazBegin()
    {
            if(!playerControllerScript.gameOver)
            {
            msgBottom.transform.position = new Vector3(-2.5f,-2.5f,-3);
            
            Invoke("HazardHurt", 2);
            }
    }
//displays a warning message on the ceiling 
    void HazCeilBegin()
    {
            if(!playerControllerScript.gameOver)
            {
            msgTop.transform.position = new Vector3(-2.5f,7.5f,-3);
            
            Invoke("HazardCeilHurt", 2);
            }
    }

    
//moves the floor hazard upwards through the floor
    void HazardHurt()
    {
        hazard.transform.position = new Vector3(0, 0, transform.position.z);
        msgBottom.transform.position = new Vector3(0,0,-15);
        Invoke("HazardReturn", 0.5f);
    }
//moves the ceiling hazard downwards through the ceiling
    void HazardCeilHurt()
    {
        hazardCeil.transform.position = new Vector3(0,2, transform.position.z);
        msgTop.transform.position = new Vector3(0,0,-15);
        Invoke("HazardCeilReturn", 0.5f);
    }
//moves the floor hazard back below the floor
    void HazardReturn()
    {
        hazard.transform.position = new Vector3(0, -1, transform.position.z);

        Invoke("HazBegin", 5);
    }
//moves the ceiling hazard back above the ceiling
    void HazardCeilReturn()
    {
        hazardCeil.transform.position = new Vector3(0, 3, transform.position.z);

        Invoke("HazCeilBegin", 5);
    }
}
