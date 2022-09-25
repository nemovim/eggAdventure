using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBlock : MonoBehaviour
{
    public bool isSelf = false;
    public float deltaX = 0;
    public float deltaY = 0;
    private bool isTeleported = false;

    void OnCollisionEnter2D(Collision2D collision) {
        if (!isSelf) {
            Teleport(collision.gameObject, deltaX, deltaY);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (isSelf && isTeleported) {
            Teleport(gameObject, -deltaX, -deltaY);
            isTeleported = false;
        } else if (isSelf && !isTeleported) {
            Teleport(gameObject, deltaX, deltaY);
            isTeleported = true;
        }
    }

    void Teleport(GameObject obj, float dx, float dy) {
        obj.transform.position = new Vector2(obj.transform.position.x + dx, obj.transform.position.y + dy);
    }
}
