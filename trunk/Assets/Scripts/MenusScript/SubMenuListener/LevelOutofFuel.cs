using UnityEngine;
using System.Collections;

public class LevelOutofFuel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		
		if(this.gameObject.name.Equals("btnHome")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		
		if (this.name.Equals("btnFuel25"))
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
		else if(this.name.Equals("btnHome"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			Application.LoadLevel("MenusScene");
		}
		else if(this.name.Equals("btnRestart"))
		{
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}

		}
		else if (this.name.Equals("btnSkip"))
		{
			ShowSkipMenu();
		}
	}
	
	public void purchaseFuel(int price){		
		if(UserPrefs.totalCoins > price)
		{			
			GAManager.Instance.LogDesignEvent("CoinCons:LevelTimeUp:Boost:tb"+price+":Lvl#"+UserPrefs.currentLevel);
			
		//	UserPrefs.totalCoins -= price;
			GameManager.Instance.SubtractCoins(price);
			GameManager.Instance.AddTime((Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1]*price)/100.0f);
			GameManager.Instance.ShowTime(price);
			UserPrefs.Save();
			Destroy(GameObject.FindGameObjectWithTag("LevelOutOfFuel"));
		//	Destroy(GameObject.FindGameObjectWithTag("Hud"));
		//	Resources.UnloadUnusedAssets();
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
		//	StartCoroutine(MenuManager.Instance.LoadScene(0));
		}
		else
		{
		//	Instantiate(Resources.Load("SubMenus/LevelOutofCandies"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
		}
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
				Resources.UnloadUnusedAssets();
				if(UserPrefs.totalCoins >= Constants.COINSTOSKIPLEVEL)
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSKIP);
				else
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
			}
		}
			
	}
	void NextLevel(){
	//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
	//	UserPrefs.Save();
		if( UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] == UserPrefs.currentLevel){
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
		}
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

