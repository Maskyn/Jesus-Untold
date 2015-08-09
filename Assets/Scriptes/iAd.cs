using UnityEngine;
using System.Collections;
#if UNITY_IPHONE
using ADBannerView = UnityEngine.iOS.ADBannerView;
#endif

public class iAd : MonoBehaviour {

	#if UNITY_IPHONE
	private ADBannerView banner = null;
	void Start()
	{
		banner = new ADBannerView(ADBannerView.Type.Banner, ADBannerView.Layout.Top);
		ADBannerView.onBannerWasClicked += OnBannerClicked;
		ADBannerView.onBannerWasLoaded  += OnBannerLoaded;
	}
	void OnBannerClicked()
	{
		Debug.Log("Clicked!\n");
	}
	void OnBannerLoaded()
	{
		Debug.Log("Loaded!\n");
		banner.visible = true;
	}
	#endif
}
