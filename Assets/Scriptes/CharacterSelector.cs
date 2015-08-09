using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CharacterSelector : MonoBehaviour {

	public int[] puntiNecessari;
	public GameObject[] checkmarsk;
	public GameObject[] characters;
	public RectTransform scroller;

	private float jesusX;
	private float distanceCharacters;

	void Start() {

		distanceCharacters = characters [1].transform.position.x - characters [0].transform.position.x;
		jesusX = scroller.transform.position.x;

		float differenceX = PlayerPrefs.GetInt("Character") * -distanceCharacters;
		scroller.transform.position = new Vector3(scroller.transform.position.x + differenceX, scroller.transform.position.y, scroller.transform.position.z);

		Check();

	}

	public void Select(int id) {

		float x = jesusX - id * distanceCharacters;
		scroller.transform.position = new Vector3(x, scroller.transform.position.y, scroller.transform.position.z);

		print(x);

		PlayerPrefs.SetInt("Character", id);
		Check ();
	}

	void Check() {
		for (int i = 0; i < 4; i++) {
			checkmarsk[i].SetActive(PlayerPrefs.GetInt("Character") == i);
			
			if (PlayerPrefs.GetInt("High Score") < puntiNecessari[i]) {
				characters[i].GetComponent<Image>().color = Color.gray;
				characters[i].GetComponent<Button>().interactable = false;
			}
		}
	}


}
