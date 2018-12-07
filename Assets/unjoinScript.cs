using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unjoinScript : MonoBehaviour {

    public Rigidbody combinedObject;
    public GameObject joinObjectSmallCollider;

    bool collisionAlreadyOccurred = false;

    void Start()
    {

    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)

    {

        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
               
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc;
                combinedObjectLoc = gameObject.transform;
                Destroy(gameObject.transform.parent.gameObject);
 
                Rigidbody partialInstance;

                OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();

                partialInstance = Instantiate(combinedObject, Lefthand.transform.position, combinedObjectLoc.rotation) as Rigidbody;
               
            }
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

