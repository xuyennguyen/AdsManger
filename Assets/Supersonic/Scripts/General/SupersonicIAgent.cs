
public interface SupersonicIAgent{

	void start();
	void reportAppStarted();

	//Base API
	void onResume();
	void onPause();
	void setAge(int age);
	void setGender(string gender);


	//BaseRewardedVideo API
	void initRewardedVideo(string appKey,string userId);
	void showRewardedVideo();
	bool isRewardedVideoAvailable();
	void showRewardedVideo(string placementName);

	SupersonicPlacement getPlacementInfo (string name);
		
	//Interstitial API
	void initInterstitial(string appKey,string userId);
	void showInterstitial();
	bool isInterstitialAdAvailalbe();

	//Offerwall API
	void initOfferwall(string appKey,string userId);
	void showOfferwall();
	bool isOfferwallAvailable();
	void getOfferwallCredits();


}
