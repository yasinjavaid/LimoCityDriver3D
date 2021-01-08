using UnityEngine;
using System.Collections;

public class LevelSkipListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if(this.gameObject.name.Equals("btnCancel")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnClick(){
		 if (this.name.Equals("btnCancel"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if (this.name.Equals("btnSkip"))
		{
			SkipLevel();
		}	
		
	}
	
	void SkipLevel(){
		if(UserPrefs.totalCoins>= Constants.COINSTOSKIPLEVEL){
			UserPrefs.totalCoins -= Constants.COINSTOSKIPLEVEL;
			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
				if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length  &&  !UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] ){
				//	Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
					UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
					UserPrefs.Save();
				}else{
					GameManager.Instance.ChangeState(GameManager.GameState.EPISODEMENU);
					Application.LoadLevel("MenusScene");
				}
			}else{
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
				Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			};
		}
	}
}
