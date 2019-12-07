using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
        cameraAudio.PlayOneShot(projectileShoot, 0.8f);
    }

    public void ProjectileHitSound()
    {
        cameraAudio.PlayOneShot(projectileHit, 0.5f);
    }

    public void RocketHitSound()
    {
        cameraAudio.PlayOneShot(rocketHit, 3.0f);
    }

    public void BatteryGetSound()
    {
        cameraAudio.PlayOneShot(batteryGet, 2f);
        cameraAudio.PlayOneShot(batteryGet2, 2.5f);
    }

    void DeathCheck()
    {
        if (playerControllerScript.gameOver && !deadYet)
        {
            deadYet = true;
            DeathSound();
        }
    }

    public void DeathSound()
    {
        cameraAudio.PlayOneShot(deathExplosion, 2.0f);
    }
}
