using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using roastedrooster.chickenrun.laws;
using roastedrooster.chickenrun.player;
using roastedrooster.chickenrun.game;

namespace roastedrooster.chickenrun.player
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

        public float slidingDirection;

        bool isInAir = false;
        public float wallClimbTime = .25f;
        public float wallOffTime = .1f;
        public float timeUntilAirControl = 0;

        Player playerScript;

        bool gameStarted = false;

        public void setGameStarted (bool value) {
            gameStarted = value;
        }

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
            playerScript = GetComponent<Player>();
        }

        void Update()
        {
        }

        void FixedUpdate()
        {
            if(gameStarted) {
                float h = Input.GetAxisRaw("Horizontal_" + playerScript.ControllerIndex);

                if (grounded) {
                    rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);
                }
                else {
                    if (timeUntilAirControl == 0) {
                        rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);
                    }
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

                if (wallSliding) {
                    // Slow player during wallSliding
                    rb2d.velocity = new Vector2(rb2d.velocity.x, -100);
                }



                if (Input.GetButton("Jump_" + playerScript.ControllerIndex) && (grounded || wallSliding)) {

                    LawManager.Instance.PlayerEvent(TriggeringEventID.PlayerJump, gameObject.GetComponent<Player>());

                    if (wallSliding) {
                        // Wall hopping
                        if (Mathf.Abs(h) >= (0.5 * Mathf.Abs(slidingDirection)) && !grounded) {
                            // if (h == slidingDirection && !grounded) {
                            rb2d.velocity = new Vector2(-slidingDirection * wallJumpClimb.x, wallJumpClimb.y);
                            timeUntilAirControl = wallClimbTime;
                        }
                        else if (h == -slidingDirection && !grounded) {
                            // Leap jump
                        }
                        else if (!grounded) {
                            rb2d.velocity = new Vector2(-slidingDirection * wallJumpOff.x, wallJumpOff.y);
                            timeUntilAirControl = wallOffTime;
                        }

                        // Other wall jumps
                    }
                    // Classic jump
                    else {
                        rb2d.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                    }
                }

                if (timeUntilAirControl > 0) {
                    timeUntilAirControl -= Time.deltaTime;
                }
                else {
                    timeUntilAirControl = 0;
                }
            }
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
        
    }
}


