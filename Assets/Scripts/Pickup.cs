using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text pickupText;
    private int score = 0;
    private float timeElapsed;
    private float currentTime;

    public bool respawnable;
    private bool playOnce = false;

    public AudioSource pickedUpSFX;
    public AudioSource respawnedSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickupText.text = "Pickups Held: " + score;

        if (respawnable)
        {
            timeElapsed = Time.time - currentTime;

            if (timeElapsed >= 3.0f)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (playOnce)
                {
                    respawnedSFX.Play();
                    playOnce = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            score++;
            pickedUpSFX.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            currentTime = Time.time;
            playOnce = true;
        }
    }
}
