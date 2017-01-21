using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 1f;
	public float rotationSpeed = 1f;
	public Canvas pauseMenu;
	KeyCode forward;
	KeyCode backward;
	KeyCode left;
	KeyCode right;
	KeyCode hit;
	KeyCode pause;
	bool isPaused = false;

	// Use this for initialization
	void Awake () {
		gameObject.tag = "Player";
		forward = PlayerPrefsManager.GetKeyBinding ("forward");
		backward = PlayerPrefsManager.GetKeyBinding ("backward");
		left = PlayerPrefsManager.GetKeyBinding ("rotateLeft");
		right = PlayerPrefsManager.GetKeyBinding ("rotateRight");
		hit = PlayerPrefsManager.GetKeyBinding ("hit");
		pause = PlayerPrefsManager.GetKeyBinding ("pause");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(pause)) {
			Time.timeScale = 0;
			pauseMenu.gameObject.SetActive (true);
			isPaused = true;
		}

		float zinput = 0;
		float rotateInput = 0;

		if (Input.GetKey (forward))
		{
			zinput = 1;
		}
		else if (Input.GetKey (backward))
		{
			zinput = -1;
		}
		if (Input.GetKey (left))
		{
			rotateInput = -1;
		}
		else if (Input.GetKey (right))
		{
			rotateInput = 1;
		}
		float zAxis = zinput * moveSpeed * Time.deltaTime;
		float rotation = rotateInput * rotationSpeed * Time.deltaTime;
		transform.Translate (0, 0, zAxis);
		transform.Rotate (0, rotation, 0);
    }

	public void UnPauseGame()
	{
		Debug.Log ("Unpaused Game");
		Time.timeScale = 1;
	}
}
