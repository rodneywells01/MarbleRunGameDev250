using UnityEngine;
using System.Collections;

public class floaterScript : MonoBehaviour {

	float range = 12;
	float distanceFromMiddle = 0;
	bool startdirection;
	Vector3 positionVector;
	Vector3 updateVector;
	int multiplier= 1;
	float speed = .1f;
	// Use this for initialization
	void Start () {
		// Make the ramp float in the z and -z direction. 
		// Starting in middle. 

		float middle = this.transform.position.z;
		positionVector = this.transform.position;
		distanceFromMiddle = 0;
	

		int test = Random.Range (0, 2);

		if (test == 1) {
			startdirection = true;
		} else {
			startdirection = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateVector = this.transform.position;
		if (startdirection) {
			multiplier = 1;
		} else {
			multiplier = -1;
		}

		updateVector.z = updateVector.z + speed * multiplier; 
		distanceFromMiddle = distanceFromMiddle + speed * multiplier; 
		
		if (Mathf.Abs(distanceFromMiddle) >= range) {
			startdirection = !startdirection;
		}

		// Update position. 
		this.transform.position = updateVector;
	}
}
