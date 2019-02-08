using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{
    public Rigidbody combinedObject;
    public GameObject joinObjectSmallCollider;
    public GameObject AssemblyManager;

    bool collisionAlreadyOccurred = false;
    private bool isAttached = false;

    private void Update()
    {
        if(isAttached)
        {
            //call method that changes position. this way, once the grabber is let go of, it snaps into place
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc = gameObject.transform;
                //Debug.Log("destroy, me: " + gameObject.transform.parent.gameObject);
                //Debug.Log("destroy, other: " + other.gameObject.transform.parent.gameObject);
                //Destroy(gameObject.transform.parent.gameObject);
                //Destroy(other.gameObject.transform.parent.gameObject);

                OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();
                OVRGrabber Righthand = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
                Vector3 newLoc = (Lefthand.transform.position + Righthand.transform.position) / 2;
                //Vector3 newLoc = combinedObjectLoc.position;

                //maybe switch so joinObject is public global variable, and retrieve small collider?
                GameObject joinObject_other = joinObjectSmallCollider.transform.parent.gameObject;
                GameObject joinObject_this = gameObject.transform.parent.gameObject;
                Debug.Log("joinObjSmallCollider: " + joinObjectSmallCollider.name);
                Debug.Log("join object other: " + joinObject_other.name);
                AssemblyManager = GameObject.Find("AssemblyManager");
                //make this and join object children of AssemblyManager
                joinObject_other.transform.parent = AssemblyManager.transform;
                joinObject_this.transform.parent = AssemblyManager.transform;
                //fix position of this and join object
                joinObject_other.transform.localPosition = new Vector3(0f, 0f, 0f); //since using localPosition, (0 0 0) sets to position of assemblyManager
                joinObject_this.transform.localPosition = new Vector3(1f, 1f, 1f);

                //rhs is parent transform of gameObject, which is a smallCollider
                //joinObject.transform.parent = gameObject.transform.parent.gameObject.transform;
                //joinObject.transform.position = new Vector3(-.5f, 1.47f, -3f); //make vec a variable

                //Rigidbody partialInstance;
                //partialInstance = Instantiate(combinedObject, newLoc, combinedObjectLoc.rotation) as Rigidbody;
                KeepingScore.Score += 50;

                //DoubleCheck GameOver
                if(combinedObject.name == "FinalTFN_Empty")
                {
                    //stop timer
                    GameTimerScript.gameOver = true;
                    GameEndScript.gameEnded = true;
                }
            }
        }  
    }
}
