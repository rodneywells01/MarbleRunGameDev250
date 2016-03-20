using UnityEngine;
using System.Collections;

public class launchRocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			transform.rigidbody.AddForce(Vector3.up * 10000f);
		}
	
	}
}
