using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class SupersonicEvents : MonoBehaviour {

	private const string ERROR_CODE = "error_code";
	private const string ERROR_DESCRIPTION = "error_description";

	void Awake(){
		gameObject.name = "SupersonicEvents";				//Change the GameObject name to SupersonicEvents.
		DontDestroyOnLoad( gameObject );					//Makes the object not be destroyed automatically when loading a new scene.
	}


	// ******************************* RewardedVideoEvents *******************************

	private static event Action _onRewardedVideoInitSuccessEvent;
	public static event Action onRewardedVideoInitSuccessEvent{
		add{
			if (_onRewardedVideoInitSuccessEvent == null || !_onRewardedVideoInitSuccessEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoInitSuccessEvent += value;
			}
		}

		remove{
			if(_onRewardedVideoInitSuccessEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoInitSuccessEvent -= value;
			}

		}
	}
	
	public void onRewardedVideoInitSuccess( string empty ){
		if (_onRewardedVideoInitSuccessEvent != null) {
			_onRewardedVideoInitSuccessEvent();
		}
	}




	private static event Action<SupersonicError> _onRewardedVideoInitFailEvent;
	public static event Action<SupersonicError> onRewardedVideoInitFailEvent{
		add{
			if (_onRewardedVideoInitFailEvent == null || !_onRewardedVideoInitFailEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoInitFailEvent += value;
			}
		}

		remove{
			if(_onRewardedVideoInitFailEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoInitFailEvent -= value;
			}
		}
	}

	public void onRewardedVideoInitFail( string description ){
		if( _onRewardedVideoInitFailEvent != null ){
			Debug.Log ("entered onRewardedVideoInitFail 1");
			SupersonicError sse = getErrorFromErrorString(description);
			_onRewardedVideoInitFailEvent( sse );
		}
			
	}





	private static event Action _onRewardedVideoAdOpenedEvent;
	public static event Action onRewardedVideoAdOpenedEvent{
		add{
			if (_onRewardedVideoAdOpenedEvent == null || !_onRewardedVideoAdOpenedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdOpenedEvent += value;
			}
		}
		
		remove{
			if(_onRewardedVideoAdOpenedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdOpenedEvent -= value;
			}
		}
	}
	
	public void onRewardedVideoAdOpened( string empty ){
		if (_onRewardedVideoAdOpenedEvent != null) {
			_onRewardedVideoAdOpenedEvent();
		}
	}





	private static event Action _onRewardedVideoAdClosedEvent;
	public static event Action onRewardedVideoAdClosedEvent{
		add{
			if (_onRewardedVideoAdClosedEvent == null || !_onRewardedVideoAdClosedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdClosedEvent += value;
			}
		}
		
		remove{
			if(_onRewardedVideoAdClosedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdClosedEvent -= value;
			}
		}
	}
	
	public void onRewardedVideoAdClosed( string empty ){
		if (_onRewardedVideoAdClosedEvent != null) {
			_onRewardedVideoAdClosedEvent();
		}
	}





	private static event Action _onVideoStartEvent;
	public static event Action onVideoStartEvent{
		add{
			if (_onVideoStartEvent == null || !_onVideoStartEvent.GetInvocationList().Contains(value)){
				_onVideoStartEvent += value;
			}
		}
		
		remove{
			if(_onVideoStartEvent.GetInvocationList().Contains(value)){
				_onVideoStartEvent -= value;
			}
		}
	}
	
	public void onVideoStart( string empty ){
		if (_onVideoStartEvent != null) {
			_onVideoStartEvent();
		}
	}




	private static event Action _onVideoEndEvent;
	public static event Action onVideoEndEvent{
		add{
			if (_onVideoEndEvent == null || !_onVideoEndEvent.GetInvocationList().Contains(value)){
				_onVideoEndEvent += value;
			}
		}
		
		remove{
			if(_onVideoEndEvent.GetInvocationList().Contains(value)){
				_onVideoEndEvent -= value;
			}
		}
	}
	
	public void onVideoEnd( string empty ){
		if (_onVideoEndEvent != null) {
			_onVideoEndEvent();
		}
	}





	private static event Action<SupersonicPlacement> _onRewardedVideoAdRewardedEvent;
	public static event Action<SupersonicPlacement> onRewardedVideoAdRewardedEvent{
		add{
			if (_onRewardedVideoAdRewardedEvent == null || !_onRewardedVideoAdRewardedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdRewardedEvent += value;
			}
		}
		
		remove{
			if(_onRewardedVideoAdRewardedEvent.GetInvocationList().Contains(value)){
				_onRewardedVideoAdRewardedEvent -= value;
			}
		}
	}
	
	public void onRewardedVideoAdRewarded( string description ){
		if (_onRewardedVideoAdRewardedEvent != null) {
			SupersonicPlacement ssp = getPlacementFromString(description);
			_onRewardedVideoAdRewardedEvent( ssp );
		}
		
	}

	

	
	private static event Action<bool> _onVideoAvailabilityChangedEvent;
	public static event Action<bool> onVideoAvailabilityChangedEvent{
		add{
			if (_onVideoAvailabilityChangedEvent == null || !_onVideoAvailabilityChangedEvent.GetInvocationList().Contains(value)){
				_onVideoAvailabilityChangedEvent += value;
			}
		}

		remove{
			if(_onVideoAvailabilityChangedEvent.GetInvocationList().Contains(value)){
				_onVideoAvailabilityChangedEvent -= value;
			}
		}
	}

	public void onVideoAvailabilityChanged( string stringAvailable ){
		bool isAvailable = (stringAvailable == "true") ? true : false;
		if( _onVideoAvailabilityChangedEvent != null )
			_onVideoAvailabilityChangedEvent( isAvailable );
	}




	// ******************************* InterstitialEvents *******************************


	private static event Action _onInterstitialInitSuccessEvent;
	public static event Action onInterstitialInitSuccessEvent{
		add{
			if (_onInterstitialInitSuccessEvent == null || !_onInterstitialInitSuccessEvent.GetInvocationList().Contains(value)){
				_onInterstitialInitSuccessEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialInitSuccessEvent.GetInvocationList().Contains(value)){
				_onInterstitialInitSuccessEvent -= value;
			}
			
		}
	}
	
	public void onInterstitialInitSuccess( string empty ){
		if (_onInterstitialInitSuccessEvent != null) {
			_onInterstitialInitSuccessEvent();
		}
	}




	private static event Action<SupersonicError> _onInterstitialInitFailEvent;
	public static event Action<SupersonicError> onInterstitialInitFailEvent{
		add{
			if (_onInterstitialInitFailEvent == null || !_onInterstitialInitFailEvent.GetInvocationList().Contains(value)){
				_onInterstitialInitFailEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialInitFailEvent.GetInvocationList().Contains(value)){
				_onInterstitialInitFailEvent -= value;
			}
		}
	}
	
	public void onInterstitialInitFail( string description ){
		if (_onInterstitialInitFailEvent != null) {
			SupersonicError sse = getErrorFromErrorString(description);
			_onInterstitialInitFailEvent( sse );
		}
			
	}





	private static event Action<bool> _onInterstitialAvailabilityEvent;
	public static event Action<bool> onInterstitialAvailabilityEvent{
		add{
			if (_onInterstitialAvailabilityEvent == null || !_onInterstitialAvailabilityEvent.GetInvocationList().Contains(value)){
				_onInterstitialAvailabilityEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialAvailabilityEvent.GetInvocationList().Contains(value)){
				_onInterstitialAvailabilityEvent -= value;
			}
		}
	}
	
	public void onInterstitialAvailability( string stringAvailable ){
		bool isAvailable = (stringAvailable == "true") ? true : false;
		if( _onInterstitialAvailabilityEvent != null )
			_onInterstitialAvailabilityEvent( isAvailable );
	}





	private static event Action _onInterstitialShowSuccessEvent;
	public static event Action onInterstitialShowSuccessEvent{
		add{
			if (_onInterstitialShowSuccessEvent == null || !_onInterstitialShowSuccessEvent.GetInvocationList().Contains(value)){
				_onInterstitialShowSuccessEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialShowSuccessEvent.GetInvocationList().Contains(value)){
				_onInterstitialShowSuccessEvent -= value;
			}
		}
	}
	
	public void onInterstitialShowSuccess( string empty ){
		if (_onInterstitialShowSuccessEvent != null) {
			_onInterstitialShowSuccessEvent();
		}
	}





	private static event Action<SupersonicError> _onInterstitialShowFailEvent;
	public static event Action<SupersonicError> onInterstitialShowFailEvent{
		add{
			if (_onInterstitialShowFailEvent == null || !_onInterstitialShowFailEvent.GetInvocationList().Contains(value)){
				_onInterstitialShowFailEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialShowFailEvent.GetInvocationList().Contains(value)){
				_onInterstitialShowFailEvent -= value;
			}
		}
	}
	
	public void onInterstitialShowFail( string description ){
		if (_onInterstitialShowFailEvent != null) {
			SupersonicError sse = getErrorFromErrorString(description);
			_onInterstitialShowFailEvent( sse );
		}
			
	}





	private static event Action _onInterstitialAdClickedEvent;
	public static event Action onInterstitialAdClickedEvent{
		add{
			if (_onInterstitialAdClickedEvent == null || !_onInterstitialAdClickedEvent.GetInvocationList().Contains(value)){
				_onInterstitialAdClickedEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialAdClickedEvent.GetInvocationList().Contains(value)){
				_onInterstitialAdClickedEvent -= value;
			}
		}
	}
	
	public void onInterstitialAdClicked( string empty ){
		if (_onInterstitialAdClickedEvent != null) {
			_onInterstitialAdClickedEvent();
		}
	}




	private static event Action _onInterstitialAdClosedEvent;
	public static event Action onInterstitialAdClosedEvent{
		add{
			if (_onInterstitialAdClosedEvent == null || !_onInterstitialAdClosedEvent.GetInvocationList().Contains(value)){
				_onInterstitialAdClosedEvent += value;
			}
		}
		
		remove{
			if(_onInterstitialAdClosedEvent.GetInvocationList().Contains(value)){
				_onInterstitialAdClosedEvent -= value;
			}
		}
	}
	
	public void onInterstitialAdClosed( string empty ){
		if (_onInterstitialAdClosedEvent != null) {
			_onInterstitialAdClosedEvent();
		}
	}
	



	// ******************************* OfferwallEvents *******************************


	private static event Action _onOfferwallInitSuccessEvent;
	public static event Action onOfferwallInitSuccessEvent{
		add{
			if (_onOfferwallInitSuccessEvent == null || !_onOfferwallInitSuccessEvent.GetInvocationList().Contains(value)){
				_onOfferwallInitSuccessEvent += value;
			}
		}
		
		remove{
			if(_onOfferwallInitSuccessEvent.GetInvocationList().Contains(value)){
				_onOfferwallInitSuccessEvent -= value;
			}
			
		}
	}
	
	public void onOfferwallInitSuccess( string empty ){
		if (_onOfferwallInitSuccessEvent != null) {
			_onOfferwallInitSuccessEvent();
		}
	}





	private static event Action<SupersonicError> _onOfferwallInitFailEvent;
	public static event Action<SupersonicError> onOfferwallInitFailEvent{
		add{
			if (_onOfferwallInitFailEvent == null || !_onOfferwallInitFailEvent.GetInvocationList().Contains(value)){
				_onOfferwallInitFailEvent += value;
			}
		}
		
		remove{
			if(_onOfferwallInitFailEvent.GetInvocationList().Contains(value)){
				_onOfferwallInitFailEvent -= value;
			}
		}
	}
	
	public void onOfferwallInitFail( string description ){
		if (_onOfferwallInitFailEvent != null) {
			SupersonicError sse = getErrorFromErrorString(description);
			_onOfferwallInitFailEvent( sse );
		}
			
	}




	private static event Action _onOfferwallOpenedEvent;
	public static event Action onOfferwallOpenedEvent{
		add{
			if (_onOfferwallOpenedEvent == null || !_onOfferwallOpenedEvent.GetInvocationList().Contains(value)){
				_onOfferwallOpenedEvent += value;
			}
		}
		
		remove{
			if(_onOfferwallOpenedEvent.GetInvocationList().Contains(value)){
				_onOfferwallOpenedEvent -= value;
			}
			
		}
	}
	
	public void onOfferwallOpened( string empty ){
		if (_onOfferwallOpenedEvent != null) {
			_onOfferwallOpenedEvent();
		}
	}





	private static event Action<SupersonicError> _onOfferwallShowFailEvent;
	public static event Action<SupersonicError> onOfferwallShowFailEvent{
		add{
			if (_onOfferwallShowFailEvent == null || !_onOfferwallShowFailEvent.GetInvocationList().Contains(value)){
				_onOfferwallShowFailEvent += value;
			}
		}
		
		remove{
			if(_onOfferwallShowFailEvent.GetInvocationList().Contains(value)){
				_onOfferwallShowFailEvent -= value;
			}
		}
	}
	
	public void onOfferwallShowFail( string description ){
		if (_onOfferwallShowFailEvent != null) {
			SupersonicError sse = getErrorFromErrorString(description);
			_onOfferwallShowFailEvent( sse );
		}
			
	}




	private static event Action _onOfferwallClosedEvent;
	public static event Action onOfferwallClosedEvent{
		add{
			if (_onOfferwallClosedEvent == null || !_onOfferwallClosedEvent.GetInvocationList().Contains(value)){
				_onOfferwallClosedEvent += value;
			}
		}
		
		remove{
			if(_onOfferwallClosedEvent.GetInvocationList().Contains(value)){
				_onOfferwallClosedEvent -= value;
			}
			
		}
	}
	
	public void onOfferwallClosed( string empty ){
		if (_onOfferwallClosedEvent != null) {
			_onOfferwallClosedEvent();
		}
	}




	private static event Action<SupersonicError> _onGetOfferwallCreditsFailEvent;
	public static event Action<SupersonicError> onGetOfferwallCreditsFailEvent{
		add{
			if (_onGetOfferwallCreditsFailEvent == null || !_onGetOfferwallCreditsFailEvent.GetInvocationList().Contains(value)){
				_onGetOfferwallCreditsFailEvent += value;
			}
		}
		
		remove{
			if(_onGetOfferwallCreditsFailEvent.GetInvocationList().Contains(value)){
				_onGetOfferwallCreditsFailEvent -= value;
			}
		}
	}
	
	public void onGetOfferwallCreditsFail( string description ){
		if (_onGetOfferwallCreditsFailEvent != null) {
			SupersonicError sse = getErrorFromErrorString(description);
			_onGetOfferwallCreditsFailEvent (sse);

		}
	}





	private static event Action<Dictionary<string,object>> _onOfferwallAdCreditedEvent;
	public static event Action<Dictionary<string,object>> onOfferwallAdCreditedEvent{
		add {
			if (_onOfferwallAdCreditedEvent == null || !_onOfferwallAdCreditedEvent.GetInvocationList ().Contains (value)) 
			{
				_onOfferwallAdCreditedEvent += value;
			}
		}

		remove {
			if(_onOfferwallAdCreditedEvent.GetInvocationList().Contains(value)){
				_onOfferwallAdCreditedEvent -= value;
			}
		}
	}

	public void onOfferwallAdCredited( string json ){
		if( _onOfferwallAdCreditedEvent != null )
			_onOfferwallAdCreditedEvent( SupersonicJSON.Json.Deserialize( json ) as Dictionary<string,object> );
	}

	public SupersonicError getErrorFromErrorString(string description){
		Dictionary<string,object> error = SupersonicJSON.Json.Deserialize( description ) as Dictionary<string,object>;
		SupersonicError sse;
		// if there is a supersonic error
		if (error != null) {
			int eCode = Convert.ToInt32 (error [ERROR_CODE].ToString ());
			string eDescription = error [ERROR_DESCRIPTION].ToString ();
			sse = new SupersonicError (eCode, eDescription);
		} 
		// else create an empty one
		else 
		{
			sse = new SupersonicError (-1, "");
		}

		return sse;
	}

	public SupersonicPlacement getPlacementFromString(string jsonPlacement){
		
		Dictionary<string,object> placementJSON = SupersonicJSON.Json.Deserialize( jsonPlacement ) as Dictionary<string,object>;
		SupersonicPlacement ssp;
		int rewardAmount = Convert.ToInt32 (placementJSON ["placement_reward_amount"].ToString ());
		string rewardName = placementJSON ["placement_reward_name"].ToString ();
		string placementName = placementJSON ["placement_name"].ToString ();
		
		ssp = new SupersonicPlacement (placementName,rewardName, rewardAmount);
		return ssp;
	}

	

}
