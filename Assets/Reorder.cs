using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reorder : MonoBehaviour {

    private GameObject driver;
    private GameObject aimingArm;
    private GameObject handle;
    private GameObject guideConnector;
    private GameObject connector;
    private GameObject nail;
    private GameObject drivingCap;

    // Use this for initialization
    void Start () {
        driver = GameObject.Find("Driver");
        aimingArm = GameObject.Find("Aiming Arm");
        handle = GameObject.Find("Handle");
        guideConnector = GameObject.Find("Guide Connector");
        connector = GameObject.Find("Connector");
        nail = GameObject.Find("Nail");
        drivingCap = GameObject.Find("Driving Cap");
        reorder1();
        //reorder2();
        //reorder3();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //left to right: Driver, AimingArm, Handle, Guide Connector, Connector, Nail, Driver
    public void reorder1()
    {
        driver.transform.position = new Vector3(1.329f, 1.014f, -5.851f);
        aimingArm.transform.position = new Vector3(1.133f, 1.013f, -5.753f);
        handle.transform.position = new Vector3(0.962f, 1.006f, -5.626f);
        guideConnector.transform.position = new Vector3(0.659f, 1.01f, -5.543f);
        connector.transform.position = new Vector3(0.538f, 1.027f, -5.544f);
        nail.transform.position = new Vector3(0.502f, 1.009413f, -5.82784f);
        drivingCap.transform.position = new Vector3(0.316f, 1.009413f, -5.73601f);
    }

    public void reorder2()
    {

    }

    public void reorder3()
    {

    }
}
