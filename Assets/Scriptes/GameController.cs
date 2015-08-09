using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Button restartButton;
	public Button quitButton;

	void Start() {
		//PlayerPrefs.SetInt("High Score", 1037);
		Time.timeScale = 1.0f;
		restartButton.interactable = false;
		restartButton.gameObject.SetActive(false);
		quitButton.interactable = false;
		quitButton.gameObject.SetActive(false);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Quit();
	}

	public void Quit() {
		Application.LoadLevel(1); 
	}

	public void RestartGame() {
		Time.timeScale = 1.0f;
		Application.LoadLevel(Application.loadedLevel);
		restartButton.interactable = false;
		restartButton.gameObject.SetActive(false);
		quitButton.interactable = false;
		quitButton.gameObject.SetActive(false);

		UpdateHighScore((int) GameObject.FindGameObjectWithTag("Player").transform.position.x);
	}

	public void EndGame() {
		Time.timeScale = 0.0f;
		restartButton.interactable = true;
		restartButton.gameObject.SetActive(true);

		#if UNITY_IPHONE 
		quitButton.interactable = true;
		quitButton.gameObject.SetActive(true);
		#endif

		UpdateHighScore((int) GameObject.FindGameObjectWithTag("Player").transform.position.x);

	}

	void UpdateHighScore(int score) {
		if (score > PlayerPrefs.GetInt("High Score")) {
			PlayerPrefs.SetInt("High Score", score);
		}
	}
}
