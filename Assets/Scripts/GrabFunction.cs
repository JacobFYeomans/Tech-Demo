using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFunction : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Transform playerTransform;

    public AudioSource pickup;
    public AudioSource drop;


    public GameObject grabableCube;
    RaycastHit hit;

    private bool isHolding = false;
    private FixedJoint joint;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z + 1);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            if (isHolding)
            {
                PutDownCube();
                return;
            }
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10.0f))
            {
                Debug.Log("Rays Casted");
                // pickup vvv
                if (!isHolding && (hit.transform.tag == "grabcube"))
                {
                    grabableCube = hit.transform.gameObject;
                    grabableCube.transform.position = offset;
                    grabableCube.GetComponent<Rigidbody>().useGravity = false; //use in other places
                    grabableCube.transform.SetParent(cam.transform);
                    joint = grabableCube.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = player.GetComponent<Rigidbody>();
                    isHolding = true;
                    pickup.Play();
                    StartCoroutine(wait1());
                    Debug.Log("cube picked up");
                }
            }
        }

        if (isHolding)
        {
            grabableCube.transform.position = offset;

        }
    }

    public void PutDownCube()
    {
        Destroy(grabableCube.GetComponent<FixedJoint>());
        grabableCube.transform.parent = null;
        grabableCube.GetComponent<Rigidbody>().useGravity = true;
        grabableCube.transform.localRotation = transform.rotation;
        isHolding = false;
        drop.Play();
        StartCoroutine(wait1());
        Debug.Log("cube dropped");
    }
}
