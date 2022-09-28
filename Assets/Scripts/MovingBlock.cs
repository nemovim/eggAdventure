using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private Vector2 initialPos;
    void Awake()
    {
        initialPos = transform.position;
    }

    public float verticalSpeed = 0;
    public int maxVerticalLength = 0;
    public float horizontalSpeed = 0;
    public int maxHorizontalLength = 0;

    void FixedUpdate()
    {
        transform.Translate(new Vector2(horizontalSpeed*0.01f, verticalSpeed*0.01f));

        if (verticalSpeed != 0 && Mathf.Round(Mathf.Abs(initialPos.y - transform.position.y)*100) >= maxVerticalLength*100) {
            if (verticalSpeed > 0) {
                initialPos = new Vector2(initialPos.x, initialPos.y + maxVerticalLength);
            } else {
                initialPos = new Vector2(initialPos.x, initialPos.y - maxVerticalLength);
            }
            verticalSpeed *= -1;
        }
        
        if (horizontalSpeed != 0 && Mathf.Round(Mathf.Abs(initialPos.x - transform.position.x)*100) >= maxHorizontalLength*100) {
            if (horizontalSpeed > 0) {
                initialPos = new Vector2(initialPos.x + maxHorizontalLength, initialPos.y);
            } else {
                initialPos = new Vector2(initialPos.x - maxHorizontalLength, initialPos.y);
            }
            horizontalSpeed *= -1;
        }
    }
}
