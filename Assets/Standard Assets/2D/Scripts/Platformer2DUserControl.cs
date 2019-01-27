using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Jump;
        public KeyCode Crouch;

        public float moveSpeed = 10.0f;
        public float jumpForce = 5.0f;

        private bool isGrounded = true;
        private Rigidbody2D rigidbody;
        
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(Left))
            {
                rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
            }
            else if (Input.GetKey(Right))
            {
                rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }

            if (Input.GetKeyDown(Jump) && isGrounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
        }


    }
}
