using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBlock : MonoBehaviour
{
    private SpriteRenderer render;
    public float reTime = 0;
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Show();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Show();
    }

    void OnTriggerExit2D(Collider2D collider) {
        nowTime = reTime;
    }

    void OnCollisionExit2D(Collision2D collision) {
        nowTime = reTime;
    }

    private float nowTime = 0;
    // -1 => don't show
    void Show() {
        if (nowTime != -1) {
            render.enabled = true;
        }
    }

    void Hide() {
        nowTime -= 0.02f;
        if (nowTime <= 0) {
            nowTime = 0;
            render.enabled = false;
        }
    }

    void FixedUpdate() {
        if (nowTime != 0) {
            Hide();
        }
    }
}
