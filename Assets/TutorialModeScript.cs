using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialModeScript : MonoBehaviour {

    public static bool isTutorialModeActivated = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggle()
    {
        isTutorialModeActivated = !isTutorialModeActivated;
    }
}
