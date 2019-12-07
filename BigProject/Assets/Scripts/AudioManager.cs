using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
// This Script manages most audio effects within the game

    public AudioClip projectileShoot;
    public AudioClip projectileHit;
    public AudioClip rocketHit;
    public AudioClip batteryGet;
    public AudioClip batteryGet2;
    public AudioClip deathExplosion;
    private AudioSource cameraAudio;
    private PlayerController playerControllerScript;
    private bool deadYet = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
    }

    public void ProjectileShootSound()
    {
        //plays audio on projectile instantiate
        cameraAudio.PlayOneShot(projectileShoot, 0.8f);
    }

    public void ProjectileHitSound()
    {
        //plays audio when projectile destroys a barrier
        cameraAudio.PlayOneShot(projectileHit, 0.5f);
    }

    public void RocketHitSound()
    {
        //plays audio when rocket destroys a barrier
        cameraAudio.PlayOneShot(rocketHit, 3.0f);
    }

    public void BatteryGetSound()
    {
        //plays audio when battery is collected
        cameraAudio.PlayOneShot(batteryGet, 2f);
        cameraAudio.PlayOneShot(batteryGet2, 2.5f);
    }

    void DeathCheck()
    {
        if (playerControllerScript.gameOver && !deadYet)
        {
            //only allows DeathSound() to be activated once
            deadYet = true;
            DeathSound();
        }
    }

    public void DeathSound()
    {
        //plays audio when player is killed
        cameraAudio.PlayOneShot(deathExplosion, 2.0f);
    }
}
