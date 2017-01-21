using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour {

	public void LoadByIndex(int index)
    {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
