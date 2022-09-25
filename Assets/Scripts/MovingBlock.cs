using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private Rigidbody2D rigid;
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    public float verticalSpeed = 0;
    private int verticalLength = 0;
    public int maxVerticalLength = 0;
    public float horizontalSpeed = 0;
    public int maxHorizontalLength = 0;
    private int horizontalLength = 0;

    void Start() {
        SetVelocity();
    }

    void FixedUpdate()
    {
        if (verticalSpeed != 0 && verticalLength < maxVerticalLength) {
            verticalLength += 1;
        } else if (verticalLength == maxVerticalLength) {
            verticalLength = 0;
            verticalSpeed *= -1;
            SetVelocity();
        }
        
        if (horizontalSpeed != 0 && horizontalLength < maxHorizontalLength) {
            horizontalLength += 1;
        } else if (horizontalLength == maxHorizontalLength) {
            horizontalLength = 0;
            horizontalSpeed *= -1;
            SetVelocity();
        }
    }

    void SetVelocity() {
        rigid.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}
