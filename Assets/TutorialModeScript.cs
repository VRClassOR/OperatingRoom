using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialModeScript : MonoBehaviour {

    public static bool isTutorialModeActivated = true;
    public bool viewTransparentObj;
    public GameObject[] transparentInstruments;

    // Use this for initialization
    void Start () {
        //if(turnOffTransparentObj)
        //{
        //    GameObject.Find
        //}
        isTutorialModeActivated = isTutorialModeActivated && viewTransparentObj;
    }
	
	// Update is called once per frame
	void Update () {
        //transparentInstruments = GameObject.FindGameObjectsWithTag("Transparent Instrument");
        //foreach (GameObject transparentInstrument in transparentInstruments)
        //    {
        //        if (!isTutorialModeActivated)
        //        {
        //            transparentInstrument.SetActive(false);
        //        } else
        //        {
        //            transparentInstrument.SetActive(true);
        //        }
                    
        //    }
        //}
	}

    public void toggle()
    {
        isTutorialModeActivated = !isTutorialModeActivated;
    }

    public void setTutorialModeTrue()
    {
        if(viewTransparentObj)
        {
            isTutorialModeActivated = true;
            Debug.Log("Tutorial mode set to true");
        } else
        {
            setTutorialModeFalse();
        }

    }

    public void setTutorialModeFalse()
    {
        isTutorialModeActivated = false;
        Debug.Log("Tutorial mode set to false");
    }
}
