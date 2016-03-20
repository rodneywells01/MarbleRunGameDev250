using UnityEngine;
using System.Collections;

public class cameraPosition : MonoBehaviour {
	GameObject camera;
	GameObject marble;
	Vector3 marbleposition;
	Vector3 cameraposition;
	Quaternion cameraRotation;

	public bool finished;
	bool playFinishAnimation;

	float xval;
	float yval;
	float zval;
	float radius = 5;
	float angle;
	float mins; 
	float secs;
	float miliseconds;

	int cameraRotationFactor; 

	// Use this for initialization
	void Start () {
		marble = GameObject.Find ("Marble");
		marbleposition = marble.transform.position;
		camera = GameObject.Find ("Main Camera Custom");

		finished = false;
		playFinishAnimation = false;

		xval = -5;
		yval = 2;
		zval = 0;
		radius = 5; 
		angle = Mathf.PI; 
		cameraRotationFactor = 200; // The higher, the slower. 
	}
	
	// Update is called once per frame
	void Update () {
		marbleposition = marble.transform.position;

		cameraposition.x = marbleposition.x + xval;
		cameraposition.z = marbleposition.z + zval; 
		cameraposition.y = marbleposition.y + yval;
		camera.transform.position = cameraposition;

		//var myCameraPosition: Vector3 = (cameraposition.x, ,


		camera.transform.LookAt (marbleposition);

		// Check to see if the marble has won. 
		if (playFinishAnimation) {
			
		}

		// Handle camera rotation
		handleLeftRight ();
		//handleUpDown ();


	}

	void OnGUI() {
		GUI.contentColor = Color.black;
		if (!finished && !GetComponent<escapeMenu>().getPausedState()) {

			GUI.Label (new Rect (Screen.width / 2 - 30, 80, 300, 50), "Level " + Application.loadedLevel);
			GUI.Label (new Rect (Screen.width / 2 - 130, 100, 300, 50), "GET TO THE PURPLE END ZONE!");


			// Configure time. 
			secs = Time.timeSinceLevelLoad %60f; 
			mins = Time.timeSinceLevelLoad / 60f;
			miliseconds = ((Time.timeSinceLevelLoad * 1000f) % 1000) / 10; 

			GUI.Label (new Rect (Screen.width / 2 - 30, 120, 300, 50), ((int)mins).ToString()+":"+((int)secs).ToString()+":"+((int)miliseconds).ToString());
		} else if (!GetComponent<escapeMenu>().getPausedState()){
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 3, 200, 100), "LEVEL COMPLETE!");
			GUI.Label (new Rect (Screen.width / 2 - 30, 120, 300, 50), ((int)mins).ToString()+":"+((int)secs).ToString()+":"+((int)miliseconds).ToString());
			if (Application.loadedLevel == Application.levelCount - 1) {
				GUI.Label (new Rect (Screen.width / 2 - 50, 100, 100, 50), "YOU WIN!");


			} else {
				if (GUI.Button(new Rect(Screen.width /2 -50, Screen.height / 3 * 2, 100, 50), "Next Level")) {
					// Load another level. 
					Application.LoadLevel("level" + (Application.loadedLevel + 1).ToString());

				}	

			}
			if (GUI.Button(new Rect(Screen.width /2 -50, Screen.height / 3 * 2 + 60, 100, 50), "Replay Level")) {
				// Replay the current level. 
				Application.LoadLevel("level" + (Application.loadedLevel).ToString());
				
			}

			if (GUI.Button(new Rect(Screen.width /2 -50, Screen.height / 3 * 2 + 120, 100, 50), "Choose Level")) {
				// Replay the current level. 
				Application.LoadLevel("mainMenu");
				
			}
		}


	}

	void handleLeftRight() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			// User want to rotate the camera left.
			solveForNewXYAngle (true);
			
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			solveForNewXYAngle(false);
		}
	}

	void handleUpDown() {
		if (Input.GetKey (KeyCode.UpArrow)) {
			// User wants to move camera up. 
			solveForNewZAngle(true);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			// User wants to move camera down. 
			solveForNewZAngle(false);
		}
	}

	public void finishAnimation() {
		marble.GetComponent<moveMarble> ().stopMovement ();

	}

	void solveForNewXYAngle (bool left) {
		int multiplier = 1;

		// Determine direction of rotation. 
		if (!left) {
			multiplier = -1; 
		}

		// Holy shit I'm actually using Calculus III. I never thought the day would come. 
		// x=rcos(theta) 
		// y=rsin(theta) 
		angle = angle + Mathf.PI / 30 * multiplier; // Update Angle. 

		xval = radius * Mathf.Cos (angle); 
		zval = radius * Mathf.Sin (angle); 



	}

	void solveForNewZAngle(bool up) {
		int multiplier = 1;
		
		// Determine direction of rotation. 
		if (!up) {
			multiplier = -1; 
		}
		
		// Holy shit I'm actually using Calculus III. I never thought the day would come. 
		// x=rcos(theta) 
		// y=rsin(theta) 
		angle = angle + Mathf.PI / 30 * multiplier; // Update Angle. 
		
		yval = radius * Mathf.Cos (angle); 
	}




} 
