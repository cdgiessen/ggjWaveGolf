using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string HIGH_SCORE = "High Score";
	const string FORWARD = "FORWARD";
	const string BACKWARD = "BACKWARD";
	const string LEFT = "LEFT";
	const string RIGHT = "RIGHT";
	const string HIT = "HIT";
	const string PAUSE = "PAUSE";

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat ("master_volume", volume);
		} else {
			Debug.LogError ("Master Volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void SetHighScore (int score) {
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public static int GetHighScore () {
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public void SetKeybindings(string forward, string backward, string left, string right, string hit, string pause)
	{
		PlayerPrefs.SetString(FORWARD, forward);
		PlayerPrefs.SetString(BACKWARD, backward);
		PlayerPrefs.SetString(LEFT, left);
		PlayerPrefs.SetString(RIGHT, right);
		PlayerPrefs.SetString(HIT, hit);
		PlayerPrefs.SetString(PAUSE, pause);
	}

	public KeyCode GetKeybinding(string keybinding)
	{
		switch (keybinding)
		{
		case "forward":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		case "backward":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		case "rotateLeft":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		case "rotateRight":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		case "hit":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		case "pause":
			return (KeyCode)Enum.Parse (typeof(KeyCode), keybinding);
		default:
			return KeyCode.None;
		}
	}
}
