using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Parallax
{
    public class PlayerController : MonoBehaviour {
        public float maxSpeed = 5f;
        public int jumpVelocity = 5;
        public int maxFrameHoldingJump = 20;

        public bool grounded = true;
        public bool wallSliding = false;

        private Rigidbody2D rb2d;
        private int frameHoldingJump = 0;

        public BoxCollider2D leftCollider;
        public BoxCollider2D rightCollider;
        public BoxCollider2D bottomCollider;
        public BoxCollider2D topCollider;

        public Vector2 wallJumpClimb;
        public Vector2 wallJumpOff;
        public Vector2 wallLeap;

        public int slidingDirection;

        bool isWallClimbing = false;

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
        }

        void FixedUpdate()
        {
            float h = Input.GetAxisRaw("Horizontal");

            if(!isWallClimbing) {
                rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);
            }

            /*
            if (((frameHoldingJump > 0 && !Input.GetKey(KeyCode.Space)) || frameHoldingJump >= maxFrameHoldingJump) && (grounded || wallSliding)) {
                gameObject.GetComponent<Rigidbody2D>().AddForce(frameHoldingJump * Vector2.up * jumpVelocity / maxFrameHoldingJump, ForceMode2D.Impulse);
                frameHoldingJump = 0;
            }

            // if (Input.GetKey(KeyCode.Space) && !(Mathf.Abs(rb2d.velocity.y) > 10f))
            if (Input.GetKey(KeyCode.Space) && (grounded || wallSliding)) {
                frameHoldingJump++;

                if (frameHoldingJump > maxFrameHoldingJump) {
                    frameHoldingJump = maxFrameHoldingJump;
                }
            }
            */

            if (Input.GetKey(KeyCode.Space) && (grounded || wallSliding)) {
                if (wallSliding) {
                    Debug.Log("Wall slide jump");
                    Debug.Log(h);
                    Debug.Log(slidingDirection);
                    if (h == slidingDirection && !grounded) {
                        // rb2d.velocity.Set(rb2d.velocity.x, -50);

                        rb2d.velocity = new Vector2(-slidingDirection * wallJumpClimb.x, wallJumpClimb.y);
                        isWallClimbing = true;
                    } else {
                        isWallClimbing = false;
                    }
                }
                else {
                    rb2d.AddForce(maxFrameHoldingJump * Vector2.up * jumpVelocity / maxFrameHoldingJump, ForceMode2D.Impulse);
                }
            }
            else {
                if (wallSliding) {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, -100);
                }
            }

            isWallClimbing = false;
        }

        void OnCollisionExit2D(Collision2D collider)
        {
            grounded = false;
            wallSliding = false;
        }

        void OnCollisionStay2D(Collision2D collision) {
            foreach (ContactPoint2D cp in collision.contacts) {

                if (cp.otherCollider == leftCollider || cp.otherCollider == rightCollider) {
                    wallSliding = true;

                    if (cp.otherCollider == leftCollider) {
                        slidingDirection = -1;
                    } else {
                        slidingDirection = 1;
                    }
                    
                } else {
                    wallSliding = false;
                }

                if (cp.otherCollider == bottomCollider) {
                    grounded = true;
                }
            }
        }
        
        public void OnCollisionEnter2D(Collision2D collision) {
        }
    }
}


