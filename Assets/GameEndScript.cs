using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour {

    TextMeshProUGUI textMesh;
    public static bool gameEnded = false;

    private void Start()
    {
        Canvas canvas = GameObject.Find("GameFinished").GetComponentInChildren<Canvas>();
        GameObject canvasText = canvas.transform.Find("Text").gameObject;
        textMesh = canvasText.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {

    }

    private void OnGUI()
    {
        if (gameEnded)
        {
            textMesh.text = "Great Job!!";
        }
    }
}

