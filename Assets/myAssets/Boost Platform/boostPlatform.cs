using UnityEngine;
using System.Collections;

public class boostPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		// Give it a boost! 
		col.transform.rigidbody.AddForce (col.contacts [0].normal * -1 * 800f);
		Vector3 test = col.contacts [0].normal * -1 * 800f;

		// Give it a booing! 
		audio.Play ();


	}
}
