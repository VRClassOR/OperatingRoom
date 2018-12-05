using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{

    public Rigidbody combinedObject;

    //public GameObject combinedObject;
    //public Transform combinedObjectLoc;
    public GameObject joinObjectSmallCollider;

    bool collisionAlreadyOccurred = false;
    // Use this for initialization
    void Start()
    {
//        Debug.Log("Cylinder1 loc start: " + combinedObjectLoc.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("other:" + other.name);
        Debug.Log("this:" + this.name);

        //if (other.gameObject.name == "Cylinder2" && !collisionAlreadyOccurred)
        if (other.gameObject.CompareTag("joinCollider")
            //&& other.gameObject.name == "Cylinder2Collider"
            && other.gameObject.name == joinObjectSmallCollider.name
            && !collisionAlreadyOccurred)
        {
            // Check alignment

            Vector3 othervec = other.bounds.max - other.bounds.min;
            //Debug.Log("othervec:" + othervec);
            collisionAlreadyOccurred = true;
            Transform combinedObjectLoc;
            combinedObjectLoc = gameObject.transform;
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);

            //Debug.Log("Collision with Cylinder 2 detected \n");
            //Debug.Log("Cylinder1 loc: " + combinedObjectLoc.position);


            //Debug.Log(Sphere1Loc.position);
            Rigidbody partialInstance;
           
            OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();

            Debug.Log("Combined Object:" + combinedObject);


            partialInstance = Instantiate(combinedObject, Lefthand.transform.position, new Quaternion(0, 0, 0, 1)) as Rigidbody;
            //partialInstance = Instantiate(combinedObject, Lefthand.transform.position, Lefthand.transform.rotation) as Rigidbody;
            //partialInstance = Instantiate(combinedObject, combinedObjectLoc.transform.position, combinedObjectLoc.rotation) as Rigidbody;

            //Debug.Log("partial instance:" + partialInstance);


            //GameObject partial = Instantiate(combinedObject) as GameObject;
            //Vector3 newVector =  new Vector3((float) 1.59, (float) -.9505, (float) -2.451);
            //partial.transform.position = Lefthand.transform.position;
            //(1.59, -.9505, -2.451);
            //Debug.Log("Partial 3 loc: " + partialInstance.transform.position);
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
