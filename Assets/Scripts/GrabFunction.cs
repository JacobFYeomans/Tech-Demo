using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFunction : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Transform playerTransform;


    public GameObject grabableCube;
    RaycastHit hit;
    Ray ray;

    private bool isHolding = false;
    private FixedJoint joint;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //ray = cam.transform.position;
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
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10.0f)) //transform.position, transform.forward,
            {
                Debug.Log("Rays Casted");
                // pickup vvv
                if (!isHolding && (hit.transform.tag == "grabcube"))
                {
                    grabableCube = hit.transform.gameObject;
                    grabableCube.transform.position = (player.transform.position + offset);
                    grabableCube.transform.localRotation = transform.rotation;
                    grabableCube.GetComponent<Rigidbody>().useGravity = false; //use in other places
                    grabableCube.transform.SetParent(playerTransform);
                    joint = grabableCube.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = player.GetComponent<Rigidbody>();
                    isHolding = true;
                    StartCoroutine(wait1());
                    Debug.Log("cube picked up");
                }
                else if (isHolding)
                {
                    PutDownCube();
                }
            }
        }

        if (isHolding)
        {
            grabableCube.transform.position = player.transform.position;
            grabableCube.transform.localRotation = transform.rotation;
        }
    }

    public void PutDownCube()
    {
        Destroy(grabableCube.GetComponent<FixedJoint>());
        grabableCube.transform.parent = null;
        grabableCube.GetComponent<Rigidbody>().useGravity = true;
        grabableCube.transform.localRotation = transform.rotation;
        isHolding = false;
        StartCoroutine(wait1());
        Debug.Log("cube dropped");
    }
}
