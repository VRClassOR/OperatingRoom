using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hapticScript : MonoBehaviour {

    public GameObject correctCollider;
    public AudioClip correctAudioClip;
    public AudioClip incorrectAudioClip;
    //bool collisionAlreadyOccurred = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        byte[] noise = { 255 };

        Debug.Log("sound file played");
        OVRHapticsClip rhapticsClip = new OVRHapticsClip(correctAudioClip);
        OVRHapticsClip lhapticsClip = new OVRHapticsClip(incorrectAudioClip);
        OVRHaptics.LeftChannel.Preempt(lhapticsClip);
        OVRHaptics.RightChannel.Preempt(rhapticsClip);
        //OVRHaptics.Channels[1].Preempt(new OVRHapticsClip(noise, 1));

        //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);


    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.gameObject.CompareTag("Instrument"))
        {
            Debug.Log("2");
            OVRHapticsClip hapticsClip;
            if (collision.gameObject == correctCollider)
            {
                Debug.Log("3");
                hapticsClip = new OVRHapticsClip(correctAudioClip);
            }
            else
            {
                Debug.Log("4");
                hapticsClip = new OVRHapticsClip(incorrectAudioClip);
            }
            Debug.Log("5");
            //if (m_controller == OVRInput.Controller.LTouch)
            //{
            OVRHaptics.LeftChannel.Preempt(hapticsClip);
            //}
            //else {
            OVRHaptics.RightChannel.Preempt(hapticsClip);
            //}
        }
    }
}
