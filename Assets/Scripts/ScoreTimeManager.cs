using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimeManager : MonoBehaviour {

	public Text scoreText;
	public Text countdownText;
	public float startTime = 60f;
	float timeLeft;
	public int score = 0;

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
		if (timeLeft <= 0.3)
		{
			if (PlayerPrefs.GetFloat ("High Score") < score)
			{
				PlayerPrefs.SetFloat ("High Score", score);
			}
			PlayerPrefs.Save ();
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
	}
}
