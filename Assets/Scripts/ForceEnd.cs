using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEnd : MonoBehaviour
{

    public bool startEnd = false;
    public GameObject sushiEnd;


    public void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("CustomHandLeft") || other.name.Equals("CustomHandRight"))
        {
            sushiEnd.GetComponent<SushiScore>().endGame();
        }

    }
}
