using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {
	public Font customFont = new Font();
	float buttonWidth;
	GUIStyle mainTitle; 
	GUIContent[] guiLevels;
	public Texture[] levelPictures;
	bool primaryMainMenu;
	int numberOfLevels;
	void Start () {
		// customFont is set in Editor;
		levelPictures = new Texture[5];
		mainTitle = new GUIStyle ();
		mainTitle.font = customFont;
		mainTitle.fontSize = 50;
		buttonWidth = 100;
		primaryMainMenu = true;
		numberOfLevels = Application.levelCount - 1;
		// Load in Level Pictures
		//levelPictures
 
		guiLevels = new GUIContent[numberOfLevels + 1];
		for (int i = 0; i < guiLevels.Length; i++) {
			guiLevels[i] = new GUIContent("Level " + i.ToString());
			Debug.Log("Making: " + i.ToString());
		}

		//guiLevels[0].image = 


		// Instantiate all levels. 
	}
	
	// Update is called once per frame
	void Update () {

		//

	}

	void OnGUI() {
		if (primaryMainMenu) {
			//GUI.Label (new Rect (Screen.width / 2 - 500, Screen.height / 3, 0, 400), "Super Marble Runner Professional Remix 16: Limited Edition", mainTitle);
			if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth /2, Screen.height / 3 * 2, buttonWidth, 50), "BEGIN")) {
				// Activate level selection.
				primaryMainMenu = false;
				audio.Play(); // Play Audio 

				// Hide title. 
				GameObject title = GameObject.Find("Title"); 
				title.SetActive(false);
			}

		} else { 

			GUI.Label(new Rect(Screen.width /2 - 100, 30, 200, 100), "WASD to move, Arrow Keys to Rotate Camera, Space to Jump, ESC to Pause");
			GUI.Box( new Rect(50, 150, Screen.width - 100, Screen.height - 300), "Choose Your Level");

			int i = 0;
			int j = 0;
			int k = 1;
			int[] inc = {i, j, k};
			debugPrintArray(inc);

			for (int a = 0; a < numberOfLevels; a++) 
			{
				if (GUI.Button(new Rect(70 + inc[0], 200 + inc[1], 100, 100), guiLevels[inc[2]])) {
					Application.LoadLevel("level" + inc[2].ToString());
				} 
				inc = updateButtonIncrementation(inc);
			}

		}
	}

	void loadLevel(string level) {
		Application.LoadLevel (level);
	}

	int[] updateButtonIncrementation(int[] vals) {
		int iinc = 150;
		int jinc = 150; 
		int kinc = 1; 

		int i = vals [0]; 
		int j = vals [1];
		int k = vals [2];

		if (i + iinc > Screen.width - iinc * 1.5) {
			// Set I to zero and start a new row. 
			i = 0; 
			j = jinc + j;
		} else {
			// Keep adding more modules to the current row. 
			i = i + iinc; 
		}

		// No matter the case, K needs to be incremented. 
		k = k + kinc;

		int[] valsincremented = {i, j, k}; 
		return valsincremented;
	}

	void debugPrintArray(int[] vals) {
		string message = ""; 

		for (int i = 0; i < vals.Length; i++) {
			message = message + " " + vals[i].ToString(); 
		}

		Debug.Log (message);
	}
}
