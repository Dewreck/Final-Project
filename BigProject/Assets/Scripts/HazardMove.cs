using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMove : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazardCeil;
    public GameObject msgBottom;
    public GameObject msgTop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            msgBottom.transform.position = new Vector3(-2.5f,-2.5f,-3);
            Debug.Log("Bottom");
            
            
            Invoke("HazardHurt", 2);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            msgTop.transform.position = new Vector3(-2.5f,7.5f,-3);
            Debug.Log("Top");
            
            Invoke("HazardCeilHurt", 2);
        }
    }

    void HazardReturn()
    {
        hazard.transform.position = new Vector3(0, -1, transform.position.z);
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
    }
}
