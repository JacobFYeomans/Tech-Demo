using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opening = false;
    public bool closing = false;
    public bool interrupted = false;

    public AudioSource doorOpening;
    public AudioSource doorClosing;
    public AudioSource doorOpeningEnd;
    public AudioSource doorClosingEnd;

    private float lowestPosition;
    private float highestPosition;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 initalPos = gameObject.transform.position;
        lowestPosition = initalPos.y;

        float yRange = gameObject.transform.lossyScale.y;
        highestPosition = lowestPosition + yRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            gameObject.transform.Translate(0, highestPosition * Time.deltaTime, 0);

            if (gameObject.transform.position.y >= highestPosition)
            {
                opening = false;
                doorOpening.Stop();
                if (interrupted)
                {
                    doorOpeningEnd.Play();
                    interrupted = false;
                }
            }
        }
        else if (closing)
        {
            gameObject.transform.Translate(0, -lowestPosition * Time.deltaTime, 0);

            if (gameObject.transform.position.y <= lowestPosition)
            {
                closing = false;
                doorClosing.Stop();
                if (interrupted)
                {
                    doorClosingEnd.Play();
                    interrupted = false;
                }

            }
        }
    }
}
