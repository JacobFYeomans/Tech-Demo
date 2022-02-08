using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    private bool opening = false;
    private bool closing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {

            door.transform.Translate(0, 4 * Time.deltaTime, 0);

            if (door.transform.position.y >= 6)
            {
                opening = false;
            }
        }
        else if (closing)
        {

            door.transform.Translate(0, -4 * Time.deltaTime, 0);

            if (door.transform.position.y <= 2)
            {
                closing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        opening = true;
    }

    private void OnTriggerExit(Collider other)
    {
        closing = true;
    }
}
