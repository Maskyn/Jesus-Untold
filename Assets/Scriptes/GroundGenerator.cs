using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {

	public GameObject ground;
	private GameObject[] grounds;
	public float distance;

	void Start () {
		grounds = new GameObject[4];

		grounds[0] = Instantiate(ground, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		grounds[1]= Instantiate(ground, new Vector3(transform.position.x + distance, transform.position.y, transform.position.z), Quaternion.identity)  as GameObject;
		grounds[2] = Instantiate(ground, new Vector3(transform.position.x + (2 * distance), transform.position.y, transform.position.z), Quaternion.identity)  as GameObject;
		grounds[3] = Instantiate(ground, new Vector3(transform.position.x + (3 * distance), transform.position.y, transform.position.z), Quaternion.identity)  as GameObject;

		InvokeRepeating("CheckPlayerX", 0, 0.25f);

	}

	void CheckPlayerX() {
		int x = (int) GameObject.FindGameObjectWithTag("Player").transform.position.x;

		foreach (GameObject ground in grounds) {
			if (ground.transform.position.x < (x - distance)) {
				ground.transform.position = new Vector3(ground.transform.position.x + distance * 3, ground.transform.position.y, ground.transform.position.z);
			}
		}
	}
}
