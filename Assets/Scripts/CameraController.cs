﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float dampening = 1;
	Vector3 offset;

	void Start() {
		offset = target.transform.position - transform.position;
	}

	void LateUpdate() {
		//float currentAngle = transform.eulerAngles.y;
		//float desiredAngle = target.transform.eulerAngles.y;
		//float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * dampening);
		//Quaternion rotation = Quaternion.Euler(0, angle, 0);
		//transform.position = target.transform.position - (rotation * offset);
		//transform.LookAt (target.transform);
	}
}