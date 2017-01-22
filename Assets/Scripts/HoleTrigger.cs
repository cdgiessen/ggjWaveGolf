using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour {

	public GameObject player;
	public Transform ball;

	void OnTriggerStay(Collider other)
	{
		player.GetComponent<ScoreTimeManager>().score += 1;
		player.GetComponent<Transform>().position = Vector3.zero;
		ball.position = Vector3.up + Vector3.up;
	}
}
