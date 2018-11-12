using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labelsOnScript : MonoBehaviour {

    public bool shouldDisplayText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        shouldDisplayText = true;

    }

    void OnTriggerExit(Collider other)
    {
        shouldDisplayText = false;
    }

    void OnshouldDisplayText()
    {
        if (shouldDisplayText)
        {
            Debug.Log("test");
        }
    }
}
