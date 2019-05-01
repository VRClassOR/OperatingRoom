using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartedScript : MonoBehaviour {

    public static bool isGameStarted = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setTrue()
    {
        isGameStarted = true;
    }

    public void setFalse()
    {
        isGameStarted = false;
    }
}
