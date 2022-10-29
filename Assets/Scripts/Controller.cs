using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public Timer timer;
    public float timeLimit = 0;
    public Ball ball;

    public TextMeshProUGUI txt; 
    public Canvas canvas;

    public void Start() {
        timer.ResetTimer(timeLimit);
        timer.StartTimer();
    }

    public void Update() {
        showTime();
    }

    public void showTime() {
        txt.text = (string.Format("{0:N1}", timer.time/1000)) + 's';
    }

    public void showResult() {
        canvas.enabled = true;
    }
}
