using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameTimerScript : MonoBehaviour {
    public static string gameTimerText;
    float gameTimer = 0f;
    int secondsElapsedForScoring = 0;
    public static bool gameOver = false;
    public static bool timeStarted = false;

    void Update() {
        //if(timeStarted)
        //{
            //stop timer if game is over
            if (!gameOver && timeStarted)
            {
                gameTimer += Time.deltaTime;
            }

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            int hours = (int)(gameTimer / 3600) % 24;

            //Debug.Log("SECONDS = " + seconds);
            //Debug.Log("SECONDSELAPSEDFORSCORING = " + secondsElapsedForScoring);

            //Decrease score by 3 each second
            if ((minutes * 60) + seconds > secondsElapsedForScoring)
            {
                KeepingScore.Score -= 3;
                secondsElapsedForScoring = (minutes * 60) + seconds;
            }

            string timerString = string.Format("{0}:{1:00}", minutes, seconds);
            gameTimerText = timerString;
        //}
	}

    public void setZero()
    {
        gameTimer = 0f;
    }

    public void startTimer()
    {
        gameTimer = 0f;
        timeStarted = true;
    }

    public void Reset()
    {
        SceneManager.LoadScene("OperatingRoomScene");
        gameTimer = 0f;
        KeepingScore.Score = 0;
        timeStarted = false;
        TutorialModeScript.isTutorialModeActivated = true;
        GameObject starterObject = GameObject.Find("GuideConnector_Transparent"); //must have this to make tutorial mode work
        if(starterObject != null)
        {
            starterObject.SetActive(true);
        }
        gameOver = false;
        GameEndScript.gameEnded = false;
    }
}
