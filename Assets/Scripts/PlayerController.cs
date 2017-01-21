using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed = 1;

	// Use this for initialization
	void Awake () {
        gameObject.tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        Vector3 newPos = new Vector3(xAxis, 0, zAxis)*Time.deltaTime*MoveSpeed + transform.position;
        transform.position = newPos;

    }
}
