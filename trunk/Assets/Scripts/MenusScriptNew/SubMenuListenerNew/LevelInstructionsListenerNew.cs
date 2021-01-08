using UnityEngine;
using System.Collections;

public class LevelInstructionsListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void OnClick(){
		if(this.name.Equals("btnContinue")){
			Debug.Log("btnContinue Pressed");
			
			Destroy(GameObject.FindGameObjectWithTag("levelInstructions"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
			if(!UserPrefs.isTutorialStart && UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1){
				UserPrefs.isTutorialStart = true;
				TutorialManager.Instance.startTutorial();
			} else if(!UserPrefs.isTutorialStart && UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 2){
				UserPrefs.isTutorialStart = true;
				UserPrefs.TutorialStep = 7;
			}

		}
		
	}
	
	
}
