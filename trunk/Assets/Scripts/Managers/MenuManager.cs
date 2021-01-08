using UnityEngine;
using System.Collections;

public class MenuManager : SingeltonBase<MenuManager> {
	
	
	
	// user will simply drop all menus in that arrary from Inspector. The menu that drop first will come first respectively.

	// Decision Maker which menu to be loaded
	public int menuType;
	public string additionalUpgradeSelection;
	
	public GameObject[] MenusArray;
	public  int currentMenu;
	public  bool isVehicleMenuPresent ;
	
	AsyncOperation async;
	void Start () {
	//	UserPrefs.currentMenu = 0;		
		GameManager.Instance.ChangeState(GameManager.GameState.MAINMENU);
		if (menuType == 1){
			StartMenu();	
		}
		else{
			StartNewMenus();
		}
	}
	
	
	void Update () {
	
			#if UNITY_ANDROID
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{	
				BackButtonHandling();
			}
			
		#endif
	}

	
	public void StartMenu(){	
		
	//	Instantiate(MenusArray[currentMenu]) ;
		
		if(GameManager.Instance.GetCurrentGameState() ==  GameManager.GameState.MAINMENU)
		{
			Instantiate(Resources.Load("Menus/MainMenu"));
			currentMenu = 0;
		}
		else if( GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU)
		{
			Instantiate(Resources.Load("Menus/EpisodeMenu"));
			currentMenu = 1;
		}	
		else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LEVELSELECTIONMENU)
		{
			Instantiate(Resources.Load("Menus/LevelSelectionMenu"));
			currentMenu = 2;
		}
		else if( GameManager.Instance.GetCurrentGameState()  == GameManager.GameState.VEHICLESELECTIONMENU)
		{
			Instantiate(Resources.Load("Menus/VehicleSelectionMenu"));
			currentMenu = 3;
			
		}
		else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.STORE)
		{
			Instantiate(Resources.Load("Menus/StoreMenu"));
			GAManager.Instance.LogDesignEvent("Store:Open");
		}
		else{
			currentMenu = 0;
			Instantiate(Resources.Load("Menus/MainMenu"));
			GameManager.Instance.ChangeState(GameManager.GameState.MAINMENU);
		}
	}
	
	// Start New Menus

		public void StartNewMenus(){	
		
	//	Instantiate(MenusArray[currentMenu]) ;
		
		if(GameManager.Instance.GetCurrentGameState() ==  GameManager.GameState.VEHICLESELECTIONMENU)
		{
			Instantiate(Resources.Load("MenusNew/VehicleSelectionMenu"));
			currentMenu = 0;
		}
		else if( GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU)
		{
			Instantiate(Resources.Load("MenusNew/EpisodeMenu"));
			currentMenu = 1;
		}	
		else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLEUPGRADEMENU)
		{
			Instantiate(Resources.Load("MenusNew/VehicleUpgradeMenu"));
			currentMenu = 2;
		}
		else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.STORE)
		{
			Instantiate(Resources.Load("MenusNew/StoreMenu"));
			GAManager.Instance.LogDesignEvent("Store:Open");
		}
		else{
			currentMenu = 0;
			Instantiate(Resources.Load("MenusNew/VehicleSelectionMenu"));
			GameManager.Instance.ChangeState(GameManager.GameState.MAINMENU);
		}
	}

	public void SwitchNextMenu(){
		currentMenu++;
		ChangeState();
		Instantiate(MenusArray[currentMenu]) ;	
		Destroy(GameObject.FindGameObjectWithTag(MenusArray[currentMenu-1].name));
		Resources.UnloadUnusedAssets();
		
	}
	
	public void SwitchPreviousMenu(){
		if(currentMenu > 0)
			currentMenu--;
		ChangeState();
		Instantiate(MenusArray[currentMenu]) ;	
		Destroy(GameObject.FindGameObjectWithTag(MenusArray[currentMenu+1].name));
		Resources.UnloadUnusedAssets();
		
	}
	
	public void ReloadCurrentMenu(){
		//currentMenu++;
//		ChangeState();
		Destroy(GameObject.FindGameObjectWithTag(MenusArray[currentMenu-1].name));
		Resources.UnloadUnusedAssets();
		Instantiate(MenusArray[currentMenu]) ;	
		
	}
	
	public void ChangeState(){
		GameManager.GameState state = (GameManager.GameState)System.Enum.Parse(typeof(GameManager.GameState), MenusArray[currentMenu].name.ToUpper());
		
		switch(state){
		
			case GameManager.GameState.MAINMENU:
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
				break;
			}
			case GameManager.GameState.EPISODEMENU:
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.EPISODEMENU); 
				break;
			}
			case GameManager.GameState.VEHICLEUPGRADEMENU:{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
				break;
			}
			case GameManager.GameState.VEHICLESELECTIONMENU:
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				break;
			}
			case GameManager.GameState.LEVELSELECTIONMENU:
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSELECTIONMENU);
				break;
			}
			case GameManager.GameState.LOADING:
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
				StartCoroutine(LoadScene(0.2f));
				break;
			}
			
		}
		//Debug.Log(GameManager.Instance.GetCurrentGameState()   +  "    " + MenusArray[currentMenu].name.ToUpper());
	}
	
	public void ChangeState(GameManager.GameState state){
		
		GameManager.Instance.ChangeState(state);
	}
	
	public void OpenStore(){
		Debug.Log("store called ");
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		Destroy(GameObject.FindGameObjectWithTag("EpisodeMenu"));
		Resources.UnloadUnusedAssets();
		UserPrefs.currentStoreMenuScreen = 1;
		Instantiate ( Resources.Load ( "Menus/StoreMenu" ) ) ;	
		GAManager.Instance.LogDesignEvent("Store:Open");
		
	}
	
	public void PurchaseProductResult(string package,bool result){
			
			if(result){
				if(menuType == 2){
				
					if(!package.Equals(ConstantsNew.PACKAGE_VGP)){
						StoreMenuLocalize storeLocalize = GameObject.FindGameObjectWithTag("StoreMenu").GetComponent<StoreMenuLocalize>() as StoreMenuLocalize;	
						storeLocalize.updateCoions();
					}											
					switch(GameManager.Instance.GetPreviousGameState()){
						case GameManager.GameState.MAINMENU:
						{		
							Debug.Log("Upadating vehicle coins count");
							VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
							vehicleLocalize.updateCoions();
							if(package.Equals(ConstantsNew.PACKAGE_VGP)){
						#if UNITY_IPHONE
								VehicleSelectionMenuListenerNew vehicleMenu = GameObject.Find("Vehicle1").GetComponent<VehicleSelectionMenuListenerNew>() as VehicleSelectionMenuListenerNew;
								vehicleMenu.playHavenIAPTracker(package);
						#endif		
					}
							break;
						}
						case GameManager.GameState.EPISODEMENU:
						{	
							Debug.Log("Upadating episode coins count"); 
							EpisodeMenuLocalize episodeLocalize = GameObject.FindGameObjectWithTag("EpisodeMenu").GetComponent<EpisodeMenuLocalize>() as EpisodeMenuLocalize;	
							episodeLocalize.updateCoions();
							break;
						}
						case GameManager.GameState.VEHICLEUPGRADEMENU:
						{	
							Debug.Log("Upadating upgrade coins count");
							UpgradeMenuLocalize upgradeLocalize = GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>() as UpgradeMenuLocalize;	
							upgradeLocalize.updateCoions();
							break;
						}
						case GameManager.GameState.LEVELSETTINGS:
						{
							Debug.Log("Upadating settings coins count");
							SettingsMenuLocalize settingsLocalize = GameObject.FindGameObjectWithTag("LevelSettings").GetComponent<SettingsMenuLocalize>() as SettingsMenuLocalize;	
							settingsLocalize.updateCoions();
							break;
						}
					}
					Debug.Log("enter in purchase " + "thank you called." );
					Instantiate(Resources.Load("SubMenusNew/LevelThankyou"));
				}
				else{
					switch(GameManager.Instance.GetCurrentGameState()){
					case GameManager.GameState.STORE:
					{
						Debug.Log("enter in purchase " + "store" );
						GameObject.FindGameObjectWithTag("Store").GetComponent<StoreMenuListener>().Unlock(package);
						break;
					}
					case GameManager.GameState.VEHICLESELECTIONMENU:
					{	
						Debug.Log("enter in purchase " + "vehic" );
						GameObject.FindGameObjectWithTag ( "TruckMenuPanel" ).GetComponent < VehicleSelectionDragScript >().UnLockAllVehicles ( ) ; 
						break;
					}
					case GameManager.GameState.EPISODEMENU:
					{	
						Debug.Log("enter in purchase " + "episdoe" );
						GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().UnLockAllEpisodes();
						break;
					}
				}
					Debug.Log("enter in purchase " + "thank you called." );
				//	GameManager.Instance.ChangeState(GameManager.GameState.THANKYOU);
					Instantiate(Resources.Load("SubMenus/LevelThankyou"));
			}				
		}
		
	}
	
	
	public IEnumerator LoadScene(float waitTime){
		
		if(menuType ==2){
			Instantiate(Resources.Load("MenusNew/Loading"));		
		}
		else{
			Instantiate(Resources.Load("Menus/Loading"));	
		}
		
		Debug.Log("current epsiode " + UserPrefs.currentEpisode + "level" + UserPrefs.currentLevel);
		switch(UserPrefs.currentEpisode){
	
			case 1:
				async = Application.LoadLevelAsync(Constants.SCENE_EPISODE1);				
				break;
			case 2:
				async = Application.LoadLevelAsync(Constants.SCENE_EPISODE2);
				break;
			case 3:
				async = Application.LoadLevelAsync(Constants.SCENE_EPISODE3);
				break;
			default:
				break;
		}
		GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLESTARTSOUND,GameManager.GameState.GAMEPLAY);
		yield return async;	
		
	}
		
	
	public void BackButtonHandling(){
		GameObject menuObject;
		menuObject = GameObject.FindGameObjectWithTag("LevelThankyou");
		if(menuObject != null){
			Destroy(menuObject);
			Resources.UnloadUnusedAssets();
		}else{
			switch(GameManager.Instance.GetCurrentGameState())
			{ 
			
				case GameManager.GameState.LEVELSETTINGS:
					menuObject = GameObject.FindGameObjectWithTag("LevelSettings");
					if(menuObject!= null){
						Destroy(menuObject);
						Resources.UnloadUnusedAssets();
					}
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());

					break;
				
				case GameManager.GameState.OUTOFCOINS:
					menuObject = GameObject.FindGameObjectWithTag("LevelOutOfCoins");
					if(menuObject!= null){
						Destroy(menuObject);
						Resources.UnloadUnusedAssets();
						GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());
					}
					break;
				
				case GameManager.GameState.VEHICLESELECTIONMENU:
				Debug.LogError("in VEHICLESELECTIONMENU state");
				if(menuType==2)
				{
					Debug.LogError("in menuType==2");
					Application.Quit();
//					Instantiate(Resources.Load("SubMenus/LevelRewardMenu"));
//					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.REWARDMENU);
				}
				else
				{
					MenuManager.Instance.SwitchPreviousMenu();
				}
//					
				
					break;
				
				case GameManager.GameState.EPISODEMENU:
					MenuManager.Instance.SwitchPreviousMenu();
					break;
				
				case GameManager.GameState.LEVELSELECTIONMENU:
					MenuManager.Instance.SwitchPreviousMenu();
					break;
				case GameManager.GameState.VEHICLEUPGRADEMENU:
					MenuManager.Instance.SwitchPreviousMenu();
					break;
				
				case GameManager.GameState.MAINMENU:
					Debug.LogError("in MAINMENU state");
				if(menuType==2)
				{
					Application.Quit();
					break;
				}
					Instantiate(Resources.Load("SubMenus/LevelRewardMenu"));
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.REWARDMENU);
					break;
					
				case GameManager.GameState.REWARDMENU:
					Destroy(GameObject.FindGameObjectWithTag("RewardMenu"));
					///GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
					Application.Quit();
					break;	
					
				case GameManager.GameState.STORE:
					Destroy(GameObject.FindGameObjectWithTag("StoreMenu"));
					Resources.UnloadUnusedAssets();
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
				if(menuType==1)
				{
					MenuManager.Instance.StartMenu();
				}
