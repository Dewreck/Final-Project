using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMove : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazardCeil;
    public GameObject msgBottom;
    public GameObject msgTop;

    public bool down;
    public bool up;
    public float hazInterval;

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
            hazInterval = Random.Range(1f,10f);
            if(!playerControllerScript.gameOver && up == false && down == false)
            {
            msgBottom.transform.position = new Vector3(-2.5f,-2.5f,-3);
            down = true;            
            Invoke("HazardHurt", 2);
            }else
            {
                hazInterval = Random.Range(1f,10f);
                Invoke("HazBegin", hazInterval);
            }
    }
//displays a warning message on the ceiling 
    void HazCeilBegin()
    {
            hazInterval = Random.Range(1f,10f);
            if(!playerControllerScript.gameOver && down == false && up == false)
            {
            msgTop.transform.position = new Vector3(-2.5f,7.5f,-3);
            up = true;
            Invoke("HazardCeilHurt", 2);
            }else
            {
                hazInterval = Random.Range(1f,10f);
                Invoke("HazBegin", hazInterval);
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
        hazInterval = Random.Range(5f,10f);
        hazard.transform.position = new Vector3(0, -1, transform.position.z);
        down = false;
        Invoke("HazBegin", hazInterval);
    }
//moves the ceiling hazard back above the ceiling
    void HazardCeilReturn()
    {
        hazInterval = Random.Range(5f,10f);
        hazardCeil.transform.position = new Vector3(0, 3, transform.position.z);
        up = false;
        Invoke("HazCeilBegin", hazInterval);
    }
}
