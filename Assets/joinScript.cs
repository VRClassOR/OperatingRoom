using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinScript : MonoBehaviour
{
    public GameObject joinObjectSmallCollider;
    public GameObject nextObject;
    private AudioSource audioSource;
    public AudioClip goodClip;
    public GameObject currentObjTransparent;
    public bool unjoin; //check this if you are unjoining objects
    public GameObject unjoinObject;

    bool collisionAlreadyOccurred = false;
    private GameObject joinObject_this;
    private GameObject joinObject_other;
    private GameObject AssemblyManager; //pass in from child collider
    private bool isUnjoined = false;
    private bool userCanUnjoin = false;

    public GameObject[] follows;

    private void Start()
    {
        if(joinObjectSmallCollider != null)
        {
            joinObject_other = joinObjectSmallCollider.transform.parent.gameObject;
            joinObject_this = gameObject.transform.parent.gameObject;
        }

    }

    private void Update()
    {
        if(currentObjTransparent!= null && !TutorialModeScript.isTutorialModeActivated)
        {
            if(currentObjTransparent.name != "Driver_Transparent_2")
            {
                currentObjTransparent.SetActive(false);
            }
        }
        if (unjoin && unjoinObject != null && !isUnjoined)
        {
            OVRGrabbable grabbableScript_unjoinObject = unjoinObject.GetComponent<OVRGrabbable>();

            if (grabbableScript_unjoinObject.isGrabbed)
            {
                unjoinObject.tag = "Instrument";
                unjoinObject.transform.parent = null; //detach parent
                isUnjoined = true;
                Debug.Log(unjoinObject + " parent set to null");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && joinObjectSmallCollider != null)
        {
            if (other.gameObject.CompareTag("joinCollider") && other.gameObject.name == joinObjectSmallCollider.name
           && !collisionAlreadyOccurred)
            {
                collisionAlreadyOccurred = true;
                Transform combinedObjectLoc = gameObject.transform;

                //null reference check
                AssemblyManager = joinObject_this.GetComponent<GameObject_data>().AssemblyManager;
                GameObject AssemblyManager_other = joinObject_other.GetComponent<GameObject_data>().AssemblyManager;

                if (unjoin)
                {
                    unjoinObject.tag = "Instrument";
                } else
                {
                    joinObject_other.tag = "isJoined";
                    joinObject_this.tag = "isJoined";
                }

                if (AssemblyManager != AssemblyManager_other)
                {
                    follows = GameObject.FindGameObjectsWithTag("isJoined");

                    //first put under assembly manager other/un-nest anything
                    foreach (GameObject makeFollow in follows)
                    {
                        if (makeFollow.GetComponent<GameObject_data>().AssemblyManager == AssemblyManager_other)
                        {
                            makeFollow.transform.parent = AssemblyManager_other.transform;
                        }
                    }

                    foreach (Transform child in AssemblyManager_other.transform)
                    {
                        child.GetComponent<GameObject_data>().AssemblyManager = AssemblyManager;
                    }
                }

                OVRGrabbable grabbableScript_other = joinObject_other.GetComponent<OVRGrabbable>();
                OVRGrabber other_grabbedBy = grabbableScript_other.grabbedBy;

                if (grabbableScript_other.isGrabbed)
                {
                    other_grabbedBy.GrabEnd();
                }

                OVRGrabbable grabbableScript_this = joinObject_this.GetComponent<OVRGrabbable>();
                OVRGrabber this_grabbedBy = grabbableScript_this.grabbedBy;
                if (grabbableScript_this.isGrabbed)
                {
                    this_grabbedBy.GrabEnd();
                }

                joinObject_other.transform.position = currentObjTransparent.transform.position;
                joinObject_other.transform.rotation = currentObjTransparent.transform.rotation;

                joinObject_other.GetComponent<Renderer>().material.color = Color.green;

                if (other_grabbedBy != null)
                {
                    other_grabbedBy.GrabBegin();
                }

                joinObject_this.GetComponent<Renderer>().material.color = Color.green;

                if (this_grabbedBy != null)
                {
                    this_grabbedBy.GrabBegin();
                }

                audioSource = GetComponent<AudioSource>();
                audioSource.clip = goodClip;
                audioSource.Play();

                //isAttached = true;

                if(nextObject != null)
                {
                    nextObject.SetActive(true);
                }

                currentObjTransparent.SetActive(false);

                KeepingScore.Score += 50;

                //DoubleCheck GameOver
                if(nextObject.name == "Finished_Flag")
                {
                    //stop timer
                    GameTimerScript.gameOver = true;
                    GameEndScript.gameEnded = true;
               
                }
            }
        }  
    }
}
