using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBattery : MonoBehaviour
{
    public float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // this rotates the object around the y axis
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
