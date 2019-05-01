using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_data : MonoBehaviour {

    //This is the transform relative to the parent tool. Consider
    //Driver
    //    Connector_Collider
    //This script is on Connector_Collider, and my RelativeTransform is what the transform of
    //connector is when it is a child of driver.

    //public Dictionary<string, Vector3> relativePosDict = new Dictionary<string, Vector3>();
    //public List<Vector3> relativePosList = new List<Vector3>();

    public Vector3 myRelativePos1;// = new Vector3(-28.69999f, 10.10001f, 306.9997f);
    public Vector3 myRelativePos2;// = new Vector3(0f, 0f, 0f);
    public Quaternion myRelativeRotation;
    // Use this for initialization
    void Start () {
        //relativePosDict.Add("DrivingCap", new Vector3(-38.99997f, -9.379983f, -212.3852f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
