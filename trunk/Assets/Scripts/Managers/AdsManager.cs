using UnityEngine;
using System.Collections;

public class AdsManager : SingeltonBase<AdsManager> {
	
	// Use this for initialization
	public int displayAdAfterLvl = 1;
	private int localCount = 0;
	private bool gameLaunch = true;
	private double pauseTime;
	private double timeLimit;
	private double timeDifference;
	
	void Start () {		
		
		pauseTime = 0.0f;
		timeLimit = 180.0f; // enter timeLimit in seconds => 1800.0f = 30 mins
		timeDifference = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DisplayAd()
	{
		
		if(UserPrefs.isAmazonBuild){
			if(gameLaunch){
				gameLaunch = false;
				UserPrefs.Load();
			}
			return;
		}
		
		switch(GameManager.Instance.GetCurrentGameState())
		{
		case GameManager.GameState.MAINMENU:
			this.PlayHavenOrMopubAdOnMainMenu();
			this.hideBannerAds();
			break;
		case GameManager.GameState.GAMEPLAY:
			this.RequestForMopubAd();
			this.showBannnerAds();
			break;
			//		case GameManager.GameState.LEVELCOMPLETE:
			////			if(UserPrefs.currentLevel != 0 && UserPrefs.currentLevel%2 == 0)
			//				this.ShowMopubAdOnLevelEnd();
			//			break;
		case GameManager.GameState.VEHICLEUPGRADEMENU:
			//			if(UserPrefs.currentLevel != 0 && UserPrefs.currentLevel%2 == 0)
			this.ShowMopubAdOnLevelEnd();
			break;
		case GameManager.GameState.TIMEOVER:
			//this.ShowMopubAdOnLevelEnd();
			break;
			//		case GameManager.GameState.CRASHED:
			////			if(UserPrefs.currentLevel != 0 && UserPrefs.currentLevel%2 == 0)
			//				this.ShowMopubAdOnLevelEnd();
			//			break;
		}

		switch(GameManager.Instance.GetPreviousGameState())
		{
			case GameManager.GameState.PAUSED:	
				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU || 
				   GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LOADING)
					this.ShowMopubAdOnLevelEnd();
				break;
			case GameManager.GameState.TIMEOVER:
				if(!UserPrefs.isOutOfFuel){
					this.ShowMopubAdOnLevelEnd();
				} else {
					UserPrefs.isOutOfFuel = false;
				}
				break;
		}
	}
	private void RequestForMopubAd()
	{
		localCount ++;
		if(localCount == displayAdAfterLvl && !UserPrefs.isIgnoreAds)
		{
			Debug.Log("----------- Show MoPub Ad State: " + " Request sent");
			#if UNITY_ANDROID
			if (MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADED
			    && MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADING){
				MoPubAndroid.requestInterstitalAd(Constants.INTERSTITIAL_ID_ANDROID);
				MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.LOADING;
			}
			#endif
			#if UNITY_IPHONE
			MoPubBinding.requestInterstitialAd(Constants.INTERSTITIAL_ID_IOS,null);
			#endif
			localCount = 0;
		}
	}
	
	IEnumerator WaitForMopubAddOnMainMenu(float wait)
	{	
		Debug.Log("----------- before :: " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
		yield return new WaitForSeconds(wait);
		
		#if UNITY_ANDROID			
		if(MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.DISPLAYED
		   && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU){								
			ShowMopubAdOnMainMenu();							
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){				
			MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.NONE;	
			MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);								
		} 
		#endif
	}
	private void ShowMopubAdOnMainMenu()
	{
		
		ShowMopubAdOnMainMenuScreen();
		StartCoroutine(WaitForMopubAddOnMainMenu(1.0f));
		
		
	}
	private void PlayHavenOrMopubAdOnMainMenu()
	{
		if(gameLaunch)
		{
			UserPrefs.Load();
			#if UNITY_ANDROID
			if(!UserPrefs.isIgnoreAds)
			{
				MoPubAndroid.reportApplicationOpen();
				//				MoPubAndroid.initAppLovinSDK();
				//				MoPubAndroid.initHeyzapSDK(Constants.PUBLISHER_ID);
				//				MoPubAndroid.initPlayhavenSession();
			}
			#endif
			if(!UserPrefs.isIgnoreAds){			
				Debug.Log("++++ AdsManagerStart +++++");
				#if UNITY_ANDROID
				Upsight.init( Constants.AndroidAppTokenPlayHaven, Constants.AndroidAppSecretPlayHaven );
				#else
				Upsight.init( Constants.iOSAppTokenPlayHaven, Constants.iOSAppSecretPlayHaven );
				#endif			
				
				// Make an open request at every app launch
				Upsight.requestAppOpen();
				
				
				UpsightManager.makePurchaseEvent += myMakePurchaseMethod;
				UpsightManager.unlockedRewardEvent += myUnlockedRewardMethod;
				
				Upsight.sendContentRequest( "game_launch", true );
				

				
				//				CreateBannerAds();
				this.hideBannerAds();
				
			}
			
			
			
			gameLaunch = false;
			
			
		}
		//		else
		//		{
		//			if(!UserPrefs.isIgnoreAds)
		//			{
		//				#if UNITY_ANDROID
		//				if (MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADED
		//				    && MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADING){
		//					
		//					if(GameManager.Instance.GetPreviousGameState() != GameManager.GameState.LEVELSETTINGS){
		//						MoPubAndroid.requestInterstitalAd(Constants.INTERSTITIAL_ID_ANDROID);
		//						MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.LOADING;
		//						Debug.Log(" ++++ MoPub Ads Start Loading ++++");
		//					}
		//					
		//					
		//				}
		//				Debug.Log(" ++++ MoPub Ads State :"+MoPubAndroidManager.INTERSTITIAL_AD_STATE+" ++++");
		//				
		//				#endif
		//				#if UNITY_IPHONE
		//				MoPubBinding.requestInterstitialAd(Constants.INTERSTITIAL_ID_IOS,null);
		//				//				StartCoroutine(WaitForMopubAddOnMainMenu());
		//				//				if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED)
		//				//					MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID);
		//				#endif
		//				ShowMopubAdOnMainMenu();
		//			}
		//		}
		
	}
	
