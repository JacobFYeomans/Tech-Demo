using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiatorTrigger : MonoBehaviour
{
    public GameObject instantiator;
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
            instantiator.GetComponent<Instantiator>().spawning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            instantiator.GetComponent<Instantiator>().spawning = false;
        }
    }
}
