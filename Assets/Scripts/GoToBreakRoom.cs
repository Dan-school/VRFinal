using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBreakRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(other);
        }
        else
        {
            Debug.Log("should load to the next place");
            SceneManager.LoadScene(0);
        }

    }
}