	private void ShowMopubAdOnMainMenuScreen(){		
		#if UNITY_ANDROID
		Debug.Log("----------- Show MoPub Ad State: " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
		if(MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED){
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
				MoPubAndroid.showInterstitalAd();	
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
				MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
		}
		
		#endif	
	}
	
	private void ShowMopubAdOnLevelEnd(){		
		#if UNITY_ANDROID
		Debug.Log("----------- Show MoPub Ad State: " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
		if(MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED){				
			MoPubAndroid.showInterstitalAd();
			Debug.Log("----------- Show MoPub Ad State: " + "SHOWN");
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
			MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
		}
		
		#endif	
	}
	
	public void PlayHavenOnMoreGames()
	{
		Upsight.sendContentRequest( "more_games", true );
	}
	
	void OnApplicationPause(bool status)
	{
		if(status)
		{
			pauseTime = Time.realtimeSinceStartup;
		}
		else
		{
			#if UNITY_ANDROID
			if(!UserPrefs.isIgnoreAds && !UserPrefs.isAmazonBuild)
				Upsight.requestAppOpen();
			#endif
			timeDifference = Time.realtimeSinceStartup - pauseTime;
			if(timeDifference >= timeLimit)
			{
				Debug.Log("Change the state");
				if(!UserPrefs.isIgnoreAds && !UserPrefs.isAmazonBuild)
					Upsight.sendContentRequest( "game_resume", true );
			}
			
		}
		
	}
	
	public void removeAds(){
		if(!UserPrefs.isIgnoreAds){
			UserPrefs.isIgnoreAds = true;
			UserPrefs.Save();
		}
	}
	
	void myMakePurchaseMethod( UpsightPurchase purchase )
	{
		if(purchase != null){
			# if UNITY_IPHONE
			if(StoreKitBinding.canMakePayments())
			{						
				StoreKitBinding.purchaseProduct(purchase.productIdentifier,purchase.quantity);
			}
			# endif
			
			# if UNITY_ANDROID		
			GoogleIAB.purchaseProduct(purchase.productIdentifier);
			# endif
		}			
	}
	
	void myUnlockedRewardMethod( UpsightReward reward )
	{
		if(reward != null){
			UserPrefs.totalCoins += reward.quantity;
			UserPrefs.Save();
		}
	}
	
	void CreateBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.createBanner( Constants.BANNER_ID_ANDROID, MoPubAdPlacement.TopCenter );
		//			#endif
		//			#if UNITY_IPHONE
		//				//MoPubAndroid.createBanner( Constants.BANNER_ID_IOS, MoPubAdPlacement.TopCenter );
		//			#endif
		//		}
	}
	
	public void DestroyBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.destroyBanner();
		//			#endif
		//			#if UNITY_IPHONE
		//				// Write here for destroy Banner ads code
		//			#endif
		//		}
	}
	
	void hideBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.hideBanner(true);
		//			#endif
		//			#if UNITY_IPHONE
		//				// Write here for hide banner ads code
		//			#endif
		//		}
	}
	
	void showBannnerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			if(!UserPrefs.isBannerAdsCreated){
		//				UserPrefs.isBannerAdsCreated = true;
		//				CreateBannerAds();
		//				return;
		//			}
		//			#if UNITY_ANDROID
		//				MoPubAndroid.hideBanner(false);
		//			#endif
		//			#if UNITY_IPHONE
		//			// Write here for show banner ads code
		//			#endif
		//		}
	}
	
}


