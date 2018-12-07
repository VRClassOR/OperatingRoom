using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{

    public Rigidbody combinedObject;
    public GameObject joinObjectSmallCollider;

    bool collisionAlreadyOccurred = false;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other:" + other.name);
        Debug.Log("this:" + this.name);
        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider")
           && other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
                
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc = gameObject.transform;
                Destroy(gameObject.transform.parent.gameObject);
                Destroy(other.gameObject.transform.parent.gameObject);

                Rigidbody partialInstance;

                OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();

                Debug.Log("Combined Object:" + combinedObject);


                partialInstance = Instantiate(combinedObject, Lefthand.transform.position, combinedObjectLoc.rotation) as Rigidbody;
                KeepingScore.Score += 100;

                //DoubleCheck GameOver
                if(combinedObject.name == "FinalTFN_Empty")
                {
                    //stop timer
                    GameTimerScript.gameOver = true;
                    GameEndScript.gameEnded = true;

                    //display good job

                }

            }
        }
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Display text");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("stop text");
    }

}
