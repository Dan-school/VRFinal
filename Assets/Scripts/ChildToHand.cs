using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildToHand : MonoBehaviour
{
    public OVRGrabbable grabbed;
    public bool placed = false;
    public Rigidbody rb;
    public GameObject sushiSpot;
    public Vector3 handplace = new Vector3(0.04f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        grabbed = gameObject.GetComponent<OVRGrabbable>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (grabbed.isGrabbed)
        {   
            rb.isKinematic = true;
            gameObject.transform.SetParent(grabbed.grabbedBy.transform);
            gameObject.transform.localPosition = handplace;
        }
        else if (placed)
        {
            gameObject.transform.SetParent(sushiSpot.transform);
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.isKinematic = false;
            gameObject.transform.SetParent(null);
        }
 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SushiSpot" && !placed)
        {
            placed = true;
            sushiSpot = other.gameObject;
            sushiSpot.tag = "Untagged";
            other.gameObject.transform.parent.gameObject.GetComponent<PlateScript>().count++;
            Destroy(grabbed);

        }
          
    }
}
