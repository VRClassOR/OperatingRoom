using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{
    public Rigidbody combinedObject; //delete later, do not use
    public GameObject joinObjectSmallCollider;
    public GameObject nextObject;
    private AudioSource audioSource;
    public AudioClip goodClip;
    //public GameObject nextObjectTransparent;
    public GameObject currentObjTransparent;

    bool collisionAlreadyOccurred = false;
    private bool isAttached = false;
    private GameObject joinObject_this;
    private GameObject joinObject_other;
    private GameObject AssemblyManager; //pass in from child collider

    public GameObject[] follows;

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("GameObject: " + gameObject);
        //Debug.Log("other: " + other);
        //if (other != null && joinObjectSmallCollider != null)
        //{
        //    if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name
        //   && !collisionAlreadyOccurred)
        //    {
        //        Debug.Log("OnTriggerExit called with other: " + other);
        //    }
        //}

        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name)
            //&& !collisionAlreadyOccurred)
            {
                Debug.Log("OnTriggerExit called");
                //follows = GameObject.FindGameObjectsWithTag("isJoined");
                //foreach (GameObject makeFollow in follows)
                //{
                //    makeFollow.transform.parent = gameObject.transform;
                //}
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("assembly manager position: " + AssemblyManager.transform.position);
        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
                collisionAlreadyOccurred = true;
                //AssemblyManager = GameObject.Find("AssemblyManager");
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

                //null reference check
                AssemblyManager = joinObject_this.GetComponent<GameObject_data>().AssemblyManager; //what if join_object_other and joinObject_this have different assembly managers?
                GameObject AssemblyManager_other = joinObject_other.GetComponent<GameObject_data>().AssemblyManager;
                //Debug.Log("joinObjSmallCollider: " + joinObjectSmallCollider.name);
                //Debug.Log("join object other: " + joinObject_other.name);
                //make this and join object children of AssemblyManager

                //joinObject_other.transform.parent = AssemblyManager.transform;
                //joinObject_this.transform.parent = AssemblyManager.transform;

                //Debug.Log("joinObject_other.transform.position: " + joinObject_other.transform.position);

                joinObject_other.tag = "isJoined";
                joinObject_this.tag = "isJoined";
                if(AssemblyManager != AssemblyManager_other)
                {
                    follows = GameObject.FindGameObjectsWithTag("isJoined");

                    //first put under assembly manager other/un-nest anything
                    foreach (GameObject makeFollow in follows)
                    {
                        if (makeFollow.GetComponent<GameObject_data>().AssemblyManager == AssemblyManager_other)
                        {
                            //Debug.Log("TEST " + makeFollow.GetComponent<GameObject_data>().AssemblyManager);
                            //makeFollow.transform.parent = gameObject.transform;
                            makeFollow.transform.parent = AssemblyManager_other.transform;
                            //Debug.Log("Step 1" + makeFollow + "is now a child of " + gameObject);
                        }
                        //Debug.Log("gameObject.transform: " + gameObject);
                    }

                    //int children = AssemblyManager_other.transform.childCount;
                    //Debug.Log("AssemblyManager_other.transform num children: " + children);

                    foreach (Transform child in AssemblyManager_other.transform)
                    {
                        //Debug.Log("child in AssemblyManager_other: " + child);
                        //Debug.Log(child + " AM: " + child.GetComponent<GameObject_data>().AssemblyManager);
                        child.GetComponent<GameObject_data>().AssemblyManager = AssemblyManager;
                        //Debug.Log(child + " AM: " + child.GetComponent<GameObject_data>().AssemblyManager);
                    }
                    //joinObject_other.GetComponent<GameObject_data>().AssemblyManager = AssemblyManager; //<-- need to do this for all things in old assembly manager
                    //AssemblyManager_other.tag = "isJoined";
                }

                //joinObject_other.transform.parent = AssemblyManager.transform;
                //joinObject_this.transform.parent = AssemblyManager.transform;

                //OVRPose trackingSpace = transform.ToOVRPose() * localPose.Inverse();
                //Vector3 linearVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerVelocity(m_controller);
                //Vector3 angularVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerAngularVelocity(m_controller);

                OVRGrabbable grabbableScript_other = joinObject_other.GetComponent<OVRGrabbable>();
                OVRGrabber other_grabbedBy = grabbableScript_other.grabbedBy;

                Vector3 other_position = joinObject_other.transform.position;
                Vector3 this_position = joinObject_this.transform.position;

                //Debug.Log("other position: " + other_position);

                if (grabbableScript_other.isGrabbed)
                {
                    other_grabbedBy.GrabEnd();
                    //Collider other_grabPoints = grabbableScript_other.grabPoints;
                    //grabbableScript_other.GrabBegin(other_grabbedBy, other_grabPoints);
                }

                //Vector3 thePosition = joinObject_this.transform.TransformPoint(new Vector3(-35.62242f, 21.03972f, -85.46162f));

                //Vector3 posDif = new Vector3((-0.1807941f - 0.1997525f), (1.503024f - 1.498708f), (-3.31163f - 3.27729f));
                Vector3 myRelPos = this.gameObject.GetComponent<collider_data>().myRelativePos1;
                Vector3 thePosition = joinObject_this.transform.TransformPoint(myRelPos);
                //Vector3 thePosition = joinObject_this.transform.TransformPoint(-34f, 9f, 308f);
                //Vector3 thePosition = transform.TransformPoint(-32.75218f, 8.096404f, 293.407f);
                //-0.1807941, 1.503024, -3.31163 //cyl1 pos

                /////////////////////////////
             
                joinObject_other.transform.position = thePosition;
                //joinObject_other.transform.position = other_position + new Vector3(.1f, .1f, .1f);

                joinObject_other.GetComponent<Renderer>().material.color = Color.green;

                //Debug.Log("other moved to: " + joinObject_other.transform.position);
                //joinObject_other.transform.position = joinObject_this.transform.position + posDif;
                

                if (other_grabbedBy != null)
                {
                    other_grabbedBy.GrabBegin();
                }

                OVRGrabbable grabbableScript_this = joinObject_this.GetComponent<OVRGrabbable>();
                OVRGrabber this_grabbedBy = grabbableScript_this.grabbedBy;
                if (grabbableScript_this.isGrabbed)
                {
                    this_grabbedBy.GrabEnd();
                }
                ///////////////////////////////
                //joinObject_this.transform.position = other_position + new Vector3(-.1f, -.1f, -.1f);
                joinObject_this.GetComponent<Renderer>().material.color = Color.green;

                if (this_grabbedBy != null)
                {
                    this_grabbedBy.GrabBegin();
                }

                //Debug.Log("End of script other moved to: " + joinObject_other.transform.position);

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

                //GameObject AssemblyManager = GameObject.Find("AssemblyManager");
                //Follow followScript = AssemblyManager.GetComponent<Follow>();
                //followScript.addFollow(gameObject, AssemblyManager); //not sure if you need to pass in Assembly Manager

                audioSource = GetComponent<AudioSource>();
                audioSource.clip = goodClip;
                audioSource.Play();

                isAttached = true;

                if(nextObject != null)
                {
                    nextObject.SetActive(true);
                    // nextObjectTransparent.SetActive(true);
                } else {
                    //AssemblyManager.tag = "isJoined";
                    //AssemblyManager.GetComponent<GameObject_data>().enabled = true;
                }

                currentObjTransparent.SetActive(false);

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
