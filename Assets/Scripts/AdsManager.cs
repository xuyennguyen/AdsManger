using UnityEngine;
using System.Collections;
using Prime31;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	private static AdsManager _instance;
	public static AdsManager Instance{

		get{
			if (_instance == null) {

				_instance = new AdsManager ();
			}
			return _instance;
		}
	}


	public  AdsType adsType;

	private  AdSize adSize;
	private  AdPosition position;

	private  static InterstitialAd interstitialAds;
	private  static  BannerView bannerAds;

	public bool isInterstitialAdLoaded = false;

	// delegate

	public delegate void ShowBannerEvent();
	public static event ShowBannerEvent OnShowBanner;

	public delegate void ShowFullScreenEvent();
	public static event ShowFullScreenEvent OnShowFullScreen;

	public delegate void VideoStartedEvent();
	public static event VideoStartedEvent OnVideoStarted;

	public delegate void VideoFinishedEvent();
	public static event VideoFinishedEvent OnVideoFinished;





	void OnEnable(){

		Debug.Log ("AdsManger OnEnable");
		// AdColony event
		AdColony.OnVideoStarted = this.AdColonyEvents_onVideoStartedEvent;
		AdColony.OnVideoFinished = this.AdColonyEvents_onVideoFinished;
		AdColony.OnAdAvailabilityChange = this.AdColonyEvents_onAdAvailabilityChange;
		AdColony.OnV4VCResult = this.AdColonyEvents_onV4VCResult;

		//SupersonicEvent 
		SupersonicEvents.onRewardedVideoInitSuccessEvent += SupersonicEvents_onRewardedVideoInitSuccessEvent;
		SupersonicEvents.onRewardedVideoInitFailEvent += SupersonicEvents_onRewardedVideoInitFailEvent;
		SupersonicEvents.onRewardedVideoAdClosedEvent += SupersonicEvents_onRewardedVideoAdClosedEvent;
		SupersonicEvents.onRewardedVideoAdOpenedEvent += SupersonicEvents_onRewardedVideoAdOpenedEvent;
		SupersonicEvents.onRewardedVideoAdRewardedEvent += SupersonicEvents_onRewardedVideoAdRewardedEvent;
		SupersonicEvents.onVideoAvailabilityChangedEvent += SupersonicEvents_onVideoAvailabilityChangedEvent;
		SupersonicEvents.onVideoEndEvent += SupersonicEvents_onVideoEndEvent;
		SupersonicEvents.onVideoStartEvent += SupersonicEvents_onVideoStartEvent;

	}

	void OnDisable(){

		Debug.Log ("AdsManger OnDisable");

		//SupersonicEvent 
		SupersonicEvents.onRewardedVideoInitSuccessEvent -= SupersonicEvents_onRewardedVideoInitSuccessEvent;
		SupersonicEvents.onRewardedVideoInitFailEvent -= SupersonicEvents_onRewardedVideoInitFailEvent;
		SupersonicEvents.onRewardedVideoAdClosedEvent -= SupersonicEvents_onRewardedVideoAdClosedEvent;
		SupersonicEvents.onRewardedVideoAdOpenedEvent -= SupersonicEvents_onRewardedVideoAdOpenedEvent;
		SupersonicEvents.onRewardedVideoAdRewardedEvent -= SupersonicEvents_onRewardedVideoAdRewardedEvent;
		SupersonicEvents.onVideoAvailabilityChangedEvent -= SupersonicEvents_onVideoAvailabilityChangedEvent;
		SupersonicEvents.onVideoEndEvent -= SupersonicEvents_onVideoEndEvent;
		SupersonicEvents.onVideoStartEvent -= SupersonicEvents_onVideoStartEvent;

	}


	void Start(){

		Debug.Log ("AdsManger OnStart");


		FetechFullscreenAds ();

		InitAdColony ();
		InitAdSupersonic ();
		//InitUnityAds ();
		_instance = this;
	}
	public  void FetechBannerAds(AdsType type, AdSize size){
		
		if (adsType == AdsType.BannerBottom) {
			
			position = AdPosition.Bottom;
		} else if (adsType == AdsType.BannerTop) {

			position = AdPosition.Top;
		} else {
			position = AdPosition.Bottom;
		}

		if (size == AdSize.Banner) {
			
			adSize = AdSize.Banner;

		} else if (size == AdSize.SmartBanner) {
			
			adSize = AdSize.SmartBanner;
		} else {
			
			adSize = AdSize.Banner;
		}
			
		bannerAds = new BannerView (AdsConfig.AdsAdmobBannerPlacement, size, position);

		if (bannerAds != null) {
			
			AdRequest request = new AdRequest.Builder().AddTestDevice("063215AC51C16009CE71243D30B7C2A1").Build();

			bannerAds.LoadAd (request);

			bannerAds.AdLoaded += BannerAds_AdLoaded;
			bannerAds.AdFailedToLoad += BannerAds_AdFailedToLoad;
			bannerAds.AdOpened += BannerAds_AdOpened;
			bannerAds.AdClosing += BannerAds_AdClosing;
			bannerAds.AdClosed += BannerAds_AdClosed;
			bannerAds.AdLeftApplication += BannerAds_AdLeftApplication;


		} else {

			Debug.LogError ("AdsManger: Banner Ads isn't, please init it");
		}

	}

	void BannerAds_AdLeftApplication (object sender, System.EventArgs e)
	{
		
	}

	void BannerAds_AdClosed (object sender, System.EventArgs e)
	{
		
	}

	void BannerAds_AdClosing (object sender, System.EventArgs e)
	{
		
	}

	void BannerAds_AdOpened (object sender, System.EventArgs e)
	{
		
	}

	void BannerAds_AdFailedToLoad (object sender, AdFailedToLoadEventArgs e)
	{
		Debug.Log ("AdsManger BannerAds_AdFailedToLoad");
	}

	void BannerAds_AdLoaded (object sender, System.EventArgs e)
	{

		Debug.Log ("AdsManger BannerAds_AdLoaded");
	}

	public  void FetechFullscreenAds(){


		interstitialAds = new InterstitialAd (AdsConfig.AdsAdmobIntertitialPlacement);
		if (interstitialAds != null) {


			AdRequest finterstitialRequest = new AdRequest.Builder().AddTestDevice("063215AC51C16009CE71243D30B7C2A1").Build();
			interstitialAds.LoadAd (finterstitialRequest);
			interstitialAds.AdLoaded += InterstitialAds_AdLoaded;
			interstitialAds.AdFailedToLoad += InterstitialAds_AdFailedToLoad;
			interstitialAds.AdOpened += InterstitialAds_AdOpened;
			interstitialAds.AdClosing += InterstitialAds_AdClosing;
			interstitialAds.AdClosed += InterstitialAds_AdClosed;
			interstitialAds.AdLeftApplication += InterstitialAds_AdLeftApplication;

		} else {

			Debug.LogError ("AdsManger: Interstital Ads isn't, please init it");
		}
	}


	void InterstitialAds_AdLeftApplication (object sender, System.EventArgs e)
	{
		
	}

	void InterstitialAds_AdClosed (object sender, System.EventArgs e)
	{
		
	}

	void InterstitialAds_AdClosing (object sender, System.EventArgs e)
	{
		
	}

	void InterstitialAds_AdOpened (object sender, System.EventArgs e)
	{
		
	}

	void InterstitialAds_AdFailedToLoad (object sender, AdFailedToLoadEventArgs e)
	{
		isInterstitialAdLoaded = false;
		Debug.Log ("AdsManger InterstitialAds_AdFailedToLoad");
	}

	void InterstitialAds_AdLoaded (object sender, System.EventArgs e)
	{
		isInterstitialAdLoaded = true;
		Debug.Log ("AdsManger InterstitialAds_AdLoaded");
	}

	public void ShowInterstitial(){
		

		if (interstitialAds.IsLoaded () == false) {
		
			FetechFullscreenAds ();
		}

		Debug.Log ("AdsManager: interstitialAds.IsLoaded:" + interstitialAds.IsLoaded ());

		if( interstitialAds != null && interstitialAds.IsLoaded()){

			Debug.Log ("AdsManger ShowInterstitial");
			interstitialAds.Show();

		}
	}

	public  void InitAdColony(){

	
		AdColony.Configure
		(
			"version:1.0,store:google",
			AdsConfig.AdsAdColonyAppId,  // app id
			AdsConfig.AdsColonyAdPlacement // zone id
		);

	}

	public  void InitAdSupersonic(){

		string AdsSupersonicUniqueUser = SystemInfo.deviceUniqueIdentifier;
		Debug.Log ("AdsManger  AdsSupersonicUniqueUser :" + AdsSupersonicUniqueUser);
		Supersonic.Agent.start ();
		Supersonic.Agent.initRewardedVideo (AdsConfig.AdsSupersonicAppId, AdsSupersonicUniqueUser);
		

	}

	public void InitUnityAds(){
		
		//Advertisement.Initialize (AdsConfig.AdsUnityAdsAppId, true);
		
	}

	public void PlayAVideo(string adPlacement){

		if (OnVideoStarted != null) {
			OnVideoStarted ();
		}
		if (AdColony.IsVideoAvailable (adPlacement)) {

			Debug.Log ("Play a video");
			AdColony.ShowVideoAd (adPlacement);

		} else if (Supersonic.Agent.isRewardedVideoAvailable ()) {

			Debug.Log ("Play a supersonic's video");
			Supersonic.Agent.showRewardedVideo (adPlacement);

		} else if( Advertisement.isReady(adPlacement)){

			ShowOptions options = new ShowOptions ();
			options.resultCallback = AdCallbackHandler;
			Advertisement.Show (adPlacement, options);
		}

		else {
			Debug.Log ("No video to show");
		}

	}


	public bool IsVideoAvailable(){


		return (AdColony.IsVideoAvailable (AdsConfig.AdsColonyAdPlacement) || Supersonic.Agent.isRewardedVideoAvailable () || Advertisement.IsReady (AdsConfig.AdsUnityAdsPlacement));

	}
	public void ShowBanner(){
		
		FetechBannerAds (AdsType.BannerBottom, AdSize.Banner);
		if (OnShowBanner != null) {

			OnShowBanner ();
		}
		if (bannerAds != null) {
			
			bannerAds.Show ();
		}
	}

	public void HideBanner(){

		Debug.Log ("AdsManager HideBanner");
		if (bannerAds != null) {

			Debug.Log ("AdsManager HideBanner - 1");
			bannerAds.Hide ();
		}
	}



	// for AdColony Ads
	void AdColonyEvents_onVideoStartedEvent(){
	}


	void AdColonyEvents_onVideoFinished(bool ad_was_show){
		
	}

	void AdColonyEvents_onV4VCResult(bool success, string name, int amount){
	
	}


	void AdColonyEvents_onAdAvailabilityChange(bool avail, string zoneId){
	}


	void SupersonicEvents_onVideoStartEvent ()
	{

	}

	void SupersonicEvents_onVideoEndEvent ()
	{

	}

	void SupersonicEvents_onVideoAvailabilityChangedEvent (bool obj)
	{

	}

	void SupersonicEvents_onRewardedVideoAdRewardedEvent(SupersonicPlacement placement){

	}
	void SupersonicEvents_onRewardedVideoAdOpenedEvent(){

	}
	void SupersonicEvents_onRewardedVideoAdClosedEvent ()
	{

	}

	void SupersonicEvents_onRewardedVideoInitFailEvent (SupersonicError obj)
	{

	}

	void SupersonicEvents_onRewardedVideoInitSuccessEvent ()
	{

	}

	void AdCallbackHandler(ShowResult result){
		
		switch(result)
		{
		case ShowResult.Finished:
			//Debug.Log ("Ad Finished. Rewarding player...");

			if (OnVideoFinished != null) {
				OnVideoFinished ();
			}
			break;
		case ShowResult.Skipped:
			//Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			//Debug.Log("I swear this has never happened to me before");
			break;
		}
	}

	void OnApplicationQuit(){

		bannerAds.Destroy ();
		interstitialAds.Destroy ();
	}
}
