using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFabDestroyer : MonoBehaviour
{
    public AudioSource deathCry;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PreFab")
        {
            deathCry.Play();
            if (!deathCry.isPlaying)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
