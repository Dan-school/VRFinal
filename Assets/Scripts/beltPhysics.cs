using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beltPhysics : MonoBehaviour
{
    public GameObject endPort;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sushi" || other.tag == "Plate")
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, endPort.gameObject.transform.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, endPort.gameObject.transform.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                endPort.gameObject.transform.position *= -1.0f;
            }
        }
    }
}
