using UnityEngine;
using System.Collections;

public class AudioScript:MonoBehaviour{
	static AudioScript instance;
	void Start(){
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			GetComponent<AudioSource>().Play();
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}
}