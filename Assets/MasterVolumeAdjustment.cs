using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeAdjustment : MonoBehaviour {

	float volumeLevel;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("master_volume")) {
			volumeLevel = PlayerPrefs.GetFloat ("master_volume");
		}
		else
		{
			PlayerPrefs.SetFloat ("master_volume", 1f);
			PlayerPrefs.Save ();
			volumeLevel = 1f;
		}
		AudioListener.volume = volumeLevel;
	}
}
