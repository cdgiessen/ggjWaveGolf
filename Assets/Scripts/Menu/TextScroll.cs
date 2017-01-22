using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroll : MonoBehaviour {

	public float textspeed = 0.1f;

//	private Rigidbody rb;
	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (transform.position.y >= 0.98) {
			return;
		}
		transform.position += Vector3.up * Time.deltaTime * textspeed;
	}
}
