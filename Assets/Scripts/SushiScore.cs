using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SushiScore : MonoBehaviour
{
    public Color sushi = Color.red;
    public Color plate = Color.green;
    public Color neutral;
    public Light scoreLight;

    public AudioSource speaker;
    public AudioClip errorClip;
    public AudioClip endClip;
    public AudioClip goodSound;
    public AudioClip StartSound;
    public GameObject StartBox;


    public bool startbool = false;

    public GameObject floor;

    public GameObject sushiBelt;

    public GameObject sushiSpawn;

    public TMP_Text scoreBoard;

    public Light overheadLight;

    System.Timers.Timer LeTimer;
    int BoomDown = 100;

    public float hourlyPay = 21.50f;

    public float persecondpay;

    public float currentPay = 0;

    private decimal displayPay;

    public float colorTime = 1.5f;//this is in seconds

    private bool timerStart = false;


    // Start is called before the first frame update
    void Start()
    {
        neutral = scoreLight.color;

    }

    // Update is called once per frame
    void Update()
    {
        persecondpay = hourlyPay / 3600;


        displayPay = decimal.Round((decimal)currentPay, 2);

        if (StartBox.GetComponent<startSushi>().startGame && !startbool)
        {
            startbool = true;
            speaker.PlayOneShot(StartSound, 1);
            StartCoroutine("DoStuff", 1.0f);
        }

        if (scoreLight.color != neutral && timerStart)
        {

            startTimer();
        }

        if (colorTime <= 0)
        {
            timerStart = false;
            scoreLight.color = neutral;
        }
        scoreBoard.text = "Pay PerSecond : \n$" + persecondpay + "\nCurrent paycheck : \n$" + displayPay;

        if (hourlyPay <= 0)
        {
            //trigger endGame
            endGame();
        }

        if (displayPay > .30M)
        {

            if (overheadLight.spotAngle >= 45)
            {
                overheadLight.spotAngle -= 0.01f;
            }
        }

    }

    public void endGame()
    {
        StopCoroutine("DoStuff");
        speaker.PlayOneShot(endClip);
        floor.transform.GetComponent<RemoveFloor>().start = true;
    }

    IEnumerator DoStuff(float waitTime)
    {
        while (true)
        {

            if (displayPay > .30M)
            {
                if (sushiBelt.transform.GetComponent<beltPhysics>().speed < 3)
                {
                    sushiBelt.transform.GetComponent<beltPhysics>().speed += 0.01f;
                }
                sushiSpawn.transform.GetComponent<SushiSpawn>().level -= 0.05f;
            }

            currentPay += persecondpay;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void startTimer()
    {
        colorTime -= Time.deltaTime * 2;
    }

    private void startTime()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sushi")
        {
            hourlyPay -= 0.25f;
            colorTime = 1.5f;
            timerStart = true;
            speaker.PlayOneShot(errorClip, 1);
            scoreLight.color = sushi;


            Destroy(other);
        }
        if (other.tag == "Plate")
        {
            if (other.gameObject.GetComponent<PlateScript>().count == 4)
            {
                colorTime = 1.5f;
                timerStart = true;
                scoreLight.color = plate;
                speaker.PlayOneShot(goodSound, 1);
                Destroy(other);
            }
            else
            {
                colorTime = 1.5f;
                timerStart = true;
                hourlyPay -= 0.25f;
                scoreLight.color = sushi;
                speaker.PlayOneShot(errorClip, 1);
                Destroy(other);
            }

        }
    }
}
