using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SushiSpawn : MonoBehaviour
{
    public GameObject Sushi;
    public GameObject StartBox;
    public float max = -0.446f;
    public float min = -1.066f;

    public float level = 8;

    public bool timerStart = false;

    public float timerLength = 8;
    // Start is called before the first frame update
    void Start()
    {
        //spawnSushi();
    }

    public void spawnSushi()
    {
        Vector3 position = new Vector3((float)GetRandomNumber(min, max), gameObject.transform.position.y, gameObject.transform.position.z);
        Instantiate(Sushi, position, Quaternion.identity);
    }

    public double GetRandomNumber(double minimum, double maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    // Update is called once per frame
    void Update()
    {

        timerLength -= Time.deltaTime;


        if (timerLength <= 0 && StartBox.GetComponent<startSushi>().startGame)
        {
            timerLength = level;
            spawnSushi();
        }
    }
}

