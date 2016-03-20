using UnityEngine;
using System.Collections;

public class fireworksScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Keep the fireworks facing camera to prevent black fire bug. 
		transform.LookAt (Camera.main.transform.position);
	}
}
