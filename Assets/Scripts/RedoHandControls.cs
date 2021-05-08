using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoHandControls : MonoBehaviour
{
    public GameObject plate;
    public OVRPlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<OVRPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            

        }
    }
}
