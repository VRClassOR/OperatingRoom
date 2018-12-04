using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{

    public Rigidbody combinedObject;
    public Transform combinedObjectLoc;
    public GameObject joinObjectSmallCollider;

    bool collisionAlreadyOccurred = false;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Cylinder1 loc start: " + combinedObjectLoc.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("other:" + other)

        //if (other.gameObject.name == "Cylinder2" && !collisionAlreadyOccurred)
        if (other.gameObject.CompareTag("joinCollider")
            //&& other.gameObject.name == "Cylinder2Collider"
            && other.gameObject.name == joinObjectSmallCollider.name
            && !collisionAlreadyOccurred)
        {
            // Check alignment

            Vector3 othervec = other.bounds.max - other.bounds.min;
            Debug.Log("othervec:" + othervec);
            collisionAlreadyOccurred = true;
            combinedObjectLoc = gameObject.transform;
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);

            Debug.Log("Collision with Cylinder 2 detected \n");
            Debug.Log("Cylinder1 loc: " + combinedObjectLoc.position);


            //Debug.Log(Sphere1Loc.position);
            Rigidbody partialInstance;
            partialInstance = Instantiate(combinedObject, combinedObjectLoc.position, combinedObjectLoc.rotation) as Rigidbody;
            //OVRGrabber Righthand = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
            //ighthand
            //partialInstance = Instantiate(combinedObject, gameObject.transform.position, gameObject.transform.rotation) as Rigidbody;
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
