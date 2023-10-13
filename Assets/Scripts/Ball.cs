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

    void Update() {
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerMove();
        CheckHeight();

        if (Input.GetKey(KeyCode.UpArrow)) {
            Die();
        }
    }

    public float minHeight = -100;
    void CheckHeight() {
        if (transform.position.y < minHeight) {
            Die();
        }
    }
    public int moveSpeed = 7;
    public int jumpSpeed = 15;
    public int minSpeed = -15;

    void PlayerMove() {

        float inputX = Input.GetAxis("Horizontal");

        Vector2 v = new Vector2(inputX * moveSpeed, rigid.velocity.y);


        // if (isGround) {
        //     v.y = jumpSpeed;
        //     isGround = false;
        // }


        rigid.velocity = v;
    }

    void PlayerJump() {
        Vector2 v = rigid.velocity;

        if (((isGround && !isGlue) || isWater) && Input.GetKey(KeyCode.Space)) {
            isGround = false;
            isGlue = false;
            v.y = jumpSpeed;
        }

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
    private bool isGlue = false; 
    private bool isWater = false; 

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.layer== 7) {
            // layer number 7 is spike.
            Restart();
        }

        if (collision.gameObject.layer == 6) {
            // layer number 6 is ground.
            isGround = true;
            isGlue = false;
        }

        if (collision.gameObject.layer == 8) {
            // layer number 8 is glue.
            isGlue = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 7) {
            Restart();
        } else if (collider.gameObject.layer == 9) {
            // layer number 9 is water.
            isWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.layer == 9) {
            // layer number 9 is water.
            isWater = false;
        }
    }

    void Die() {
        Restart();
    }

    public void Restart() {
        rigid.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(0, 0);
        isGround = false;
        isGlue = false;
        isWater = false;
    }

}
