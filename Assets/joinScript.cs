using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{
    public Rigidbody combinedObject;
    public GameObject joinObjectSmallCollider;

    bool collisionAlreadyOccurred = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc = gameObject.transform;
                Destroy(gameObject.transform.parent.gameObject);
                Destroy(other.gameObject.transform.parent.gameObject);

                OVRGrabber Lefthand = GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>();
                OVRGrabber Righthand = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
                Vector3 newLoc = (Lefthand.transform.position + Righthand.transform.position) / 2;

                Rigidbody partialInstance;
                partialInstance = Instantiate(combinedObject, newLoc, combinedObjectLoc.rotation) as Rigidbody;
                KeepingScore.Score += 50;

                //DoubleCheck GameOver
                if(combinedObject.name == "FinalTFN_Empty")
                {
                    //stop timer
                    GameTimerScript.gameOver = true;
                    GameEndScript.gameEnded = true;
                }
            }
        }  
    }
}
