using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour {

	public void LoadByIndex(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
