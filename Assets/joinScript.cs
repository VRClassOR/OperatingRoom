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

                //Follow.follow = joinObject_this.transform;
                Follow.follows.Add(joinObject_this.transform);
                Follow.follows.Add(joinObject_other.transform);

                Follow.originalLocalPosition = joinObject_this.transform.localPosition;
                Follow.originalLocalRotation = joinObject_this.transform.localRotation;

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
