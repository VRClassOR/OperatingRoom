using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreCylinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Can't test this meethod until we figure out why a NullException is being thrown when you put
    //the two cylinders together
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.name == "Cylinder2Collider")
    //    {
    //        KeepingScore.Score += 100;
    //        Destroy(gameObject);
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {

        KeepingScore.Score += 100;

    }
}
