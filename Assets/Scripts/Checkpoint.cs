using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Killbox killzone;
    private bool active = false;

    public AudioSource respawnUpdate;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (killzone.respawnPoint != gameObject)
        {
            active = false;
        }

        if (!active)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (active)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active)
        {
            respawnUpdate.Play();
        }
        killzone.respawnPoint = gameObject;
        active = true;
    }
}
