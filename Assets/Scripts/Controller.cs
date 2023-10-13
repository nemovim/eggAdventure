using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{
    private Timer timer;
    public float timeLimit = 0;
    public string timeoutStage = "lobby";

    public float minHeight = -35;

    public GameObject ballPrefab;
    private GameObject ball;

    private GameObject mainCamera;

    public Canvas timeCanvasPrefab;
    private Canvas timeCanvas;

    public Canvas resultCanvasPrefab;
    private Canvas resultCanvas;

    private TextMeshProUGUI timeTxt;

    private StagePortal clearPortal;

    public void Awake()
    {
        timer = GetComponent<Timer>();
        timer.OnTimerEnd.AddListener(TimerEnd);
        ball = Instantiate(ballPrefab);
        ball.GetComponent<Ball>().minHeight = minHeight;
        mainCamera = GameObject.Find("Main Camera");
        resultCanvas = Instantiate(resultCanvasPrefab);
        timeCanvas = Instantiate(timeCanvasPrefab);
        timeTxt = timeCanvas.GetComponentInChildren<TextMeshProUGUI>();
        clearPortal = GameObject.Find("ClearPortal")?.GetComponent<StagePortal>();
        clearPortal?.OnStageClear.AddListener(StageClear);
    }

    public void Start()
    {
        timer.ResetTimer(timeLimit);
        if (timeLimit > 0) {
            timer.StartTimer();
        }
    }

    public void Update()
    {
        ShowTime();
    }

    public void FixedUpdate() {
        MoveCamera();
    }

    public void ShowTime()
    {
        timeTxt.text = string.Format("{0:N1}", timer.time / 1000) + 's';
    }

    public void ShowResult()
    {
        resultCanvas.enabled = true;
    }

    private void TimerEnd()
    {
        if (timeoutStage == "main")
        {
            SceneManager.LoadScene("Main");
        }
        else if (timeoutStage == "lobby")
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    private void StageClear()
    {
        timer.StopTimer();
        ShowResult();
        ball.GetComponent<Ball>().Restart();
    }

    public float cameraSpeed = 0.1f;
    private void MoveCamera() {
        Vector2 dir = ball.transform.position - mainCamera.transform.position;
        Vector2 moveVector = new(dir.x * cameraSpeed, dir.y * cameraSpeed);
        mainCamera.transform.Translate(moveVector);
    }
}
