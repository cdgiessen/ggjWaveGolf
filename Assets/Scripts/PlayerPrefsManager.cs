using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	static int HIGH_SCORE = 0;
	const string FORWARD = "FORWARD";
	const string BACKWARD = "BACKWARD";
	const string LEFT = "LEFT";
	const string RIGHT = "RIGHT";
	const string STRAFE_LEFT = "STRAFE_LEFT";
	const string STRAFE_RIGHT = "STRAFE_RIGHT";
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
		HIGH_SCORE = score;
	}

	public static int GetHighScore () {
		return HIGH_SCORE;
	}

	public static void SetKeybindings(string forward, string backward, string left, string right, string strafe_left, string strafe_right, string hit, string pause)
	{
		PlayerPrefs.SetString(FORWARD, forward);
		PlayerPrefs.SetString(BACKWARD, backward);
		PlayerPrefs.SetString(LEFT, left);
		PlayerPrefs.SetString(RIGHT, right);
		PlayerPrefs.SetString(STRAFE_LEFT, strafe_left);
		PlayerPrefs.SetString(STRAFE_RIGHT, strafe_right);
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
				PlayerPrefs.SetString(LEFT, KeyCode.Q.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(LEFT));
			}
		case "rotateRight":
			if (PlayerPrefs.HasKey (RIGHT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(RIGHT));
			}
			else
			{
				PlayerPrefs.SetString(RIGHT, KeyCode.E.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(RIGHT));
			}
		case "strafeLeft":
			if (PlayerPrefs.HasKey (STRAFE_LEFT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(STRAFE_LEFT));
			}
			else
			{
				PlayerPrefs.SetString(STRAFE_LEFT, KeyCode.A.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(STRAFE_LEFT));
			}
		case "strafeRight":
			if (PlayerPrefs.HasKey (STRAFE_RIGHT))
			{
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(STRAFE_RIGHT));
			}
			else
			{
				PlayerPrefs.SetString(STRAFE_RIGHT, KeyCode.D.ToString());
				return (KeyCode)Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString(STRAFE_RIGHT));
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
