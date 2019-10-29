using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRecall : MonoBehaviour
{
    private float posReset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 0)
        {
            transform.position = new Vector3(0,0,0);
        }
    }
}
