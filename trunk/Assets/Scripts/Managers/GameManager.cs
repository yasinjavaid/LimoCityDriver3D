using UnityEngine;
using System.Collections;

public class GameManager : SingeltonBase<GameManager> {
	
	private bool gameLaunch = true; // tobe removed from here
	public enum GameState 
	{ 
		INTRO,
		MAINMENU, 
		EPISODEMENU, 
		LEVELSELECTIONMENU, 
		VEHICLESELECTIONMENU,
		CAMERAROTATION,
		CRASHED,
		TIMEOVER,
		PAUSED,
		GAMEPLAY, 
		RATEUS, 
		OUTOFCOINS, 
		STORE,
		LEVELCOMPLETE,
		LEVELSKIP,
		LEVELSETTINGS,
		LEVELEXIT,
		THANKYOU,
		EPISODEUNLOCK,
		LOADING,
		REWARDMENU,
		UNLOCKALLLEVELS,
		LOCKEDLEVELUNLOCK,
		VEHICLEUPGRADEMENU,
		OUTOFCOINSENGINEUPGRADE,
		OUTOFCOINSSTEERINGUPGRADE,
		OUTOFCOINSBRAKESUPGRADE,
		OUTOFCOINSTYRESUPGRADE,
		CONFIRMENGINEUPGRADE,
		CONFIRMSTEERINGUPGRADE,
		CONFIRMBRAKESUPGRADE,
		CONFIRMTYRESUPGRADE,
		// Added by nawaz for vehicle
		VEHICLEUNLOCK,
		//Added By Ali for Parking
		PARKED,
		// Added for dialog lvl instructions
		PICKPASSENGERINSTRUCTIONS,
		DROPPASSENGERINSTRUCTIONS,
		Tutorial
	
		
	};
	
	public enum SoundState 
	{ 
		BUTTONCLICKSOUND,
		LEVELFAILSOUND,
		LEVELSUCCESSSOUND,
		POPUPSOUND,
		VEHICLECRASHSOUND,
		VEHICLESTARTSOUND,
		MUTESOUND,
		UNMUTESOUND,
		IAPSUCCESSSOUND,
		APPLAUSESOUND,
		NONE
	};
	
	private GameState previousGameState;
	private GameState currentGameState;
	private SoundState currentSoundState;
	private int RateUsCount = 0;
	public delegate void StateHandler (GameState state);
	public event StateHandler OnStateChange;
	
