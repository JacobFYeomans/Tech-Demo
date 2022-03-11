using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject platform;

    public GameObject player;

    // Start is called before the first frame update
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
            platform.GetComponent<Moving_Platform>().moving = true;
            platform.GetComponent<Moving_Platform>().isMoving.Play();
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            platform.GetComponent<Moving_Platform>().moving = false;
            platform.GetComponent<Moving_Platform>().isMoving.Stop();
            player.transform.parent = null;
        }
    }
}
