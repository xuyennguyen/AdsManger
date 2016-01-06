#if (!UNITY_IPHONE && !UNITY_IOS && !UNITY_ANDROID) || (UNITY_EDITOR)

using UnityEngine;
using System.Collections;

public class UnsupportedPlatformAgent : SupersonicIAgent {
	

	public UnsupportedPlatformAgent(){
		Debug.Log ("Unsupported Platform");
	}
	
	#region SupersonicAgent implementation

	public void start(){
		Debug.Log ("Unsupported Platform");
	}

	public void reportAppStarted()
	{
		Debug.Log ("Unsupported Platform");
	}

	public void onResume ()
	{

	}
	
	public void onPause ()
	{
	}
	
	public void setAge (int age)
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void setGender (string gender)
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void initRewardedVideo (string appKey,string userId)
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void showRewardedVideo ()
	{
		Debug.Log ("Unsupported Platform");
	}

	public void showRewardedVideo (string placementName)
	{
		Debug.Log ("Unsupported Platform");
	}

	
	public bool isRewardedVideoAvailable ()
	{
		Debug.Log ("Unsupported Platform");
		return false;
	}

	public SupersonicPlacement getPlacementInfo (string placementName)
	{
		Debug.Log ("Unsupported Platform");
		return null;
	}

	public void initInterstitial (string appKey,string userId)
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void showInterstitial ()
	{
	}
	
	public bool isInterstitialAdAvailalbe ()
	{
		Debug.Log ("Unsupported Platform");
		return false;
	}
	
	public void initOfferwall (string appKey,string userId)
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void showOfferwall ()
	{
		Debug.Log ("Unsupported Platform");
	}
	
	public void getOfferwallCredits ()
	{
		Debug.Log ("Unsupported Platform");
	}

	public bool isOfferwallAvailable()
	{
		Debug.Log ("Unsupported Platform");
		return false;
	}
	
	#endregion
	

}

#endif
