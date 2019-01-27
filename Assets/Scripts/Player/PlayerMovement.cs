using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

  public KeyCode Left;
  public KeyCode Right;
  public KeyCode Jump;
  public KeyCode Crouch;

  private Animator anim;


  public float moveSpeed = 10.0f;
  public float jumpForce = 5.0f;

  public bool facingRight = false;
  private bool isJumping = false;
  private Rigidbody2D rigidbody;

  public void SetPlayer1Movement() {
    Left = KeyCode.A;
    Right = KeyCode.D;
    Jump = KeyCode.W;
    Crouch = KeyCode.S;
  }

  public void SetPlayer2Movement() {
    Left = KeyCode.J;
    Right = KeyCode.L;
    Jump = KeyCode.I;
    Crouch = KeyCode.K;
  }

  private void Awake() {
    rigidbody = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
  }

  private void Update() {
    if (Time.timeScale == 1) {
      if (Input.GetKey(Left)) {
        if (facingRight) {
          facingRight = !facingRight;

          // Multiply the player's x local scale by -1.
          Vector3 theScale = transform.localScale;
          theScale.x *= -1;
          transform.localScale = theScale;
        }
        rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
      } else if (Input.GetKey(Right)) {
        if (!facingRight) {
          facingRight = !facingRight;

          // Multiply the player's x local scale by -1.
          Vector3 theScale = transform.localScale;
          theScale.x *= -1;
          transform.localScale = theScale;
        }
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
      } else {
        rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
      }

      if (Input.GetKeyDown(Jump) && !isJumping) {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        anim.SetBool("Ground", false);
        isJumping = true;
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.tag == "Ground") {
      anim.SetBool("Ground", true);
      isJumping = false;
    }
  }


}
