using UnityEngine;
using System.Collections;

public class CactusController : MonoBehaviour {

	void Start () {
		Invoke("Remove", 7);
	}
	
	void Remove() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<DinoController>().Hit();
		}
	}
}
