using UnityEngine;
using System.Collections;

public class ObjectsGenerator : MonoBehaviour {

	public GameObject[] objects;

	public float minTime = 3f;
	public float maxTime = 3f;

	public float initialPause = 1f;

	public float randomPositionY = 0f;
	public float randomPositionX = 0f;

	// Use this for initialization
	void Start () {
		Invoke("Generate", initialPause);
	}
	
	void Generate() {
		int randomId = Random.Range(0, objects.Length);

		// difference of position
		float diffY = Random.Range(-randomPositionY, +randomPositionY);
		float diffX = Random.Range(-randomPositionX, +randomPositionX);

		Vector3 child = new Vector3(transform.position.x + diffX, transform.position.y + diffY, transform.position.z);

		Instantiate(objects[randomId], child, Quaternion.identity);

		Invoke("Generate", Random.Range(minTime, maxTime));
	}
}
