using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewarp : MonoBehaviour
{
    private Vector3 rewarpPos;
    private bool settingPos = true;

    public AudioSource setRewarp;
    public AudioSource activateRewarp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && settingPos == true)
        {
            rewarpPos = gameObject.transform.position;
            settingPos = false;
            setRewarp.Play();
        }
        else if (Input.GetKeyDown(KeyCode.R) && settingPos == false)
        {
            gameObject.transform.position = rewarpPos;
            settingPos = true;
            activateRewarp.Play();
        }
    }
}
