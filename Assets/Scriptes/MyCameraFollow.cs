using UnityEngine;
using System.Collections;

public class MyCameraFollow : MonoBehaviour
{
	
	private Vector3 pos;
	public float distanceFromPlayer;
	
	private Transform player;		// Reference to the player's transform.
	
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
	{
		pos = transform.position;
		pos.x = player.position.x + distanceFromPlayer;
		//pos.y = target.position.y + distanceFromCar;
		transform.position = pos;
	}
}
