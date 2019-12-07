using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollect : MonoBehaviour
{
//This Script manages the behavior of the Battery prefab when the player collects it

    private PlayerController playerControllerScript;
    private AudioManager audioManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        audioManagerScript = GameObject.Find("Main Camera").GetComponent<AudioManager>();
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
        audioManagerScript.BatteryGetSound();
        }
    } 
}