//				else if(menuType==2)
//				{
//					GameManager.GameState previousState = GameManager.Instance.GetPreviousGameState();
//				}
				
				
					break;
				
				case GameManager.GameState.GAMEPLAY:
					//Instantiate(Resources.Load("SubMenus/LevelExit"));
					//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELEXIT);
					if(menuType==2)
					{
						GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.PAUSED);
					
					}
				else
				{
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELEXIT);
					
				}
				
					break;
				
				case GameManager.GameState.LEVELEXIT:
					Destroy(GameObject.FindGameObjectWithTag("LevelEnd"));
					Resources.UnloadUnusedAssets();
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
					break;
				
				case GameManager.GameState.THANKYOU:
					Destroy(GameObject.FindGameObjectWithTag("LevelThankyou"));
					Resources.UnloadUnusedAssets();
					GameManager.Instance.ChangeState(GameManager.Instance.GetPreviousGameState());
					break;
				
				case GameManager.GameState.EPISODEUNLOCK:
					Destroy(GameObject.FindGameObjectWithTag("LevelUnlockEpisode"));
					Resources.UnloadUnusedAssets();
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());
					break;
				
				case GameManager.GameState.RATEUS:
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
					break;
				
			case GameManager.GameState.LOCKEDLEVELUNLOCK:
				Destroy(GameObject.FindGameObjectWithTag("LockedLevelSkip"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());
				break;
				
				default:
					break;
			}
		
		}
		
		
	}
	
	public void unlockAllEpisodes(){
		if(!UserPrefs.isAllEpisdoesUnlock){
			
			UserPrefs.isAllEpisdoesUnlock = true;
			
			for(int i = 0; i< UserPrefs.episodeUnlockArray.Length; i++){
				UserPrefs.episodeUnlockArray[i] = true;
			}
			
			UserPrefs.Save();
		}
	}
		public void unlockAllVehicles(){
		if(!UserPrefs.isAllVehiclesUnlock){
			
			UserPrefs.isAllVehiclesUnlock = true;
			
			for(int i = 0; i< UserPrefs.vehicleUnlockArray.Length; i++){
				UserPrefs.vehicleUnlockArray[i] = true;
			}
			
			UserPrefs.Save();
		}
	}
	
}
