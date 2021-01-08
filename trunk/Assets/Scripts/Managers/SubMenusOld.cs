using UnityEngine;
using System.Collections;

public class SubMenusOld   : SingeltonBase<SubMenusOld> {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SwitchMenu(GameManager.GameState currentGameState){
		Debug.Log("switch menu called. ");
		DestoryPreviousMenu(GameManager.Instance.GetPreviousGameState());
		Debug.Log("switch menu called. "  +  currentGameState);
		switch(currentGameState)
		{
			
			case GameManager.GameState.LEVELCOMPLETE:				
				Instantiate(Resources.Load("SubMenus/LevelComplete"));
				GAManager.Instance.LogDesignEvent("PlayArea:LevelSuccess:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.CRASHED:
				Debug.Log("switch menu called. "  +  "level crash" );				
				Instantiate(Resources.Load("SubMenus/LevelCrash"));
				GAManager.Instance.LogDesignEvent("PlayArea:LevelCrash:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.LEVELSKIP:
				Instantiate(Resources.Load("SubMenus/LevelSkip"));
				break;
			case GameManager.GameState.OUTOFCOINS:
				Instantiate(Resources.Load("SubMenus/LevelOutOfCoins"));
				break;
			case GameManager.GameState.TIMEOVER:				
				Instantiate(Resources.Load("SubMenus/LevelOutOfFuel"));
				GAManager.Instance.LogDesignEvent("PlayArea:LevelTimeUp:Lvl#"+UserPrefs.currentLevel);
				break;
			case GameManager.GameState.RATEUS:
				Instantiate(Resources.Load("SubMenus/LevelRateUs"));
				break;
			case GameManager.GameState.LEVELSETTINGS:
				Instantiate(Resources.Load("SubMenus/LevelSettings"));
				break;
			case GameManager.GameState.LEVELEXIT:
				Instantiate(Resources.Load("SubMenus/LevelExit"));
				break;
			case GameManager.GameState.THANKYOU:
				// detory out of coins you menu
				Instantiate(Resources.Load("SubMenus/LevelThankyou"));
				break;
			
			case GameManager.GameState.EPISODEUNLOCK:
				Instantiate(Resources.Load("SubMenus/LevelUnlockEpisode"));
				break;
			
			case GameManager.GameState.STORE:
				Instantiate(Resources.Load("Menus/StoreMenu"));
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
			    Instantiate(Resources.Load("SubMenus/UnlockAllLevels"));
			    break;
			case GameManager.GameState.LOCKEDLEVELUNLOCK:
			    Instantiate(Resources.Load("SubMenus/LockedLevelSkip"));
			    break;
			case GameManager.GameState.PAUSED:
				Instantiate(Resources.Load("SubMenus/ParkingAchieved"));
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
				temp = GameObject.FindGameObjectWithTag("LevelUnlockEpisode");
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
	
}
