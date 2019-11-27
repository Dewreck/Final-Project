using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollect : MonoBehaviour
{

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // destroys battery and adds Health to player on collision with player
        if (other.gameObject.CompareTag("Player"))
        {
        Destroy(gameObject);
        Debug.Log("Battery Get!!");
        playerControllerScript.playerHealth += 1f;
        playerControllerScript.batteryPoof.Play();
        }
    } 
}
