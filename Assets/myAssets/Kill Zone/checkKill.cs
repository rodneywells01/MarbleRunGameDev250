using UnityEngine;
using System.Collections;

public class checkKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision myCollision) {
		if (myCollision.transform.name == "Marble") {
			GameObject.Find("Marble").GetComponent<moveMarble>().stopMovement();
			audio.Play(); // FAILURE!! 
			GameObject.Find("Marble").GetComponent<moveMarble>().resetBall();
		}
	}
}
