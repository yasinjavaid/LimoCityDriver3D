using UnityEngine;
using System.Collections;

public class LevelCrashListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnHome")){
			SubMenusOld.Instance.EnableBackground();
			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
			
				GameObject.Find("btnSkip").SetActive(false);
				GameObject home = GameObject.Find("btnHome");
				home.transform.localPosition = new Vector3(-95f, home.transform.localPosition.y, home.transform.localPosition.z);
				GameObject skip = GameObject.Find("btnRestart");
				Debug.Log("---------------skip called. ");
				skip.transform.localPosition = new Vector3(110, skip.transform.localPosition.y, skip.transform.localPosition.z);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
/*	
		#if UNITY_ANDROID
	
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{	
				Debug.Log("escaped clicked. ");
				GameObject temp = GameObject.FindGameObjectWithTag("LevelCrash");
				if(temp != null)
					Destroy(temp);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			}
	
		#endif
		
		*/
	}
	
	void OnClick(){
		if(this.name.Equals("btnHome"))
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
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}

		}
		else if (this.name.Equals("btnSkip"))
		{
			ShowSkipMenu();
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
		//UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
		//UserPrefs.Save();
		
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
				Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}
		}
	}
}
