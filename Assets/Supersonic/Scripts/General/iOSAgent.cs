#if UNITY_IPHONE || UNITY_IOS
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System;

public class iOSAgent : SupersonicIAgent {

	[DllImport("__Internal")]
	private static extern void CFStart();

	[DllImport("__Internal")]
	private static extern void CFReportAppStarted();

	[DllImport("__Internal")]
	private static extern void CFSetPluginData(string pluginType, string pluginVersion);

	[DllImport("__Internal")]
	private static extern void CFSetAge(int age);
	[DllImport("__Internal")]
	private static extern void CFSetGender(string gender);
	[DllImport("__Internal")]
	private static extern void CFInitRewardedVideo(string appKey,string userId);
	[DllImport("__Internal")]
	private static extern void CFShowRewardedVideo();
	[DllImport("__Internal")]
	private static extern void CFShowRewardedVideoWithPlacementName(string placementName);
	[DllImport("__Internal")]
	private static extern bool CFIsRewardedVideoAvailable();
	[DllImport("__Internal")]
	private static extern string CFGetPlacementInfo(string placementName);
	[DllImport("__Internal")]
	private static extern void CFInitInterstitial(string appKey,string userId);
	[DllImport("__Internal")]
	private static extern void CFShowInterstitial();
	[DllImport("__Internal")]
	private static extern bool CFIsInterstitialAdAvailable();
	[DllImport("__Internal")]
	private static extern void CFInitOfferwall(string appKey,string userId);
	[DllImport("__Internal")]
	private static extern void CFShowOfferwall();
	[DllImport("__Internal")]
	private static extern void CFGetOfferwallCredits();
	[DllImport("__Internal")]
	private static extern bool CFIsOfferwallAvailable();

	
	public iOSAgent(){
	
	}

	#region SupersonicAgent implementation


	public void start(){
		CFStart ();
		CFSetPluginData( "Unity", Supersonic.UNITY_PLUGIN_VERSION);
	}

	public void reportAppStarted(){
		CFReportAppStarted ();
	}

	public void onResume (){

	}

	public void onPause (){

	}

	public void setAge (int age){
		CFSetAge(age);
	}


	public void setGender (string gender){
		CFSetGender(gender);
	}


	public void initRewardedVideo (string appKey,string userId){
		CFInitRewardedVideo(appKey,userId);
	}


	public void showRewardedVideo (){
		CFShowRewardedVideo ();
	}

	public void showRewardedVideo (string placementName){
		CFShowRewardedVideoWithPlacementName (placementName);
	}

	public bool isRewardedVideoAvailable (){
		return CFIsRewardedVideoAvailable ();
	}

	public SupersonicPlacement getPlacementInfo (string placementName){

		SupersonicPlacement sp =  null;

		string spString = CFGetPlacementInfo (placementName);
		if (spString != null ){
			Dictionary<string,object> spDic = SupersonicJSON.Json.Deserialize( spString ) as Dictionary<string,object>;
			string pName = spDic ["placement_name"].ToString ();
			string rewardName = spDic ["reward_name"].ToString ();
			int rewardAmount = Convert.ToInt32 (spDic ["reward_amount"].ToString ());
			sp = new SupersonicPlacement(pName, rewardName, rewardAmount);
		}

		return sp;
	}


	public void initInterstitial (string appKey,string userId){
		CFInitInterstitial (appKey,userId);
	}


	public void showInterstitial (){
		CFShowInterstitial ();
	}


	public bool isInterstitialAdAvailalbe (){
		return CFIsInterstitialAdAvailable ();
	}


	public void initOfferwall (string appKey,string userId){
		CFInitOfferwall(appKey,userId);
	}


	public void showOfferwall (){
		CFShowOfferwall ();
	}


	public void getOfferwallCredits (){
		CFGetOfferwallCredits ();		
	}

	public bool isOfferwallAvailable (){
		return CFIsOfferwallAvailable ();
	}

	#endregion


}
#endif
