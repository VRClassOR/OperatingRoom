using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerScript : MonoBehaviour {
    public Text gameTimerText;
    float gameTimer = 0f;
    int minuteElapsedForScoring = 0;

	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;
        //Need to decrement Score if time goes up. Time is likely very small so converting to int won't be possible.
        

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        if(minutes > minuteElapsedForScoring)
        {
            KeepingScore.Score -= 100;
            minuteElapsedForScoring = minutes;
        }

        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimerText.text = timerString;
	}
}
