using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            door.GetComponent<Door>().opening = true;
            door.GetComponent<Door>().closing = false;
            if (door.GetComponent<Door>().doorClosing.isPlaying)
            {
                door.GetComponent<Door>().interrupted = true;
            }
            door.GetComponent<Door>().doorClosing.Stop();
            door.GetComponent<Door>().doorOpening.Play(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            door.GetComponent<Door>().closing = true;
            door.GetComponent<Door>().opening = false;
            if (door.GetComponent<Door>().doorOpening.isPlaying)
            {
                door.GetComponent<Door>().interrupted = true;
            }
            door.GetComponent<Door>().doorOpening.Stop();
            door.GetComponent<Door>().doorClosing.Play();
        }
    }
}
