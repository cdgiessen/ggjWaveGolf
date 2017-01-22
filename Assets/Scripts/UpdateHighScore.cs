using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHighScore : MonoBehaviour {

	public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("High Score")) {
			scoreText.text = PlayerPrefs.GetInt ("High Score").ToString();
		}
		else
		{
			PlayerPrefs.SetInt ("High Score", 0);
			scoreText.text = "0";
		}
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = PlayerPrefs.GetInt ("High Score").ToString();
	}
}
