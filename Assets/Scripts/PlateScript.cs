using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public OVRGrabbable grabbed;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        grabbed = gameObject.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed.isGrabbed)
        {
            gameObject.transform.SetParent(grabbed.grabbedBy.transform);
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.transform.SetParent(null);
            gameObject.tag = "Plate";
        }

    }


}

