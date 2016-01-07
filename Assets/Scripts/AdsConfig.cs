using UnityEngine;
using System.Collections;
using Prime31;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;

public  class AdsConfig  {

//#if  UNITY_ANDROID
//	#if PRODUCTION

	// App Id
	public const string AdsAdmobAppId = "";
	public const string AdsTapjoyAppId = "";
	public const string AdsAdColonyAppId = "appbf9953d59f484f48bf";
	public const string AdsSupersonicAppId = "43b469ad";
	public const string AdsUnityAdsAppId = "1027682";
	public const string AdsInmobAppId = "26c4d404ff674c62a374bdca788b04f2";

	// Adplacement
	public  string AdsSupersonicUniqueUser = "";
	public const string AdsSupersonicAdPlacement =	"DefaultRewardedVideo";
	public const string AdsColonyAdPlacement = "vzbd704b0a07de4b4b83";
	public const string AdsUnityAdsPlacement = "rewardedVideo";
	public const long 	AdsInmobiAdsFullscreenPlacement = 1449078706947;
	public const string AdsAdmobBannerPlacement = "ca-app-pub-5564691899175158/1216122226";
	public const string AdsAdmobIntertitialPlacement = "ca-app-pub-5564691899175158/2692855420";

	// adstype

	public const AdsType adsType = AdsType.BannerBottom;
	public  AdSize adSize = AdSize.Banner;


//
//	#else
//
//	#endif
//
//
//#else
//
//#endif


}
