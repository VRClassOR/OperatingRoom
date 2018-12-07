using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/* 
 * When the game ends, display a canvas with text
 * that signals to the user that the game is over.
*/
public class GameEndScript : MonoBehaviour {

    TextMeshProUGUI textMesh;
    public static bool gameEnded = false;

    // At program start, instantiate a canvas that will
    // indicate to the user when the game is over.
    private void Start()
    {
        Canvas canvas = GameObject.Find("GameFinished").GetComponentInChildren<Canvas>();
        GameObject canvasText = canvas.transform.Find("Text").gameObject;
        textMesh = canvasText.GetComponent<TextMeshProUGUI>();
    }

    // When the game ends (the final piece is assembled)
    // the timer is halted and the canvas indicates to the 
    // user that the game is over.
    private void OnGUI()
    {   
        if (gameEnded)
        {
            textMesh.text = "Great Job!!";
        }
    }
}

