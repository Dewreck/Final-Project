using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 15f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 14f)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
