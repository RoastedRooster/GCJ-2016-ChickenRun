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
        bool wallSliding = false;

        private Rigidbody2D rb2d;
        private int frameHoldingJump = 0;

        public BoxCollider2D leftCollider;
        public BoxCollider2D rightCollider;
        public BoxCollider2D bottomCollider;
        public BoxCollider2D topCollider;
        
        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (((frameHoldingJump > 0 && !Input.GetKey(KeyCode.Space)) || frameHoldingJump >= maxFrameHoldingJump) && grounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(frameHoldingJump * Vector2.up * jumpVelocity / maxFrameHoldingJump, ForceMode2D.Impulse);
                frameHoldingJump = 0;
            }

            if (Input.GetKey(KeyCode.Space) && !(Mathf.Abs(rb2d.velocity.y) > 10f))
            {
                frameHoldingJump++;
            }
        }

        void FixedUpdate() {
            float h = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(h *maxSpeed,rb2d.velocity.y);
        }
        
        void OnCollisionExit2D(Collision2D collider) {
            grounded = false;
            // wallSliding = false;
        }

        void OnCollisionStay2D(Collision2D collision) {
            foreach (ContactPoint2D cp in collision.contacts) {

                if (cp.otherCollider == leftCollider) {
                    Debug.Log("Collider touch on left");
                    checkIfSliding();
                }

                if (cp.otherCollider == rightCollider) {
                    Debug.Log("Collider touch on right");
                    checkIfSliding();
                }

                if (cp.otherCollider == bottomCollider) {
                    Debug.Log("the fuck");
                    grounded = true;
                }

                /*
                if (cp.collider == leftCollider) {
                    Debug.Log("Collider touch on left");
                } else if (cp.collider == rightCollider) {
                    Debug.Log("Collider touch on right");
                }
                */
                /*​
                if (cp.otherCollider == colliders[i]) {
                    Debug.Log("otherCollider touch: " + i);
                }
                */
            }
        }
        
        public void OnCollisionEnter2D(Collision2D collision) {
        
        }

        private void checkIfSliding() {
        }
    }
}


