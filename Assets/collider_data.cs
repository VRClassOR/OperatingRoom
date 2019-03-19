using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_data : MonoBehaviour {

    //This is the transform relative to the parent tool. Consider
    //Driver
    //    Connector_Collider
    //This script is on Connector_Collider, and my RelativeTransform is what the transform of
    //connector is when it is a child of driver.
    public Transform myRelativeTransform;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
