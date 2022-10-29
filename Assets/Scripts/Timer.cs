using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float time = 0;
    private bool isRunning = false;

    public string nextStage = "main";

    void FixedUpdate()
    {
        // 0.02 seconds
        if (isRunning) {
            if (time == 0 && nextStage == "main") {
                SceneManager.LoadScene("Main");
            } else if (time == 0 && nextStage == "stage") {
                SceneManager.LoadScene("Stage 3");
            }
            time -= 20;
        }
    }

    public void ResetTimer(float timeLimit) {
        time = timeLimit;
    }

    public void StartTimer() {
        isRunning = true;
    }

    public void StopTimer() {
        isRunning = false;
    }
}
