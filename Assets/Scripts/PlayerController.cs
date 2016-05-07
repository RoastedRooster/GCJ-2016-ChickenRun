using UnityEngine;
using System.Collections;

namespace Parallax
{
    public class PlayerController : MonoBehaviour
    {
        public float maxSpeed = 5f;
        public int jumpVelocity = 5;
        public int maxFrameHoldingJump = 20;

        bool grounded = true;
        bool wallSliding = false;

        private Rigidbody2D rb2d;
        private int frameHoldingJump = 0;

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if(((frameHoldingJump >= 0 && !Input.GetKey(KeyCode.Space)) || frameHoldingJump >= maxFrameHoldingJump) && grounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(frameHoldingJump * Vector2.up * jumpVelocity / maxFrameHoldingJump, ForceMode2D.Impulse);
                frameHoldingJump = 0;
            }

            if (Input.GetKey(KeyCode.Space) && !(Mathf.Abs(rb2d.velocity.y) > 10f))
            {
                frameHoldingJump++;
            }

            // Debug.Log(rb2d.velocity.y);

            Debug.DrawLine(transform.position, new Vector2(0, -1), Color.red);
        }

        void FixedUpdate() {
            float h = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(h *maxSpeed,rb2d.velocity.y);
        }

        void OnCollisionStay2D(Collision2D collider) {
            checkIfGrounded();
            checkIfSliding();
        }

        void OnCollisionExit2D(Collision2D collider) {
            grounded = false;
            wallSliding = false;
        }

        private void checkIfSliding() {
            /*
            RaycastHit2D[] hits;

            Vector2 positionToCheck = transform.position;

            // Check on left
            hits = Physics2D.RaycastAll(positionToCheck, new Vector2(1, 0), 0.01f);
            // if a collider was hit, we are grounded
            if (hits.Length > 0) {
                Debug.Log("Against wall");
            }

            // Check on right
            hits = Physics2D.RaycastAll(positionToCheck, new Vector2(-1, 0), 0.01f);
            // if a collider was hit, we are grounded
            if (hits.Length > 0) {
                Debug.Log("Against wall");
            }
            */
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector2.right, out hit)) {
                float distanceToRightWall = hit.distance;
                if (distanceToRightWall <= 32 + 0.01f) {
                    Debug.Log("i'm hitting the right hand wall!");
                    // Place logic for hitting right wall here
                }
            }
        }

        private void checkIfGrounded() {
            RaycastHit2D[] hits;

            // We raycast down 1 pixel from this position to check for a collider
            Vector2 positionToCheck = transform.position;
            hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

            // if a collider was hit, we are grounded
            if (hits.Length > 0) {
                grounded = true;
            }
        }
    }
}


