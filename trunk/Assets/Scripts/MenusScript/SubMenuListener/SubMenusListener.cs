
// This script listens different pop ups buttons. 

using UnityEngine;
using System.Collections;

public class SubMenusListener : MonoBehaviour {

	
	void Start () {
		
	}

	void Update () {
	
	}
	
	void OnClick(){
		
		if(this.name.Equals("btnHome"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			Application.LoadLevel("MenusScene");
		}
		else if(this.name.Equals("btnRestart"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			Application.LoadLevel("MenusScene");

		}
		else if (this.name.Equals("btnSkip"))
		{
			ShowSkipMenu();
		}
		else if (this.name.Equals("btnLevelSkipCancel"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if (this.name.Equals("btnLevelSkipSkip"))
		{
			SkipLevel();
		}
		else if(this.name.Equals("btnLevelEndCancel"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelEnd"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if (this.name.Equals("btnLevelEndOk"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelEnd"));
			Application.LoadLevel("MenusScene");
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
		}
		else if (this.name.Equals("btnLevelThankyouOk"))
		{
			Destroy(GameObject.FindGameObjectWithTag("btnLevelThankyouOk"));
		//	GameManager.Instance.ChangeState(GameManager.GameState.g);
		}
		else if (this.name.Equals("btnSkipOk"))
		{
	
		}
		else if (this.name.Equals("btnFuel25"))
		{
			purchaseFuel(25);
		}
		else if (this.name.Equals("btnFuel50"))
		{
			purchaseFuel(50);
		}
		else if (this.name.Equals("btnFuel75"))
		{
			purchaseFuel(75);	
		}
		else if ( this.gameObject.name.Equals ( "btnNext" ) )
		{
			NextLevel();
		}
		else if(this.gameObject.name.Equals("btnStore"))
		{
			ShowStoreMenu();
		}
		else if(this.gameObject.name.Equals("btnRateUs"))
		{
			
		}
		else if(this.gameObject.name.Equals("btnRateUsMenuSkip"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if(this.gameObject.name.Equals("btnLevelUnlockEpisodeOk"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
			Application.LoadLevel(Constants.SCENE_MENU);  
		}
	}
	
	
	void NextLevel(){
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
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			Application.LoadLevel(Constants.SCENE_MENU); 
		}
	}
	
	void SkipLevel(){
		if(UserPrefs.totalCoins>= Constants.COINSTOSKIPLEVEL){
		//	UserPrefs.totalCoins -= Constants.COINSTOSKIPLEVEL;
			GameManager.Instance.SubtractCoins(Constants.COINSTOSKIPLEVEL);
			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
				if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length  &&  !UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] ){
				//	Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
					UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
					UserPrefs.Save();
				}else{
					GameManager.Instance.ChangeState(GameManager.GameState.EPISODEMENU);
					Application.LoadLevel(Constants.SCENE_MENU); 
				}
			}else{
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
				UserPrefs.Save();
				NextLevel();
			}
		}
		else
		{
			//Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
			//Instantiate(Resources.Load("SubMenus/LevelOutofCandies"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
		}
		UserPrefs.Save();
		
		
	}
	
	
	void ShowSkipMenu(){
		
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
			// next episode will unlock
			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length  &&  !UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] ){
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSKIP);
				//Instantiate(Resources.Load("SubMenus/LevelSkip"));
			}else{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
				Application.LoadLevel(Constants.SCENE_MENU);                     
			}
		}
		else 	
		{
			if( UserPrefs.currentLevel+1 <=   UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]         )  // checking whether next level is unlock or not
				NextLevel();
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
				if(UserPrefs.totalCoins >= Constants.COINSTOSKIPLEVEL)
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSKIP);
				else
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
			}
		}
			
	}
	
	void ShowStoreMenu(){
		Destroy(GameObject.FindGameObjectWithTag("LevelOutOfCoins"));
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
	
	}
	
	public void purchaseFuel(int price){		
		if(UserPrefs.totalCoins > price)
		{			
			//UserPrefs.totalCoins -= price;
			GameManager.Instance.SubtractCoins(price);
			UserPrefs.Save();
			Destroy(GameObject.FindGameObjectWithTag("LevelOutOfFuel"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
		}
		else
		{
		//	Instantiate(Resources.Load("SubMenus/LevelOutofCandies"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
		}
	}
	
}
