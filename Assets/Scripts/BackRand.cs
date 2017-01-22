using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRand : MonoBehaviour {

    public Camera camera;
    public float changeDelay;
    float countdown;

	// Use this for initialization
	void Start () {
        countdown = changeDelay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            camera.backgroundColor = RandomColor();
            countdown = changeDelay;
        }
	}

    Color RandomColor()
    {
        return new Color(Random.Range(0.5f,1), Random.Range(0.5f, 1), Random.Range(0.5f, 1));
    }
}
