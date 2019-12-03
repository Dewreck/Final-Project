using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HazardMove : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazardCeil;
    public TextMeshProUGUI warningUP;
    public TextMeshProUGUI warningDOWN;

    public bool down;
    public bool up;
    public float hazInterval;

    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    // this starts the floor hazard path
        Invoke("HazBegin",15);
    //this starts the ceiling hazard path
        Invoke("HazCeilBegin",19);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
// displays a warning message on the floor
    void HazBegin()
    {
        //this tests if play area is available to begin hazard behavior
            // hazInterval = Random.Range(1f,10f);
            
            if(!playerControllerScript.gameOver && up == false && down == false)
            {
            warningDOWN.gameObject.SetActive(true);
            down = true;            
            Invoke("HazardHurt", 2);
            }else
            {
            // this retries to begin the function at another interval
                hazInterval = Random.Range(1f,9f);
                Invoke("HazBegin", hazInterval);
            }
    }
//displays a warning message on the ceiling 
    void HazCeilBegin()
    {
        //this tests if play area is available to begin hazard behavior
            // hazInterval = Random.Range(1f,10f);
            if(!playerControllerScript.gameOver && up == false && down == false)
            {
            warningUP.gameObject.SetActive(true);
            up = true;
            Invoke("HazardCeilHurt", 2);
            }else
            {
            // this retries to begin the function at another interval
                hazInterval = Random.Range(1f,5f);
                Invoke("HazBegin", hazInterval);
            }
    }

    
//moves the floor hazard upwards through the floor
    void HazardHurt()
    {
        hazard.transform.position = new Vector3(0,-0.27f, transform.position.z);
        warningDOWN.gameObject.SetActive(false);
        down = false;
        Invoke("HazardReturn", 0.5f);
    }
//moves the ceiling hazard downwards through the ceiling
    void HazardCeilHurt()
    {
        hazardCeil.transform.position = new Vector3(0,2.27f, transform.position.z);
        warningUP.gameObject.SetActive(false);
        up = false;
        Invoke("HazardCeilReturn", 0.5f);
    }
//moves the floor hazard back below the floor
    void HazardReturn()
    {
        hazInterval = Random.Range(5f,10f);
        hazard.transform.position = new Vector3(0, -1, transform.position.z);
        Invoke("HazBegin", hazInterval);
    }
//moves the ceiling hazard back above the ceiling
    void HazardCeilReturn()
    {
        hazInterval = Random.Range(5f,10f);
        hazardCeil.transform.position = new Vector3(0, 3, transform.position.z);
        Invoke("HazCeilBegin", hazInterval);
    }
}
