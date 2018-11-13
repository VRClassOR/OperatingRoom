using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFN : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision gameObject name: " + gameObject.name + "\n");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger gameObject name: " + gameObject.name + "\n");
    }
}
