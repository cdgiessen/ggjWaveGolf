﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsController : MonoBehaviour
{

	public Slider volumeSlider;
	public Text forwardField;
	public Text backwardField;
	public Text leftField;
	public Text rightField;
	public Text strafeLeftField;
	public Text strafeRightField;
	public Text hitField;
	public Text pauseField;
	bool waitingForKey = false;
	string keyBinding = "";
	Text bindingField = null;

	// Use this for initialization
	void Start ()
	{
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		forwardField.text = PlayerPrefsManager.GetKeybinding ("forward").ToString();
		backwardField.text = PlayerPrefsManager.GetKeybinding ("backward").ToString();
		leftField.text = PlayerPrefsManager.GetKeybinding ("rotateLeft").ToString();
		rightField.text = PlayerPrefsManager.GetKeybinding ("rotateRight").ToString();
		strafeLeftField.text = PlayerPrefsManager.GetKeybinding ("strafeLeft").ToString();
		strafeRightField.text = PlayerPrefsManager.GetKeybinding ("strafeRight").ToString();
		hitField.text = PlayerPrefsManager.GetKeybinding ("hit").ToString();
		pauseField.text = PlayerPrefsManager.GetKeybinding ("pause").ToString();
	}

	// Update is called once per frame
	void Update ()
	{
		if (waitingForKey)
		{
			if (Input.anyKey) {
				foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
					if (Input.GetKey (key)) {
						keyBinding = key.ToString ();
					}

				}
				bindingField.text = keyBinding;
				waitingForKey = false;
			}
		}
	}

	public void SaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetKeybindings (forwardField.text, backwardField.text, leftField.text, rightField.text, strafeLeftField.text, strafeRightField.text, hitField.text, pauseField.text);
		PlayerPrefs.Save ();
	}

	public void KeybindingSetting (Text sendingField)
	{
		waitingForKey = true;
		bindingField = sendingField;
	}
}
