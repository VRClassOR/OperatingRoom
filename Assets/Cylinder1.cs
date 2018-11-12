using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder1 : MonoBehaviour
{

    public Rigidbody Partial3;
    public Transform Cylinder1Loc;

    bool collisionAlreadyOccurred = false;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Cylinder1 loc start: " + Cylinder1Loc.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("other:" + other)
        
        if (other.gameObject.name == "Cylinder2" && !collisionAlreadyOccurred)
        {
            // Check alignment

            Vector3 othervec = other.bounds.max - other.bounds.min;
            Debug.Log("othervec:" + othervec);
            collisionAlreadyOccurred = true;
            Debug.Log("Collision with Cylinder 2 detected \n");
            Debug.Log("Cylinder1 loc: " + Cylinder1Loc.position);
            Cylinder1Loc = gameObject.transform;
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);

            //Debug.Log(Sphere1Loc.position);
            Rigidbody partialInstance;
            partialInstance = Instantiate(Partial3, Cylinder1Loc.position, Cylinder1Loc.rotation) as Rigidbody;
            //OVRGrabber Righthand = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
            //ighthand
            //partialInstance = Instantiate(Partial3, gameObject.transform.position, gameObject.transform.rotation) as Rigidbody;
            Debug.Log("Partial 3 loc: " + partialInstance.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Display text");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("stop text");
    }

}
