using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {

    public Camera cam;

	void Start ()
    {
        cam = Camera.main;
        cam.orthographicSize = Screen.height / 2;
    }

}
