using UnityEngine;
using System.Collections;

namespace Parallax
{
    public class PlayerController : MonoBehaviour
    {
        public float maxSpeed = 5f;
        public int jumpVelocity = 5;
        public int maxFrameHoldingJump = 20;

        private Rigidbody2D rb2d;
        private int frameHoldingJump = 0;

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if((frameHoldingJump >= 0 && !Input.GetKey(KeyCode.Space)) || frameHoldingJump >= maxFrameHoldingJump)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(frameHoldingJump * Vector2.up * jumpVelocity / maxFrameHoldingJump, ForceMode2D.Impulse);
                frameHoldingJump = 0;
                Debug.Log("JUMP !");
            }

            if (Input.GetKey(KeyCode.Space) && !(Mathf.Abs(rb2d.velocity.y) > 10f))
            {
                frameHoldingJump++;
                Debug.Log("Holding");
            }

            Debug.Log(rb2d.velocity.y);
        }

        void FixedUpdate() {
            float h = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(h *maxSpeed,rb2d.velocity.y);
        }
    }
}


