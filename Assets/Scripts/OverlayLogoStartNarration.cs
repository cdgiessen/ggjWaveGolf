using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayLogoStartNarration : MonoBehaviour {

	public float splashDelay = 3f;
	public GameObject logoDisplay;
	public GameObject introCube;
	public GameObject audioSource;
	bool narrationStarted = false;

	// Update is called once per frame
	void Update () {
		splashDelay -= Time.deltaTime;
		if (splashDelay < 0)
		{
			logoDisplay.SetActive (false);
			introCube.SetActive (true);
			narrationStarted = true;
		}
		if (!audioSource.GetComponent<AudioSource> ().isPlaying && narrationStarted)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		}
		if (PlayerPrefs.HasKey ("HIT"))
		{
			audioSource.GetComponent<AudioSource> ().Stop ();
		}
		else
		{
			if (Input.GetKey ((KeyCode)Enum.Parse(typeof (KeyCode), PlayerPrefs.GetString ("HIT"))))
			{
				audioSource.GetComponent<AudioSource> ().Stop ();
			}
		}
	}
}
