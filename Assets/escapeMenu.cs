using UnityEngine;
using System.Collections;

public class escapeMenu : MonoBehaviour {

	public GameObject pauseMenu;
	bool pausedstate = false;
	GameObject marble;
	Vector3 velocity; 
	Vector3 angularVelocity;

	// Use this for initialization
	void Start () {
		marble = GameObject.Find ("Marble");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pausedstate = !pausedstate;
			pauseMenu.SetActive(pausedstate);

			if (pausedstate) {
				// Disable Marble 
				velocity = marble.transform.rigidbody.velocity; 
				angularVelocity = marble.transform.rigidbody.angularVelocity; 

				marble.GetComponent<moveMarble>().stopMovement(); 


			} else {
				// Enable Marble 
				marble.GetComponent<moveMarble>().startMovement(); 
				marble.transform.rigidbody.velocity = velocity;
				marble.transform.rigidbody.angularVelocity = angularVelocity;
			}
		}

	}

	public bool getPausedState() {
		return pausedstate;
	}



	public void skipLevel() {
		Debug.Log ("Pussy!");
		if (Application.loadedLevel != Application.levelCount) {
			Application.LoadLevel ("level" + (Application.loadedLevel + 1).ToString ());
		}

	}

	public void levelSelect() {
		Application.LoadLevel("mainMenu");
	}

	public void quit() {
		// DON'T LEAVE ME
		Application.Quit ();
	}
}
