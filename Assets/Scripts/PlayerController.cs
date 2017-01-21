using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 1f;
	public float rotationSpeed = 1f;
	public float strafeSpeed = 1f;

	// Use this for initialization
	void Awake () {
        gameObject.tag = "Player";
	}

	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
		float zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		float rotation = Input.GetAxis("Rotation") * rotationSpeed * Time.deltaTime;
		transform.Translate (xAxis, 0, zAxis);
		transform.Rotate (0, rotation, 0);

    }
}
