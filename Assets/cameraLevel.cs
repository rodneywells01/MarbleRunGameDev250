using UnityEngine;
using System.Collections;

public class cameraLevel : MonoBehaviour {
	/*
		This script is for keeping a cube in the same direction and horizontal rotation as the camera. 
		
	 */
	// Use this for initialization
	Transform cam; 
	Quaternion newRotation;
	void Start () {

		cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		setPosition ();
	}

	void setPosition() {
		// Set Position.
		transform.position = cam.position;

		// Calculate rotation. 
		newRotation = cam.rotation;
		newRotation.z = 0f; 

		// Set new rotation. 
		transform.rotation = newRotation;
	}
}
