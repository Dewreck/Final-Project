using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pillar;
    public GameObject barrier;
    public GameObject battery;
    private float pillarX = 4.6f;
    private float pillarX2 = 4.9f;
    private float pillarY = 1.0f;
    private float ObjectZ = 14.0f;

    public float barrierSpawnX = -4f;
    public float barrierSpawnX2 = 4.2f;
    public float floorBarrierY = 0.36f;
    public float topBarrierY = 1.65f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPillar", 0, 1.5f);
        InvokeRepeating("SpawnBarrier", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 batterySpawnPos = new Vector3(Random.Range(barrierSpawnX, barrierSpawnX2),Random.Range(0.5f,1.6f), ObjectZ);
            Instantiate(battery, batterySpawnPos, battery.transform.rotation);
        }
    }

    void SpawnBarrier()
    {
        // Spawns a barrier on the ceiling
            Vector3 barrierTopSpawnPos = new Vector3(Random.Range(barrierSpawnX, barrierSpawnX2), 1.65f, ObjectZ);
            Instantiate(barrier, barrierTopSpawnPos, barrier.transform.rotation);

        // Spawns a barrier on the floor
            Vector3 barrierBottomSpawnPos = new Vector3(Random.Range(barrierSpawnX, barrierSpawnX2),floorBarrierY,ObjectZ);
            Instantiate(barrier, barrierBottomSpawnPos, barrier.transform.rotation);
    }

// this spawns wall pillars at regular intervals
    void SpawnPillar()
    {
        Instantiate(pillar, new Vector3(-pillarX,pillarY,ObjectZ), pillar.transform.rotation);
        Instantiate(pillar, new Vector3(pillarX2,pillarY,ObjectZ), pillar.transform.rotation);
    }
}


