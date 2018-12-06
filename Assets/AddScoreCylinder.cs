using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreCylinder : MonoBehaviour {

    public GameObject joinObjectSmallCollider;
    public GameObject joinObjectParentCollider;

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
        //If we connect with the right object, up the score. If the wrong object, down the score
        //no points for collissions with hands
        if (other != null && joinObjectParentCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name)
            {
                KeepingScore.Score += 100;
                Debug.Log("gameObject name: " + gameObject.name + "\n");
                Debug.Log("OTHER gameObject name: " + other.gameObject.name + "\n");
                /*if (other.gameObject.name == "Cylinder2" 
                    && transform.GetChild(0).tag == "joinCollider") //tag == "joinCollider")
                { 
                    KeepingScore.Score += 100;
                }
                */
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Instrument"))
        {
            Debug.Log("gameObject name: " + gameObject.name + "\n");
            Debug.Log("OTHER gameObject name: " + other.gameObject.name + "\n");
            if (other != null && joinObjectParentCollider != null)
            {
                if (other.gameObject.name != joinObjectParentCollider.name) ;
                {
                    KeepingScore.Score -= 100;
                }
            }
            
        }
    }
}
