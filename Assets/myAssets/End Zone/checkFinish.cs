using UnityEngine;
using System.Collections;

public class checkFinish : MonoBehaviour {
	public GameObject camera;
	public AudioClip audioFile;
	public AudioSource test;
	GameObject marble;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera Custom");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision ballCollision) {
		if (ballCollision.gameObject.name == "Marble") {
			// The marble has made it to the end zone. 

			// Grab camera and say level complete on the GUI. 
			camera.GetComponent<cameraPosition>().finished = true;
			camera.GetComponent<cameraPosition>().finishAnimation();

			// Play level complete audio. 
			audio.Play();

			// Play fireworks.
			GameObject[] objects = GameObject.FindGameObjectsWithTag("fireworks");
			ParticleSystem[] fireworks = new ParticleSystem[2];
			for (int i = 0; i < objects.Length; i++) {
				fireworks[i] = objects[i].GetComponent<ParticleSystem>();
			}

			for (int i = 0; i < fireworks.Length; i++) {
				if (!fireworks[i].IsAlive()) {
					fireworks[i].Play();
				}

			}

			// Freeze movement. 
			ballCollision.transform.rigidbody.isKinematic = true;

		}
	}
}
