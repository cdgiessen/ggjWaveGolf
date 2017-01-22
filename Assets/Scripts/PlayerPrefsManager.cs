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
		PlayerPrefs.Save ();
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void SetHighScore (int score) {
		PlayerPrefs.SetInt (HIGH_SCORE, score);
		PlayerPrefs.Save ();
	}

	public static int GetHighScore () {
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public static void SetKeybindings(string forward, string backward, string left, string right, string hit, string pause)
	{
		PlayerPrefs.SetString(FORWARD, forward);
		PlayerPrefs.SetString(BACKWARD, backward);
		PlayerPrefs.SetString(LEFT, left);
		PlayerPrefs.SetString(RIGHT, right);
		PlayerPrefs.SetString(HIT, hit);
		PlayerPrefs.SetString(PAUSE, pause);
		PlayerPrefs.Save ();
	}

	public static KeyCode GetKeybinding(string keybinding)
	{
		switch (keybinding)
		{
		case "forward":
			if (PlayerPrefs.HasKey (FORWARD))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(FORWARD));
			}
			else
			{
				PlayerPrefs.SetString(FORWARD, KeyCode.W.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(FORWARD));
			}
		case "backward":
			if (PlayerPrefs.HasKey (BACKWARD))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(BACKWARD));
			}
			else
			{
				PlayerPrefs.SetString(BACKWARD, KeyCode.S.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(BACKWARD));
			}
		case "rotateLeft":
			if (PlayerPrefs.HasKey (LEFT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(LEFT));
			}
			else
			{
				PlayerPrefs.SetString(LEFT, KeyCode.A.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(LEFT));
			}
		case "rotateRight":
			if (PlayerPrefs.HasKey (RIGHT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(RIGHT));
			}
			else
			{
				PlayerPrefs.SetString(RIGHT, KeyCode.D.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(RIGHT));
			}
		case "hit":
			if (PlayerPrefs.HasKey (HIT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(HIT));
			}
			else
			{
				PlayerPrefs.SetString(HIT, KeyCode.Space.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(HIT));
			}
		case "pause":
			if (PlayerPrefs.HasKey (PAUSE))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(PAUSE));
			}
			else
			{
				PlayerPrefs.SetString(PAUSE, KeyCode.Escape.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(PAUSE));
			}
		default:
			return KeyCode.None;
		}
	}
}
