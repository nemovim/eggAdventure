using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public float speed = 10;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = player.transform.position - this.transform.position;
        Vector2 moveVector = new Vector2(dir.x * speed, dir.y * speed);
        this.transform.Translate(moveVector);
    }
}
