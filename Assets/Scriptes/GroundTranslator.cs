using UnityEngine;
using System.Collections;

public class GroundTranslator : MonoBehaviour {

	public GameObject otherGround;
	public float objWidth;
	
	void OnTriggerEnter2D (Collider2D  other)
	{
		if (other.tag == "Player") {
			Vector3 pos = transform.position;
			pos.x += objWidth;
			otherGround.transform.position = pos;
		}
	}
}
