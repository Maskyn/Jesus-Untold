using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 0f);
		Invoke("Remove", 7);
	}
	
	void Remove() {
		Destroy(gameObject);
	}
}
