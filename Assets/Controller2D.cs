using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {

    BoxCollider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
	}

    struct RaycastOrigins {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
