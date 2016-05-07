using UnityEngine;
using System.Collections;

public class PickTrapBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        coll.transform.position = GameObject.FindGameObjectWithTag("start").transform.position;
    }
}
