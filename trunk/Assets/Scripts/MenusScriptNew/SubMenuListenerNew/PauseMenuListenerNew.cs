using UnityEngine;
using System.Collections;

public class PauseMenuListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnExit")){
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
//			MenuManager.Instance.StartNewMenus();
			Application.LoadLevel("MenusScene");
		}
		
		if(this.name.Equals("btnRestart")){
			
			//Uncomment during final integration
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("levelPause"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
				StartCoroutine(MenuManager.Instance.LoadScene(1));
			}
			
		}
			
		if(this.name.Equals("btnResume")){
			Debug.Log("btnResume Pressed");
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			//Uncomment during final integration
						
		}
	}
}
