﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimeManager : MonoBehaviour {

	public Text scoreText;
	public Text countdownText;
	public float startTime = 60f;
	float timeLeft;
	int score = 0;

	// Use this for initialization
	void Start () {
		timeLeft = startTime;
		scoreText.text = score.ToString ();
		countdownText.text = timeLeft.ToString ("F");
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		scoreText.text = score.ToString ();
		countdownText.text = timeLeft.ToString ("F");
	}
}
