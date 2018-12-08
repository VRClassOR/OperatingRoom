﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class KeepingScore : MonoBehaviour {

    public static int Score = 0;
    double timer = 0.0;
    TextMeshProUGUI textMesh;

    private void Start()
    {
        Canvas canvas = GameObject.Find("ScoreKeeper").GetComponentInChildren<Canvas>();
        GameObject canvasText = canvas.transform.Find("Text").gameObject;
        textMesh = canvasText.GetComponent<TextMeshProUGUI>();
    }

    private void OnGUI()
    {
        textMesh.text = "Score: " + Score.ToString() + "\n" + GameTimerScript.gameTimerText;
            
    }
}
