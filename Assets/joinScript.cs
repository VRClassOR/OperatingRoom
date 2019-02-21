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
    private GameObject joinObject_this;
    private GameObject joinObject_other;

    private void Update()
    {
        
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
                joinObject_other = joinObjectSmallCollider.transform.parent.gameObject;
                joinObject_this = gameObject.transform.parent.gameObject;
                Debug.Log("joinObjSmallCollider: " + joinObjectSmallCollider.name);
                Debug.Log("join object other: " + joinObject_other.name);
                AssemblyManager = GameObject.Find("AssemblyManager");
                //make this and join object children of AssemblyManager

                joinObject_other.transform.parent = AssemblyManager.transform;
                joinObject_this.transform.parent = AssemblyManager.transform;

                joinObject_other.tag = "isJoined";
                joinObject_this.tag = "isJoined";

                //OVRPose trackingSpace = transform.ToOVRPose() * localPose.Inverse();
                //Vector3 linearVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerVelocity(m_controller);
                //Vector3 angularVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerAngularVelocity(m_controller);

                OVRGrabbable grabbableScript_other = joinObject_other.GetComponent<OVRGrabbable>();
                OVRGrabber other_grabbedBy = grabbableScript_other.grabbedBy;

                Vector3 other_position = joinObject_other.transform.position;

                if (grabbableScript_other.isGrabbed)
                {
                    other_grabbedBy.GrabEnd();
                    //Collider other_grabPoints = grabbableScript_other.grabPoints;
                    //grabbableScript_other.GrabBegin(other_grabbedBy, other_grabPoints);
                }

                Vector3 posDif = new Vector3((-0.1807941f - 0.1997525f), (1.503024f - 1.498708f), (-3.31163f - 3.27729f));

                //-0.1807941, 1.503024, -3.31163 //cyl1 pos

                //0.256, -17.102, -85.687 //cyl1 rot

                //- 0.1997525, 1.498708, -3.27729 //cyl2 pos

                //- 2.594, -104.66, 2.397 //cyl2 rot

                joinObject_other.transform.position = other_position + new Vector3(.3f, .3f, .3f);
                //joinObject_other.transform.position = joinObject_this.transform.position + posDif;
                other_grabbedBy.GrabBegin(); //check if grabbed??

                OVRGrabbable grabbableScript_this = joinObject_this.GetComponent<OVRGrabbable>();
                OVRGrabber this_grabbedBy = grabbableScript_this.grabbedBy;
                if (grabbableScript_this.isGrabbed)
                {
                    this_grabbedBy.GrabEnd();
                }

                joinObject_this.transform.position = other_position + new Vector3(-.3f, -.3f, -.3f);
                this_grabbedBy.GrabBegin();

                //Follow.follow = joinObject_this.transform;
                //Follow.follows.Add(joinObject_this.transform);
                //Follow.follows.Add(joinObject_other.transform);

                //Follow.originalLocalPosition = joinObject_this.transform.localPosition;
                //Follow.originalLocalRotation = joinObject_this.transform.localRotation;

                //FollowMe followScript_other = joinObject_other.GetComponent<FollowMe>();
                //followScript_other.isAttached = true;
                //followScript_other.follow = joinObject_this.transform;
                //followScript_other.originalLocalPosition = joinObject_this.transform.localPosition;
                //followScript_other.originalLocalRotation = joinObject_this.transform.localRotation;

                //FollowMe followScript_this = joinObject_this.GetComponent<FollowMe>();
                //followScript_this.isAttached = true;
                //followScript_this.follow = joinObject_this.transform;
                //followScript_this.originalLocalPosition = joinObject_this.transform.localPosition;
                //followScript_this.originalLocalRotation = joinObject_this.transform.localRotation;

                //joinObject_other.transform.position = new Vector3(0, 0, 0);
                //joinObject_this.transform.position = new Vector3(0, 0, 0);

                isAttached = true;

                //FollowByTag followScript_other = joinObject_other.GetComponent<FollowByTag>();
                //followScript_other.isAttached = true;

                //FollowByTag followScript_this = joinObject_this.GetComponent<FollowByTag>();
                //followScript_this.isAttached = true;

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
