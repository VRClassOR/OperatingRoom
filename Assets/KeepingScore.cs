using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepingScore : MonoBehaviour {

    public static int Score = 0;
    double timer = 0.0;
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        // Score += (int)timer;

	}

    private void OnGUI()
    {
        GUI.Box(new Rect(50,50,100,100), Score.ToString());
    }
}
