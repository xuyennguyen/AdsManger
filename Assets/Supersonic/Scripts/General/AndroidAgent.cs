#if UNITY_ANDROID
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class AndroidAgent : SupersonicIAgent {


	private static AndroidJavaObject _androidBridge;
	private readonly static string AndroidBridge = "com.supersonic.unity.androidbridge.AndroidBridge";

	private const string REWARD_AMOUNT = "reward_amount";
	private const string REWARD_NAME = "reward_name";
	private const string PLACEMENT_NAME = "placement_name";

	public AndroidAgent(){
		Debug.Log ("AndroidAgent ctr");
	}




	#region SupersonicAgent implementation

	public void start()
	{
		Debug.Log ("Android started");
//		if( Application.platform != RuntimePlatform.Android )
//			return;
		
		using( var pluginClass = new AndroidJavaClass( AndroidBridge ) )
			_androidBridge = pluginClass.CallStatic<AndroidJavaObject>( "getInstance" );
		_androidBridge.Call("setPluginData","Unity",Supersonic.UNITY_PLUGIN_VERSION);
		Debug.Log ("Android started - ended");
		
	}

	public void reportAppStarted(){
		_androidBridge.Call ("reportAppStarted");
	}

	public void onResume ()
	{
		_androidBridge.Call ("onResume");
	}

	public void onPause ()
	{
		_androidBridge.Call ("onPause");
	}

	public void setAge (int age)
	{
		_androidBridge.Call ("setAge", age);
	}

	public void setGender (string gender)
	{
		_androidBridge.Call ("setGender", gender);
	}

	public void initRewardedVideo (string appKey,string userId)
	{
		_androidBridge.Call ("initRewardedVideo", appKey,userId);
	}

	public void showRewardedVideo ()
	{
		_androidBridge.Call ("showRewardedVideo");
	}

	public void showRewardedVideo (string placementName)
	{
		_androidBridge.Call ("showRewardedVideo",placementName);
	}

	public bool isRewardedVideoAvailable ()
	{
		bool available = _androidBridge.Call<bool>("isRewardedVideoAvailable");
		return available;
	}

	public SupersonicPlacement getPlacementInfo (string placementName)
	{
		string placementInfo = _androidBridge.Call<string>("getPlacementInfo", placementName);
		SupersonicPlacement pInfo = null;
		if (placementInfo != null){
			Dictionary<string,object> pInfoDic = SupersonicJSON.Json.Deserialize( placementInfo ) as Dictionary<string,object>;
			string pName = pInfoDic [PLACEMENT_NAME].ToString ();
			string rName = pInfoDic [REWARD_NAME].ToString ();
			int rAmount = Convert.ToInt32 (pInfoDic [REWARD_AMOUNT].ToString ());

			pInfo = new SupersonicPlacement (pName, rName, rAmount);		
		}
		return pInfo;
	}

	public void initInterstitial (string appKey,string userId)
	{
		_androidBridge.Call ("initInterstitial", appKey,userId);
	}

	public void showInterstitial ()
	{
		_androidBridge.Call ("showInterstitial");
	}

	public bool isInterstitialAdAvailalbe ()
	{
		bool available = _androidBridge.Call<bool>("isInterstitialAdAvailalbe");
		return available;
	}

	public void initOfferwall (string appKey,string userId)
	{
		_androidBridge.Call ("initOfferwall",appKey,userId);
	}

	public void showOfferwall ()
	{
		_androidBridge.Call ("showOfferwall");
	}

	public void getOfferwallCredits ()
	{
		_androidBridge.Call ("getOfferwallCredits");
	}

	public bool isOfferwallAvailable()
	{
		bool available = _androidBridge.Call<bool>("isOfferwallAvailable");
		return available;
	}

	#endregion


}

#endif

