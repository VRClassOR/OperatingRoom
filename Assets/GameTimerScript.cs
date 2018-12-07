using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerScript : MonoBehaviour {
    public static string gameTimerText;
    float gameTimer = 0f;
    int secondsElapsedForScoring = 0;
    public static bool gameOver = false;

    void Update() {

        //stop timer if game is over
        if (!gameOver) { 
         gameTimer += Time.deltaTime;
        }
        

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        //Decrease score by 1 each second
        if(seconds > secondsElapsedForScoring)
        {
            KeepingScore.Score -= 1;
            secondsElapsedForScoring = seconds;
            
        }

        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimerText = timerString;
	}
}
