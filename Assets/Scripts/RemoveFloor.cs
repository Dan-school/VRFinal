using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFloor : MonoBehaviour
{

    public bool start = false;
    public Vector3 spot = new Vector3(-15, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StartCoroutine(LerpPosition(spot, 15));
        }
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
