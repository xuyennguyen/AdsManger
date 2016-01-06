using UnityEngine;
using System.Collections;

public class TestAds : MonoBehaviour {

	AdsManager adsManager;

	// Use this for initialization
	void Start () {

		adsManager = new AdsManager ();
	
	}
	
	public void AdmobShowBanner(){

		adsManager.ShowBanner ();
	}

	public void AdmobHideBanner(){

		adsManager.HideBanner ();
	}

	public void AdmobShowInterstital(){

		adsManager.ShowInterstitial ();
	
	}

	public void SupersonicShowVideo(){

		adsManager.PlayAVideo (AdsConfig.AdsSupersonicAdPlacement);
	}

	public void ShowAdColonyVideo(){

		adsManager.PlayAVideo (AdsConfig.AdsColonyAdPlacement);
	}

	public void ShowUnityAdsVideo(){

		adsManager.PlayAVideo (AdsConfig.AdsUnityAdsPlacement);
	}
}
