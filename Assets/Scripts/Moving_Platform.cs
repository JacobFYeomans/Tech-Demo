using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public int speed = 3;

    public GameObject startPoint;
    public GameObject endPoint;
    //public GameObject player;

    public AudioSource platformMoving;

    private Vector3 startingPosition;
    private Vector3 finalPosition;
    private Vector3 moveToVector = new Vector3(0f, 0f, 0f);

    public bool moving = false;
    private bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = startPoint.transform.position;
        finalPosition = endPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (!moved)
            {
                moveToVector = movePlatform();
                Debug.Log(moveToVector);
                gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

                if (transform.position.x >= finalPosition.x)
                {
                    moved = true;
                }
            }
            else if (moved)
            {
                moveToVector = movePlatform();

                gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0); 

                if (transform.position.x <= startingPosition.x)
                {
                    moved = false;
                }
            }
        }
    }

    private Vector3 movePlatform()
    {
        if (startingPosition.x <= finalPosition.x)
        {
            moveToVector.x = speed * Time.deltaTime;
        }
        else if (startingPosition.x >= finalPosition.x)
        {
            moveToVector.x = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.x = 0;
        }
        if (startingPosition.y <= finalPosition.y)
        {
            moveToVector.y = speed * Time.deltaTime;
        }
        else if (startingPosition.y >= finalPosition.y)
        {
            moveToVector.y = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.y = 0;
        }
        if (startingPosition.z <= finalPosition.z)
        {
            moveToVector.z = speed * Time.deltaTime;
        }
        else if (startingPosition.z >= finalPosition.z)
        {
            moveToVector.z = -speed * Time.deltaTime;
        }
        else
        {
            moveToVector.z = 0;
        }

        return moveToVector;
    }
}
