using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable_assembly : OVRGrabbable
{
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        Debug.Log("Grab Begin override called");
        GameObject AssemblyManager = GameObject.Find("AssemblyManager");
        Follow followScript = AssemblyManager.GetComponent<Follow>();
        followScript.addFollow(gameObject);
    }
    //public override bool isGrabbed
    //{
    //    //FollowMe followScript_other = joinObject_other.GetComponent<FollowMe>();
    //    get {
    //        Debug.Log("isGrabbed override called");
    //        GameObject AssemblyManager = GameObject.Find("AssemblyManager");
    //        Follow followScript = AssemblyManager.GetComponent<Follow>();
    //        followScript.addFollow(gameObject);
    //        return base.m_grabbedBy != null; }
    //}
}
