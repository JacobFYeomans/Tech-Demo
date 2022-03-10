using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public int speed = 3;

    public GameObject startPoint;
    public GameObject endPoint;

    public AudioSource platformMoving;

    private Vector3 startingPosition;
    private Vector3 finalPosition;
    private Vector3 moveToVector = new Vector3(0f, 0f, 0f);

    public bool moving = false; //standing on platform
    private bool moved = false; //reached destination

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = startPoint.transform.position;
        finalPosition = endPoint.transform.position;


        //if moveToVector.x > finalPosition.x && moveToVector.y > finalPosition.y && moveToVector.z > finalPosition.z //positive
        //abs value = 6 checks, greater or less then in X, Y, and Z
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (!moved)
            {
                movePlatform();

                gameObject.transform.Translate(moveToVector);

                if (transform.position.x >= finalPosition.x)
                {
                    moved = true;
                }
            }
            else if (moved)
            {
                movePlatform();

                gameObject.transform.Translate(-moveToVector);

                if (transform.position.x <= startingPosition.x)
                {
                    moved = false;
                }
            }
        }
    }

    private void movePlatform()
    {
        //x value
        if (startingPosition.x < finalPosition.x)
        {
            moveToVector.x = speed * Time.deltaTime;
        }
        else if (startingPosition.x > finalPosition.x)
        {
            moveToVector.x = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.x = 0;
        }
        //y value
        if (startingPosition.y < finalPosition.y)
        {
            moveToVector.y = speed * Time.deltaTime;
        }
        else if (startingPosition.y > finalPosition.y)
        {
            moveToVector.y = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.y = 0;
        }
        //z value
        if (startingPosition.z < finalPosition.z)
        {
            moveToVector.z = speed * Time.deltaTime;
        }
        else if (startingPosition.z > finalPosition.z)
        {
            moveToVector.z = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.z = 0;
        }
    }
}
