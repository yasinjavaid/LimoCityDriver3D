using UnityEngine;
using System.Collections;

public class LevelCompleteListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	Debug.Log("escaped clicked.intialize ");
		
		if(this.gameObject.name.Equals("btnHome")){
		
			if( UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] == UserPrefs.currentLevel){
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
			}
			
			UserPrefs.Save();
			SubMenusOld.Instance.EnableBackground();
			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
			//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] = Constants.levelsPerEpisode;
				GameObject.Find("btnNext").SetActive(false);
				//GameObject home = GameObject.Find("btnHome");
				this.transform.localPosition = new Vector3(-95f, this.transform.localPosition.y, this.transform.localPosition.z);
				GameObject skip = GameObject.Find("btnRetry");
				Debug.Log("---------------skip called. ");
				skip.transform.localPosition = new Vector3(110, skip.transform.localPosition.y, skip.transform.localPosition.z);
			}
		}
			
		
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void OnClick(){
		if(this.name.Equals("btnHome"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelComplete"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			Application.LoadLevel(Constants.SCENE_MENU);
		}
		else if(this.name.Equals("btnRetry"))
		{
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
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
				StartCoroutine(MenuManager.Instance.LoadScene(1));
			}

		}else if ( this.gameObject.name.Equals ( "btnNext" ) )
		{
			NextLevel();
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
