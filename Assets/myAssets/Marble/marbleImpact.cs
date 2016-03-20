using UnityEngine;
using System.Collections;

public class marbleImpact : MonoBehaviour {

	public AudioSource thunkHard;
	public AudioSource thunkSoft;
	
	void Start () {
		// Update Audio Variables. 
		AudioSource[] tempSounds = GetComponents<AudioSource> (); 
		thunkHard = tempSounds [1]; 
		thunkSoft = tempSounds [0];
	}

	void OnCollisionEnter() {
		// Determine the speed of the object and play an appropriate sound. 
		if (Mathf.Abs(rigidbody.velocity.y) > 8) {
			thunkHard.Play(); // Play a hard hit. 
		} else if (Mathf.Abs(rigidbody.velocity.y) > 0) {
			thunkSoft.Play (); // Play a soft hit. 
		}
	}
}
