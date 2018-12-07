using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Most objects use "joinScript.cs" to combine object A and object B into object C and then delete objects A and B.
 * All tools in the program follow this sequence except for "DrivingCap+GuideConnector+Handle+Driver+Connector+Nail",
 * which must have the "handle" part of the instrument removed using the Left Hand or Right Hand.
 * This script ensures that the "joinObjectSmallCollider" is not destroyed when a part of the tool is "unjoined" to
 * create the next tool in the sequence.
*/
public class unjoinScript : MonoBehaviour {

    public Rigidbody combinedObject;
    public GameObject RightHandCollider;
    public GameObject LeftHandCollider;
    

    bool collisionAlreadyOccurred = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && RightHandCollider != null && LeftHandCollider != null)
        {
            if (other.gameObject.name == RightHandCollider.name || other.gameObject.name == LeftHandCollider.name
                && !collisionAlreadyOccurred)
            {
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc;
                combinedObjectLoc = gameObject.transform;
                Destroy(gameObject.transform.parent.gameObject);

                OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();
                OVRGrabber Righthand = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
                Vector3 newLoc = (Lefthand.transform.position + Righthand.transform.position) / 2;

                Rigidbody partialInstance;
                partialInstance = Instantiate(combinedObject, newLoc, combinedObjectLoc.rotation) as Rigidbody;
                KeepingScore.Score += 50;

            }
        }
    }
}

