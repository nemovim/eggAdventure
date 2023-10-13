using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public float time = 0;
    private bool isRunning = false;

    public UnityEvent OnTimerEnd;

    void FixedUpdate()
    {
        // 0.02 seconds
        if (isRunning)
        {
            if (time == 0)
            {
                OnTimerEnd?.Invoke();
            }
            else
            {
                time -= 20;
            }
        }
    }

    public void ResetTimer(float timeLimit)
    {
        time = timeLimit;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
