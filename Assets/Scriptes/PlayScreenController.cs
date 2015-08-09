using UnityEngine;
using System.Collections;

public class PlayScreenController : MonoBehaviour {

	void Start() {
		//PlayerPrefs.SetInt("High Score", 1037);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();
	}
}
