using UnityEngine;
using System.Collections;

public class moveMarble : MonoBehaviour {
	GameObject camera;
	Transform cameraDirection;
	Transform upwardDirection;
	float force = 8f;
	Vector3 startingLocation;
	public bool canJump = false;
	bool canControl = true;

	// Use this for initialization
	void Start () {
		cameraDirection = GameObject.Find("cameraLevel").transform;
		canJump = false;
		canControl = true;
		startingLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (canControl) {
			if (Input.GetKey (KeyCode.W)) {
				rigidbody.AddForce (cameraDirection.forward * force);
				checkApplyTorque(KeyCode.W);

			}

			if (Input.GetKey (KeyCode.A)) {
				rigidbody.AddForce (cameraDirection.right * -1 * force);
				checkApplyTorque(KeyCode.A);
			}

			if (Input.GetKey (KeyCode.S)) {
				rigidbody.AddForce (cameraDirection.forward * -1 * force);
				checkApplyTorque(KeyCode.S);
			}

			if (Input.GetKey (KeyCode.D)) {
				rigidbody.AddForce (cameraDirection.right * force);
				checkApplyTorque(KeyCode.D);

			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				if (canJump) {
					rigidbody.AddForce (Vector3.up * force * 40);
				} 
			}

		}
	}

	void OnCollisionStay(Collision myCollision) {
		if (myCollision.gameObject.tag == "floor") {
			canJump = true;
		}


		
	} 
	
	void OnCollisionExit(Collision myCollision) {
		canJump = false;

	}


	public void stopMovement() {
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		canControl = false;

		transform.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}

	public void startMovement() {
		canControl = true;
		transform.rigidbody.constraints = RigidbodyConstraints.None;
	}

	public void resetBall() {
		GameObject.Find ("Marble").transform.position = startingLocation;

		transform.rigidbody.angularVelocity = Vector3.zero;
		startMovement ();

	}

	void checkApplyTorque(KeyCode value) {
		float forceMultiplier = 50;
		if (!canJump) {
			// This means that the object is in the air. I want to apply torque. 
			// TODO: If really bored, implement realistic rotation?
			Vector3 torqueToApply; 
			if (value == KeyCode.W) {
				torqueToApply = cameraDirection.right * forceMultiplier;
			} else if (value == KeyCode.A) {
				torqueToApply = cameraDirection.forward * forceMultiplier; 
			} else if (value == KeyCode.S) {
				torqueToApply = cameraDirection.right * -1  * forceMultiplier;
			} else {
				torqueToApply = cameraDirection.forward * -1 * forceMultiplier;
			}

			transform.rigidbody.AddTorque(torqueToApply);
		} 
	}

	public bool getJumpStatus() {
		return canJump;
	}


}
