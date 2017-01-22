using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class SpinOnGaze : MonoBehaviour
{
    private GazeAware _gazeAware;

    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
    }

    void Update()
    {

        if (_gazeAware.HasGazeFocus)
        {
            transform.Rotate(Vector3.forward);
            Debug.Log("Lost Focus");
        }
        GazePoint gazePoint = EyeTracking.GetGazePoint();
        if (gazePoint.IsValid)
        {
            print("Gaze point on Screen (X,Y): " + gazePoint.Screen.x + ", " + gazePoint.Screen.y);
        }
    }
}
