using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere1 : MonoBehaviour {
    public Rigidbody Partial3;
    public Transform Sphere1Loc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sphere2"))
        {
            Debug.Log(Sphere1Loc.position);
            Sphere1Loc = gameObject.transform;
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            Debug.Log(Sphere1Loc.position);
            Rigidbody partialInstance;
            partialInstance = Instantiate(Partial3, Sphere1Loc.position, Sphere1Loc.rotation) as Rigidbody;
        }
    }
}
