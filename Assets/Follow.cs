using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://github.com/Nova840/Miscellaneous/blob/master/Follow.cs

public class Follow : MonoBehaviour {

    [SerializeField]

    private GameObject follow_GO = null;

    private Transform follow;

    private Vector3 originalLocalPosition;

    private Quaternion originalLocalRotation;

    private OVRGrabbable grabbableScript;

    //private List<GameObject> childrenList = new List<GameObject>();

    //public static List<GameObject> follows = new List<GameObject>();
    public GameObject[] follows;
    //public static Transform follow;
    //= null; //made static bc??

    //public static Vector3 originalLocalPosition;

    //public static Quaternion originalLocalRotation;

    public void addFollow(GameObject follow)
    {
        Debug.Log("follow added");
        //if (this.follow_GO == null)
        //{
        this.follow_GO = follow;
        this.follow = follow_GO.transform;

        //Debug.Log("originalLocalPosition trash: " + originalLocalPosition);

        originalLocalPosition = this.follow.localPosition;

        originalLocalRotation = this.follow.localRotation;

        grabbableScript = follow_GO.GetComponent<OVRGrabbable>();
        //init();
        //}

        follows = GameObject.FindGameObjectsWithTag("isJoined");

        //first put under assembly manager/un-nest anything
        foreach (GameObject makeFollow in follows)
        {
            if(makeFollow.GetComponent<GameObject_data>().AssemblyManager == this.gameObject)
            {
                makeFollow.transform.parent = gameObject.transform;
            }
            //Debug.Log("gameObject.transform: " + gameObject);
        }

        //second, make the grabbed object the parent of follows (with assembly manager the ultimate parent)
        foreach (GameObject makeFollow in follows)
        {
            if(makeFollow.name != follow_GO.name &&
                makeFollow.GetComponent<GameObject_data>().AssemblyManager == this.gameObject)
            {
                makeFollow.transform.parent = this.follow;
                //Debug.Log(makeFollow + " is a child of " + this.follow);
            }
        }

        //foreach (Transform child in gameObject.transform)
        //{
        //    if(child.gameObject.name != follow_GO.name)
        //    {
        //        child.parent = this.follow;
        //    }
        //    //move the parent to child's position
        //    //childrenList.Add(child.gameObject);
        //    //childTransformList.Add(child.gameObject.transform);
        //}

        //Debug.Log("originalLocalPosition original: " + originalLocalPosition);
    }

    public void removeFollow(GameObject follow)
    {
        //follows = null;
        //Debug.Log("follow removed");
        //if(follow_GO == follow)
        //{
        //    this.follow_GO = null;
        //}
        //set is attached to false
    }

    private void init() //comment out when using join script
    {
        //if (follow != null)
        //{
            follow = follow_GO.transform;

            originalLocalPosition = follow.localPosition;

            originalLocalRotation = follow.localRotation;
            //Debug.Log("awake called");
            //Debug.Log("Follow: " + follow);
            //Debug.Log("local Pos " + originalLocalPosition);
            //Debug.Log("local Rotation " + originalLocalRotation);

            //grabbableScript = follow_GO.GetComponent<OVRGrabbable>();
        //}

 
    }

    //private void Update()
    //{
    //    if (follow_GO != null && follow != null && !grabbableScript.isGrabbed)
    //    {
    //        //Debug.Log("follow update called");
    //        //Debug.Log("originalLocalPosition: " + originalLocalPosition);
    //        GameObject tempParent = follow.parent.gameObject;

    //        follow.parent = null;

    //        //Vector3 tempVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //        //Debug.Log("follow not null");
    //        //Debug.Log("Follow: " + follow);
    //        //originalLocalPosition = follow.localPosition; //should i create a struct?
    //        //originalLocalRotation = follow.localRotation;
    //        //if (originalLocalRotation != null)
    //        //{


    //        //move the parent to child's position

    //        //transform.position += new Vector3(0f, 0.0005f, 0f);

    //        //Debug.Log("Follow position: " + follow.position);

    //        transform.position = follow.position;

    //        //HAS TO BE IN THIS ORDER

    //        //sort of "reverses" the quaternion so that the local rotation is 0 if it is equal to the original local rotation

    //        follow.RotateAround(follow.position, follow.forward, -originalLocalRotation.eulerAngles.z);

    //        follow.RotateAround(follow.position, follow.right, -originalLocalRotation.eulerAngles.x);

    //        follow.RotateAround(follow.position, follow.up, -originalLocalRotation.eulerAngles.y);

    //        //rotate the parent

    //        transform.rotation = follow.rotation;

    //        //moves the parent by the child's original offset from the parent
    //        //Vector3 tempVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    //        //tempVector += -transform.right * originalLocalPosition.x;

    //        //tempVector += -transform.up * originalLocalPosition.y;

    //        //tempVector += -transform.forward * originalLocalPosition.z;

    //        //transform.position = tempVector;

    //        transform.position += -transform.right * originalLocalPosition.x;

    //        transform.position += -transform.up * originalLocalPosition.y;

    //        transform.position += -transform.forward * originalLocalPosition.z;

    //        follow.parent = tempParent.transform;

    //        //resets local rotation, undoing step 2

    //        follow.localRotation = originalLocalRotation;

    //        //reset local position

    //        follow.localPosition = originalLocalPosition;

    //        //}

    //    }


    //}

    //private void Update()
    //{
    //    if (follows != null)
    //    {
    //        foreach (Transform follow in follows)
    //        {
    //            //originalLocalPosition = follow.localPosition; //should i create a struct?
    //            //originalLocalRotation = follow.localRotation;
    //            if (originalLocalRotation != null)
    //            {
    //                //move the parent to child's position

    //                transform.position = follow.position;

    //                //HAS TO BE IN THIS ORDER

    //                //sort of "reverses" the quaternion so that the local rotation is 0 if it is equal to the original local rotation

    //                follow.RotateAround(follow.position, follow.forward, -originalLocalRotation.eulerAngles.z);

    //                follow.RotateAround(follow.position, follow.right, -originalLocalRotation.eulerAngles.x);

    //                follow.RotateAround(follow.position, follow.up, -originalLocalRotation.eulerAngles.y);

    //                //rotate the parent

    //                transform.rotation = follow.rotation;

    //                //moves the parent by the child's original offset from the parent

    //                transform.position += -transform.right * originalLocalPosition.x;

    //                transform.position += -transform.up * originalLocalPosition.y;

    //                transform.position += -transform.forward * originalLocalPosition.z;

    //                //resets local rotation, undoing step 2

    //                follow.localRotation = originalLocalRotation;

    //                //reset local position

    //                follow.localPosition = originalLocalPosition;
    //            }

    //        }

    //    }


    //  } //end update

}
