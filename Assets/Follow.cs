using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://github.com/Nova840/Miscellaneous/blob/master/Follow.cs

public class Follow : MonoBehaviour {

    [SerializeField]

    //public Transform follow = null;
    public static List<Transform> follows = new List<Transform>();
    public static Transform follow;
        //= null; //made static bc??



    public static Vector3 originalLocalPosition;

    public static Quaternion originalLocalRotation;

    //private Vector3 originalLocalPosition;

    //private Quaternion originalLocalRotation;



    //private void Awake()
    //{

    //originalLocalPosition = follow.localPosition;

    //originalLocalRotation = follow.localRotation;

    //}



    private void Update()
    {
        if (follows != null)
        {
            foreach(Transform follow in follows)
            {
                //move the parent to child's position

                transform.position = follow.position;

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

}
