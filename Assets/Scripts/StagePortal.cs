using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePortal : MonoBehaviour
{
    public Controller controller;

    public int stageNum = -4;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            if (stageNum == -1) {
                SceneManager.LoadScene("Lobby");
            } else if (stageNum == -2) {
                SceneManager.LoadScene("Main");
            } else if (stageNum == -3) {
                controller.timer.StopTimer();
                controller.showResult();
            } else if (stageNum == 0) {
                SceneManager.LoadScene("Stages");
            } else if (stageNum > 0) {
                SceneManager.LoadScene($"Stage {stageNum}");
            }
        }
    }
}
