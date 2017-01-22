using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioSource firstClip;
	public AudioSource secondClip;
	public AudioSource finalClip;
	bool firstClipDone = false;
	bool secondClipDone = false;
	bool secondClipLoopDone = false;
	bool finalClipDone = false;

	// Use this for initialization
	void Start () {
		/*
		 * volume adjustment will go here
		 */
	}
	
	// Update is called once per frame
	void Update () {
		if (!firstClip.isPlaying && !firstClipDone)
		{
			firstClipDone = true;
			firstClip.gameObject.SetActive (false);
			secondClip.Play ();
		}
		else if (!secondClip.isPlaying && !secondClipDone && firstClipDone)
		{
			secondClipDone = true;
			secondClip.Play();
		}
		else if (!secondClip.isPlaying && !secondClipLoopDone && secondClipDone)
		{
			secondClipLoopDone = true;
			secondClip.gameObject.SetActive(false);
			finalClip.Play();
		}
		else if (!finalClip.isPlaying && !finalClipDone && secondClipLoopDone)
		{
			finalClipDone = true;
			finalClip.gameObject.SetActive(false);
		}
	}
}
