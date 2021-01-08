using UnityEngine;
using System.Collections;

public class SubMenusNew   : SingeltonBase<SubMenusNew> {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SwitchMenu(GameManager.GameState currentGameState){
		DestoryPreviousMenu(GameManager.Instance.GetPreviousGameState());
		Debug.Log("switch menu called. "  +  currentGameState);
		switch(currentGameState)
		{
			
			case GameManager.GameState.LEVELCOMPLETE:				
				Instantiate(Resources.Load("SubMenusNew/LevelComplete"));
				//NextLevel();
				GAManager.Instance.LogDesignEvent("PlayArea:LevelSuccess:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.CRASHED:
				Debug.Log("switch menu called. "  +  "level crash" );				
				Instantiate(Resources.Load("SubMenusNew/LevelCrashMenuNew"));
				//Instantiate(Resources.Load("SubMenus/LevelCrash"));
				GAManager.Instance.LogDesignEvent("PlayArea:LevelCrash:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.LEVELSKIP:
				Instantiate(Resources.Load("SubMenusNew/SkipLevelNew"));
				break;
			case GameManager.GameState.OUTOFCOINS:
				Instantiate(Resources.Load("SubMenusNew/LevelOutOfCoins"));
				break;
			case GameManager.GameState.TIMEOVER:				
				Instantiate(Resources.Load("SubMenusNew/LevelOutOfFuel"));
				GAManager.Instance.LogDesignEvent("PlayArea:LevelTimeUp:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.RATEUS:
				Instantiate(Resources.Load("SubMenusNew/LevelRateUs"));
				break;
			case GameManager.GameState.LEVELSETTINGS:
				Instantiate(Resources.Load("SubMenusNew/LevelSettings"));
				break;
//			case GameManager.GameState.LEVELEXIT:
//				//Instantiate(Resources.Load("SubMenus/LevelExit"));
//				Resources.UnloadUnusedAssets();
//				Application.LoadLevel("MenusScene");
//				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
//				break;
			case GameManager.GameState.THANKYOU:
				// detory out of coins you menu
				Instantiate(Resources.Load("SubMenusNew/LevelThankyou"));
				break;
			
			case GameManager.GameState.EPISODEUNLOCK:
				Instantiate(Resources.Load("SubMenusNew/UnlockLevelMenuNew"));
				break;
			case GameManager.GameState.VEHICLEUNLOCK:
				Instantiate(Resources.Load("SubMenusNew/UnlockVehicleMenuNew"));
				break;

			
			case GameManager.GameState.STORE:
				Debug.Log("GameManager.GameState.STORE"+GameManager.GameState.STORE);
				Instantiate(Resources.Load("MenusNew/StoreMenu"));
				GAManager.Instance.LogDesignEvent("Store:Open");
				break;
			case GameManager.GameState.GAMEPLAY:
				GameObject background = GameObject.FindGameObjectWithTag("SubMenuBackground");
				if(background!= null){
					background.GetComponent<UITexture>().enabled = false;
					background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, 1);
				}
				break;
			case GameManager.GameState.UNLOCKALLLEVELS:
			    Instantiate(Resources.Load("SubMenusNew/UnlockAllLevels"));
			    break;
			case GameManager.GameState.LOCKEDLEVELUNLOCK:
			    Instantiate(Resources.Load("SubMenusNew/LockedLevelSkip"));
			    break;
			case GameManager.GameState.PAUSED:
				Instantiate(Resources.Load("SubMenusNew/PauseMenuNew"));
				break;
			case GameManager.GameState.PICKPASSENGERINSTRUCTIONS:
				Instantiate(Resources.Load("SubMenusNew/LevelInstructions"));
				break;
			case GameManager.GameState.DROPPASSENGERINSTRUCTIONS:
				Instantiate(Resources.Load("SubMenusNew/LevelInstructions"));
				break;
			
			
			case GameManager.GameState.OUTOFCOINSBRAKESUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeBreaksNew"));
				break;
			
			case GameManager.GameState.OUTOFCOINSENGINEUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeEngineNew"));
				break;
			
			case GameManager.GameState.OUTOFCOINSSTEERINGUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeSteeringNew"));
				break;
			
			case GameManager.GameState.OUTOFCOINSTYRESUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeTyresNew"));
				break;
			case GameManager.GameState.CONFIRMBRAKESUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeBreaksNew"));
				break;
			
			case GameManager.GameState.CONFIRMENGINEUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeEngineNew"));
				break;
			
			case GameManager.GameState.CONFIRMSTEERINGUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeSteeringNew"));
				break;
			
			case GameManager.GameState.CONFIRMTYRESUPGRADE:
				Instantiate(Resources.Load("SubMenusNew/UpgradeTyresNew"));
				break;
			default:
				break;
				
		}

	}
	public void DestoryPreviousMenu(GameManager.GameState previousGameState){
		Debug.Log("switch menu called. "  +  previousGameState);
		GameObject temp;

		switch(previousGameState)
		{   
			case GameManager.GameState.LEVELCOMPLETE:
				temp = GameObject.FindGameObjectWithTag("LevelComplete");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.CRASHED:
				temp = GameObject.FindGameObjectWithTag("LevelCrash");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.LEVELSKIP:
				temp = GameObject.FindGameObjectWithTag("LevelSkip");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.OUTOFCOINS:
				temp = GameObject.FindGameObjectWithTag("LevelOutOfCoins");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.TIMEOVER:
				temp = GameObject.FindGameObjectWithTag("LevelOutOfFuel");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.RATEUS:
				temp = GameObject.FindGameObjectWithTag("RateUs");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.LEVELSETTINGS:
				temp = GameObject.FindGameObjectWithTag("LevelSettings");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.LEVELEXIT:
				temp = GameObject.FindGameObjectWithTag("LevelExit");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.THANKYOU:
				temp = GameObject.FindGameObjectWithTag("LevelThankyou");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.EPISODEUNLOCK:
				temp = GameObject.FindGameObjectWithTag("unlockLevelMenu");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.VEHICLEUNLOCK:
				temp = GameObject.FindGameObjectWithTag("unlockVehicleMenu");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.STORE:
				temp = GameObject.FindGameObjectWithTag("StoreMenu");
				if(temp != null)
					Destroy(temp);
				break;
			case GameManager.GameState.UNLOCKALLLEVELS:
			    temp = GameObject.FindGameObjectWithTag("UnlockAllLevels");
			    Destroy(temp);
			    break;
			case GameManager.GameState.LOCKEDLEVELUNLOCK:
			    temp = GameObject.FindGameObjectWithTag("LockedLevelSkip");
			    Destroy(temp);
			    break;
			case GameManager.GameState.OUTOFCOINSENGINEUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeEngineNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.CONFIRMENGINEUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeEngineNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.OUTOFCOINSBRAKESUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeBreaksNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.CONFIRMBRAKESUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeBreaksNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.OUTOFCOINSTYRESUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeTyresNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.CONFIRMTYRESUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeTyresNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.OUTOFCOINSSTEERINGUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeSteeringNewSubMenu");
			    Destroy(temp);
			    break;
			case GameManager.GameState.CONFIRMSTEERINGUPGRADE:
			    temp = GameObject.FindGameObjectWithTag("UpgradeSteeringNewSubMenu");
			    Destroy(temp);
			    break;
			default:
				break;
				
		}
		
			
	
	}
	public void EnableBackground(){
		GameObject background = GameObject.FindGameObjectWithTag("SubMenuBackground");
		if(background != null){
			background.GetComponent<UITexture>().enabled = true;
			background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, 0);
		}
	}
	void NextLevel(){
		// called in start.
	//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
	//	UserPrefs.Save();
		
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){   // 12 >= 12
			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length){
				//Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
				UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
				UserPrefs.Save();
			}else{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
				Application.LoadLevel(Constants.SCENE_MENU);                     
			}
		}
		else{
			UserPrefs.currentLevel++;
			
			//UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelComplete"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}
		}
	}
	
}