	// Use this for initialization
	void Start () {
			string currentSystemLanguage=Application.systemLanguage.ToString();
		
		if(currentSystemLanguage.Equals("French"))
		{
			Localization.instance.currentLanguage="French";
		}
		if(currentSystemLanguage.Equals("English"))
		{
			Localization.instance.currentLanguage="English";
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region StateHandler
	public GameState GetCurrentGameState()
	{
		return currentGameState;
	}
	
	public GameState GetPreviousGameState()
	{
		return previousGameState;
	}
	public void SetPreviousGameState(GameState state)
	{
		 previousGameState=state;
	}
	
	public SoundState GetSoundState()
	{
		return currentSoundState;
	}
	
	private void SetGameState(GameState state)
	{
		previousGameState = currentGameState;
		currentGameState = state;
	}
	
	private void SetSoundState(SoundState state)
	{
		currentSoundState = state;
	}
	
	public void ChangeState (GameState state)
	{
		
		Debug.Log("curre state game maneg " + GameManager.Instance.GetCurrentGameState());
		
		SetGameState(state);
//		if(state != GameState.MAINMENU)
//		{
				AdsManager.Instance.DisplayAd(); 
//		}
		if(gameLaunch){
				gameLaunch = false;
				UserPrefs.Load();
				
		}
		
		/// to be removed above lines and only call adsmanager
		
		if(RateUsCount==2   &&  state == GameState.LEVELCOMPLETE   &&  !UserPrefs.isRatesUS){
			SetGameState(GameState.RATEUS);
			state = GameState.RATEUS;
			RateUsCount++;
		}
		//added on 15 jan
		SubMenuManagerPrent.Instance.SwitchMenu(state);
		switch(currentGameState)
		{
			case GameState.INTRO:
				break;
			case GameState.MAINMENU:
//				AdsManager.Instance.DisplayAd();
				break;
			case GameState.TIMEOVER:
				SubmitScore(UserPrefs.vehiclesParked, UserPrefs.coinsCollected);
				SubmitAchievement();
//				AdsManager.Instance.DisplayAd();
				break;
			case GameState.PAUSED:
				break;
			case GameState.PICKPASSENGERINSTRUCTIONS:
				break;
			case GameState.DROPPASSENGERINSTRUCTIONS:
				break;
			case GameState.LEVELCOMPLETE:
				RateUsCount++;
				SubmitScore(UserPrefs.vehiclesParked, UserPrefs.coinsCollected);
				SubmitAchievement();
	//			AdsManager.Instance.DisplayAd();
				break;
			case GameState.GAMEPLAY:
				GAManager.Instance.LogDesignEvent("PlayArea:Start");
//				AdsManager.Instance.DisplayAd();
				break;
			case GameState.CRASHED:
				SubmitScore(UserPrefs.vehiclesParked, UserPrefs.coinsCollected);
				SubmitAchievement();
//				AdsManager.Instance.DisplayAd();
				break;			
		}
		
		
	}
		
	public void ChangeState (SoundState soundState)
	{	
		SetSoundState(soundState);
		SoundManager.Instance.PlaySound();
	}
	
	public void ChangeState ( SoundState soundState, GameState gameState )
	{
//		SetGameState(gameState);
//		SetSoundState(soundState);
//		SoundManager.Instance.PlaySound();
//		AdsManager.Instance.DisplayAd();
//		SubMenuManager.Instance.SwitchMenu(gameState);
		ChangeState(gameState);
		ChangeState(soundState);
		//commented on 15 jan
	//	SubMenuManager.Instance.SwitchMenu(gameState);
	}	
	#endregion
	
	
	#region IAPs
	public void PurchasePackage(string package)
	{
		StoreManager.Instance.PurchasePackage(package);
		GAManager.Instance.LogDesignEvent("Store:IAP:Try:"+GetPackagePrice(package));
	}
	
	public void Restore()
	{
		StoreManager.Instance.RestoreCompletedTransactions();
	}
	#endregion
	
	
	
	#region Leaderboard & Achievement
	public void ShowLeaderBoard()
	{
		GCManager.Instance.ShowLeaderBoard();
	}
	public void GoogleSignIn()
	{
		GCManager.Instance.GoogleSignIn();
	}
	
	public void ShowAchievements()
	{
		GCManager.Instance.ShowAchievements();
	}
	
	public void SubmitScore(long vehiclesParked, long coinsCollected)
	{
		GCManager.Instance.ValidateScore(vehiclesParked,coinsCollected);
	}
	
	public void SubmitAchievement()
	{
		if(!isNewMenu())
		{
			GCManager.Instance.ValidateAchievement();
		}
	}
	#endregion
	
	
	#region Coins Collection
	public void AddCoins(int coins)
	{		
		Debug.LogError("coins being added"+coins);
		UserPrefs.totalCoins += coins;
		UserPrefs.coinsCollected += coins;
		UserPrefs.Save();
	}
	
	public void SubtractCoins(int coins)
	{
		UserPrefs.totalCoins -= coins;
		Debug.Log("UserPrefs.totalCoinsUserPrefs.totalCoinsUserPrefs.totalCoinsUserPrefs.totalCoins"+UserPrefs.totalCoins);
		UserPrefs.Save();
	}
	
	
	public void PurchaseProductResult(string package, bool result)
	{
		Debug.Log("purchase prodcut result " + result );
		if (isNewMenu()){
			Debug.LogError("Inside New menus check and going to update coins");
			updateCoinsCount(package, result);
			return;
		}
		if(result)
		{
			LogGAEvent(package,result);
			SetSoundState(SoundState.IAPSUCCESSSOUND);			
			SoundManager.Instance.PlaySound();
//			StoreManager.Instance.PurchaseProductResult(result);
			if(package == Constants.PACKAGE_1)
			{
				AddCoins(Constants.PACKAGE_1_AMOUNT);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == Constants.PACKAGE_2)
			{
				AddCoins(Constants.PACKAGE_2_AMOUNT);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == Constants.PACKAGE_3)
			{
				AddCoins(Constants.PACKAGE_3_AMOUNT);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == Constants.PACKAGE_4)
			{
				AddCoins(Constants.PACKAGE_4_AMOUNT);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == Constants.UNLOCKALLEPISODE)
			{				
				MenuManager.Instance.unlockAllEpisodes();
			}
			else if(package == Constants.REMOVEADS)
			{
				AdsManager.Instance.removeAds();
			}
			else if (package == Constants.UNLOCKALLVEHICLE)
			{
				MenuManager.Instance.unlockAllVehicles();
				
			}
			else if (package == Constants.UNLOCKALL)
			{
				MenuManager.Instance.unlockAllVehicles();
				MenuManager.Instance.unlockAllEpisodes();
				
				for( int i = 0 ; i < UserPrefs.unlockLevelsArrays.Length ; i++)
					UserPrefs.unlockLevelsArrays[i] = 12;
				
				AdsManager.Instance.removeAds();				
			}
			
			Debug.Log("menu purchase prodcut result " + result );		
			SubmitScore(UserPrefs.vehiclesParked, UserPrefs.coinsCollected);
			SubmitAchievement();
			
			if((package == Constants.UNLOCKALLEPISODE || package == Constants.REMOVEADS || package == Constants.UNLOCKALLVEHICLE || package == Constants.UNLOCKALL) && GetCurrentGameState() == GameState.MAINMENU){
				if(UserPrefs.isRestoreTransaction){
					MenuManager.Instance.PurchaseProductResult(package, result);
				}
			} else {
				MenuManager.Instance.PurchaseProductResult(package, result);
			}
		} 
	}
	
	public void updateCoinsCount(string package, bool result){
		
		LogGAEventPro(package,result);
		
		LogTapStreamEvent(package, result);
		
		if(result)
		{
			Debug.LogError("going to display package value "+package);
			Debug.LogError("Package= "+package);
			Debug.LogError("After display package value "+package);
			SetSoundState(SoundState.IAPSUCCESSSOUND);			
			SoundManager.Instance.PlaySound();
//			StoreManager.Instance.PurchaseProductResult(result);
			if(package == ConstantsNew.PACKAGE_1 || package == ConstantsNew.PACKAGE_TEST)
			{
				AddCoins(ConstantsNew.PACKAGE_1_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == ConstantsNew.PACKAGE_2)
			{
				AddCoins(ConstantsNew.PACKAGE_2_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == ConstantsNew.PACKAGE_3)
			{
				AddCoins(ConstantsNew.PACKAGE_3_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == ConstantsNew.PACKAGE_4)
			{
				AddCoins(ConstantsNew.PACKAGE_4_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == ConstantsNew.PACKAGE_5)
			{
				AddCoins(ConstantsNew.PACKAGE_5_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			else if(package == ConstantsNew.PACKAGE_VGP)
			{
				AddCoins(ConstantsNew.PACKAGE_1_Coins);
				UserPrefs.isCoinsPurchsed = true;
			}
			MenuManager.Instance.PurchaseProductResult(package, result);
		}
	}
	
	#endregion
	
	#region GameAnalatics
	
	private void LogGAEvent(string package , bool result){
		
		if(result){
			GAManager.Instance.LogBusinessEvent("Store:IAP:Success:",Constants.INAPP_CURRENCY,GetPackagePrice(package));
		} else {
			GAManager.Instance.LogDesignEvent("Store:IAP:Fail:"+GetPackagePrice(package));
		}
		
	}
	
	private int GetPackagePrice(string package){
		
		int price = 0;
		
		if(package == Constants.PACKAGE_1)
		{
			price = 99;
		}
		else if(package == Constants.PACKAGE_2)
		{
			price = 199;
		}
		else if(package == Constants.PACKAGE_3)
		{
			price = 299;
		}
		else if(package == Constants.PACKAGE_4)
		{
			price = 399;
		}
		else if(package == Constants.REMOVEADS)
		{
			price = 99;
		}
		else if(package == Constants.UNLOCKALLEPISODE)
		{
			price = 499;
		}
		else if(package == Constants.UNLOCKALLVEHICLE)
		{
			price = 499;
		}
		else if(package == Constants.UNLOCKALL)
		{
			price = 699;
		}		
		return price;
	}
	
	private void LogGAEventPro(string package , bool result){
		
		if(result){
			GAManager.Instance.LogBusinessEvent("Store:IAP:Success:",Constants.INAPP_CURRENCY,GetProPackagePrices(package));
		} else {
			GAManager.Instance.LogDesignEvent("Store:IAP:Fail:"+GetProPackagePrices(package));
		}
	}
	
	private int GetProPackagePrices(string package){
		
		int price = 0;
		
		if(package == ConstantsNew.PACKAGE_1)
		{
			price = 2999;
		}
		else if(package == ConstantsNew.PACKAGE_2)
		{
			price = 999;
		}
		else if(package == ConstantsNew.PACKAGE_3)
		{
			price = 499;
		}
		else if(package == ConstantsNew.PACKAGE_4)
		{
			price = 299;
		}
		else if(package == ConstantsNew.PACKAGE_5)
		{
			price = 99;
		}
		return price;
	}
	
	#endregion
	
	
	public void AddTime(float time)
	{
		if(!isNewMenu()){
			GameObject.FindGameObjectWithTag("Thumb").SendMessage("AddTime", time, SendMessageOptions.RequireReceiver);			
		}
		else{
			GameObject.FindGameObjectWithTag("btnSpots").SendMessage("AddTime", time, SendMessageOptions.RequireReceiver);			
		}
	}
	public void ShowTime(int price)
	{
		if(!isNewMenu()){
				GameObject.FindGameObjectWithTag("TimerText").SendMessage("ScaledTimerText", price, SendMessageOptions.RequireReceiver);	
		}

	}
	
	public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}
	#region tapstream
	
	private void LogTapStreamEvent(string package, bool result){
		Tapstream.Event e = new Tapstream.Event("LimoCityDriver3D", false);
		e.AddPair(package, GetProPackagePrices(package));
		Tapstream.FireEvent(e);	
	}
	
	#endregion
//	public void ChangeGameState (GameState state)
//	{
//		previousGameState = currentGameState;
//		currentGameState = state;
//								
//		switch(currentGameState)
//		{
//			case GameState.INTRO:
//				break;
//			case GameState.MAINMENU:
//			
//				break;
//			case GameState.TIMEOVER:
//				break;
//			case GameState.PAUSED:
//				break;
//			case GameState.LEVELCOMPLETE:
//				break;
//			case GameState.GAMEPLAY:
//				break;
////			case GameState.INTRO:
////				break;
////			case GameState.INTRO:
////				break;
//		}
//		
//		
//		if(OnStateChange != null)
//			OnStateChange(currentGameState);
//	}
}
