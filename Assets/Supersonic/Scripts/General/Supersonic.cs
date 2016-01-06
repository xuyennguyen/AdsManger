using UnityEngine;
using System.Collections;

public class Supersonic : SupersonicIAgent {

	private SupersonicIAgent _platformAgent ;

	private static Supersonic mInstance;

	public const string UNITY_PLUGIN_VERSION = "6.3.3";
	public const string GENDER_MALE = "male";
	public const string GENDER_FEMALE = "female";
	public const string GENDER_UNKNOWN = "unknown";



	private Supersonic(){
		#if UNITY_EDITOR 
		_platformAgent = new UnsupportedPlatformAgent();	
		#elif (UNITY_IPHONE || UNITY_IOS) 
		_platformAgent = new iOSAgent();		
		#elif UNITY_ANDROID
		_platformAgent = new AndroidAgent ();

		#endif
	}


	#region SupersonicIAgent implementation


	public static Supersonic Agent
	{
		get
		{
			if (mInstance == null){
				mInstance = new Supersonic();
			}
			return mInstance;
		}
	}

	public string pluginVersion(){
		return UNITY_PLUGIN_VERSION;
	}



	public void start(){
		_platformAgent.start();
	}


	public void onResume (){
		_platformAgent.onResume ();
	}


	public void onPause (){
		_platformAgent.onPause ();
	}


	public void setAge (int age){
		_platformAgent.setAge (age);
	}


	public void setGender (string gender){
		if (gender.Equals(GENDER_MALE))
			_platformAgent.setGender (GENDER_MALE);
		else if (gender.Equals(GENDER_FEMALE))
			_platformAgent.setGender (GENDER_FEMALE);
		else if (gender.Equals(GENDER_UNKNOWN))
			_platformAgent.setGender (GENDER_UNKNOWN);
	}

	public void reportAppStarted(){
		_platformAgent.reportAppStarted ();	
	}


	public void initRewardedVideo (string appKey,string userId){
		_platformAgent.initRewardedVideo (appKey,userId);
	}


	public void showRewardedVideo (){
		_platformAgent.showRewardedVideo ();
	}

	public void showRewardedVideo(string placementName){
		_platformAgent.showRewardedVideo (placementName);
	}

	public SupersonicPlacement getPlacementInfo(string placementName){
		return _platformAgent.getPlacementInfo (placementName);
	}

	public bool isRewardedVideoAvailable (){
		return _platformAgent.isRewardedVideoAvailable ();
	}


	public void initInterstitial (string appKey,string userId){
		_platformAgent.initInterstitial (appKey,userId);
	}


	public void showInterstitial (){
		_platformAgent.showInterstitial ();
	}


	public bool isInterstitialAdAvailalbe (){
		return _platformAgent.isInterstitialAdAvailalbe ();
	}


	public void initOfferwall (string appKey,string userId){
		_platformAgent.initOfferwall (appKey,userId);
	}


	public void showOfferwall (){
		_platformAgent.showOfferwall ();
	}


	public void getOfferwallCredits (){
		_platformAgent.getOfferwallCredits ();
	}


	public bool isOfferwallAvailable(){
		return _platformAgent.isOfferwallAvailable ();
	}


	#endregion


}
