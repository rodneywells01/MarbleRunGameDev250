using UnityEngine;
using System.Collections;

public class throwSparks : MonoBehaviour {

	/*
	 * Check to see if the marble is:
	 *  1: Touching a surface 
	 *  2: Moving quickly enough 
	 * If it is, turn on spark device
	 * Else, shut off spark device
	 */
	// Use this for initialization

	bool touchingSurface; 
	bool movingQuickly; 
	GameObject marble;
	moveMarble marblescript;
	public ParticleSystem sparks;
	GameObject camera; 

	void Start () {
		marble = GameObject.Find ("Marble"); 
		marblescript = marble.GetComponent<moveMarble> ();
		camera = GameObject.Find ("Main Camera Custom");
	}
	
	// Update is called once per frame
	void Update () {
		updateVariables ();
		setPosition ();
		// Check to see if the marble should display sparks 
		if (movingQuickly && touchingSurface) {
			// Turn spark machine on if not on
			this.particleSystem.enableEmission = true;
		} else {
			// Turn spark particles off 
			this.particleSystem.enableEmission = false;
		}
	}

	void updateVariables() {
		// Is the marble touching a surface?
		touchingSurface = marblescript.getJumpStatus ();


		// Is the marble moving quicly enough?
		if (marble.transform.rigidbody.velocity.magnitude > 30f) {
			movingQuickly = true;
		} else {
			movingQuickly = false;
		}
	}

	void setPosition() {
		// Update position of sparks (Right under ball) and rotation. 
		transform.position = marble.transform.localPosition - new Vector3(0,marble.transform.localScale.y / 2, 0);

		// Update rotation 

		if (marble.transform.rigidbody.velocity != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (marble.transform.rigidbody.velocity * -1);
		}
	}
}
