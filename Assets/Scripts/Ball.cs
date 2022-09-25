using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    public int moveSpeed = 7;
    public int jumpSpeed = 15;
    public int minSpeed = -15;

    void PlayerMove() {

        float inputX = Input.GetAxis("Horizontal");

        Vector2 v = new Vector2(inputX * moveSpeed, rigid.velocity.y);

        if (isGround && Input.GetKey(KeyCode.Space)) {
            isGround = false;
            v.y = jumpSpeed;
        }

        // if (isGround) {
        //     v.y = jumpSpeed;
        //     isGround = false;
        // }

        if (v.y < minSpeed) {
            v.y = minSpeed;
        }

        rigid.velocity = v;
    }

    
    // bool IsGround() {
    //     RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Ground"));

    //     if (rayHit.collider != null && rayHit.distance < 0.6f) {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    private bool isGround = false; 
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer== 7) {
            // layer number 7 is obstacle.
            Restart();
        } else if (collision.gameObject.layer == 6) {
            isGround = true;
        } else if (collision.gameObject.layer == 8) {
            isGround = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {
            isGround = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.layer == 9) {
            isGround = true;
        }
    }

    void Restart() {
        rigid.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(0, 0);
        isGround = false;
    }

}
