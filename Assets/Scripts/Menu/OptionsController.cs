using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

	public Slider volumeSlider;

	// Use this for initialization
	void Start ()
	{
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
	
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void SaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
	}
}
