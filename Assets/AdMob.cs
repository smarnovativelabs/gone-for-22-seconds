using System;
using UnityEngine;
using System.Collections;
using admob;

public class AdMob : MonoBehaviour {

	[SerializeField] Ad Ios;
	[SerializeField] Ad Android;
	[SerializeField] bool testingMode;

	public static bool IsRemoveAdPurchased;
	public static AdMob o;

	void Start () {
		o = this;
		Admob.Instance ().setTesting (testingMode);
	#if UNITY_IOS
		Admob.Instance ().initAdmob (Ios.bannerID, Ios.interstitialID);
	#endif
	#if UNITY_ANDROID
		Admob.Instance ().initAdmob (Android.bannerID, Android.interstitialID);
	#endif
		Admob.Instance ().loadInterstitial ();
	}

	public void ShowBanner (bool status) {
		if (!IsRemoveAdPurchased) {
			if (status) {
				Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_CENTER, 5);
				print ("BannerAd Displaying");
			} else {
				Admob.Instance ().removeBanner ();
				print ("BannerAd Destroyed");
			}
		}
	}

	public void ShowVideo () {
		if (!IsRemoveAdPurchased) {
			if (Admob.Instance ().isInterstitialReady ()) {
				Admob.Instance ().showInterstitial ();
				print ("InterstitialAd Displaying");
			} else
				print ("InterstitialAd Loading");
			StartCoroutine (LoadVideo ());
		}
	}

	IEnumerator LoadVideo () {
		yield return new WaitForSeconds (1);
		Admob.Instance ().loadInterstitial ();
	}
}

[Serializable]
public class Ad {
	public string bannerID;
	public string interstitialID;
}
