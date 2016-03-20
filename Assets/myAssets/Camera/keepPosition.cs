using UnityEngine;
using System.Collections;

public class keepPosition : MonoBehaviour {

	GameObject marble;
	Vector3 marbleposition;
	GameObject marbleCenter;
	// Use this for initialization
	void Start () {
		marble = GameObject.Find ("Marble");
		marbleCenter = GameObject.Find ("MarbleCenter");
		marbleposition = marble.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		marbleCenter.transform.position = marble.transform.position;

	}

}
