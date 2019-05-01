using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialModeScript : MonoBehaviour {

    public static bool isTutorialModeActivated = true;
    public bool viewTransparentObj;
    public GameObject[] transparentInstruments;

    // Use this for initialization
    void Start () {
        isTutorialModeActivated = isTutorialModeActivated && viewTransparentObj;
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
