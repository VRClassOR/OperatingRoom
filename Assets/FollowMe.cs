using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour {

    public bool isAttached = false;

    [SerializeField]

    public Transform follow = null;

    public Vector3 originalLocalPosition;

    public Quaternion originalLocalRotation;

    public GameObject AssemblyManager;

    // Use this for initialization
    void Start () {
        AssemblyManager = GameObject.Find("AssemblyManager");
    }
	
	// Update is called once per frame
	void Update () {
		if(isAttached && follow != null)
        {
            //move the parent to child's position

            AssemblyManager.transform.position = follow.position;

            //HAS TO BE IN THIS ORDER

            //sort of "reverses" the quaternion so that the local rotation is 0 if it is equal to the original local rotation

            follow.RotateAround(follow.position, follow.forward, -originalLocalRotation.eulerAngles.z);

            follow.RotateAround(follow.position, follow.right, -originalLocalRotation.eulerAngles.x);

            follow.RotateAround(follow.position, follow.up, -originalLocalRotation.eulerAngles.y);

            //rotate the parent

            transform.rotation = follow.rotation;

            //moves the parent by the child's original offset from the parent

            transform.position += -transform.right * originalLocalPosition.x;

            transform.position += -transform.up * originalLocalPosition.y;

            transform.position += -transform.forward * originalLocalPosition.z;

            //resets local rotation, undoing step 2

            follow.localRotation = originalLocalRotation;

            //reset local position

            follow.localPosition = originalLocalPosition;
        }
	}
}
