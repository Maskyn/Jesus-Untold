using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogoSetup : MonoBehaviour
{
	public Image FadePanel;
	
		// Use this for initialization
		public void Start ()
		{
		Invoke("LoadPlayScene", 3f);
		}

		public void LoadPlayScene() {
		Application.LoadLevel (1);
	}

	void Update()
	{
		Color c = FadePanel.color;
		c.a = Mathf.Lerp(FadePanel.color.a,0.5f,Time.deltaTime);
		FadePanel.color = c;

	}
}
