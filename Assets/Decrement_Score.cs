using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decrement_Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //If we connect with the right object, up the score. If the wrong object, down the score
        //no points for collissions with hands

        if (other.gameObject.CompareTag("Instrument") && other.gameObject.name != "Cylinder2")
        {
            KeepingScore.Score -= 100;
            Debug.Log("gameObject name: " + gameObject.name + "\n");
            Debug.Log("OTHER gameObject name: " + other.gameObject.name + "\n");
        }

    }

}
