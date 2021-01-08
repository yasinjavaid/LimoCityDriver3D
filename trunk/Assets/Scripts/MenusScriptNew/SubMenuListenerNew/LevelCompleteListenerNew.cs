using UnityEngine;
using System.Collections;

public class LevelCompleteListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void OnClick(){
		if(this.name.Equals("btnContinue")){
			Debug.Log("btnContinue Pressed");
			NextLevel();
		}
		
	}
	
	void NextLevel(){
		// called in start.
	//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
	//	UserPrefs.Save();
		
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){   // 12 >= 12
//			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length){
//				//Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
//				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
//				UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
//				UserPrefs.Save();
//			}else{
				Destroy(GameObject.FindGameObjectWithTag("LevelComplete"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);

			Application.LoadLevel("MenusScene");                   
//			}
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
//				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
//				StartCoroutine(MenuManager.Instance.LoadScene(0));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
		}
	}
}
