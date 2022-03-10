using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangingCube : MonoBehaviour
{

    float timeElapsed;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time - currentTime;
        if (timeElapsed >= 2.0f)
        {
            currentTime = Time.time;
            gameObject.GetComponent<Renderer>().material.color = new Color(RandomMe(0, 2), RandomMe(0, 2), RandomMe(0, 2), 1f);
        }
    }

    private float RandomMe(float low, float high)
    {
        return Random.Range(low, high);
    }
}
