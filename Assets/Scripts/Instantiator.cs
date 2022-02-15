using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject PreFab;

    private float timeElapsed;
    private float timeSnapshot;

    public AudioSource instatiatorActive;
    public AudioSource spawnedPreFab;

    public bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        timeSnapshot = Time.time;

        //PREFABS!!

        //GameObject.Instantiate(PreFab); //you can also find the file

        //PRIMITIVES!!

        //create variable game objects to hold the instantiated object
        //GameObject c_Cube;
        //GameObject c_Sphere;

        //instantiate a primitive, cube
        //c_Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //c_Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //how do me move/place these objects
        //gameObject.transform.Transform targets game object itself, as does anything similar

        //changing position
        //c_Cube.transform.position = new Vector3(-1.0f, 20.0f, 0.0f);
        //c_Sphere.transform.position = new Vector3(1.0f, 20.0f, 0.0f);

        //adding rigidbody
        //c_Cube.AddComponent<Rigidbody>();
        //c_Sphere.AddComponent<Rigidbody>();

        //changing colour
        //c_Cube.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        //c_Sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time - timeSnapshot;

        if (timeElapsed >= 1.0f && spawning)
        {
            GameObject.Instantiate(PreFab);
            PreFab.transform.position = gameObject.transform.position;
            spawnedPreFab.Play(0);
            timeSnapshot = Time.time;
            timeElapsed = 0.0f;
        }
    }
}
