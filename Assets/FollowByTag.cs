using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowByTag : MonoBehaviour {
    public bool isAttached = false;
    private GameObject[] joinedObjects;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isAttached)
        {
            joinedObjects = GameObject.FindGameObjectsWithTag("isJoined");
            foreach(GameObject obj in joinedObjects)
            {

            }
        }
		
	}
}
