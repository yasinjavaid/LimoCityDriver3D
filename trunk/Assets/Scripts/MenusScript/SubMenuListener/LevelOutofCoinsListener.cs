using UnityEngine;
using System.Collections;

public class LevelOutofCoinsListener : MonoBehaviour {

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
		
		if(this.name.Equals("btnHome"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			Application.LoadLevel("MenusScene");
		}
		else if(this.gameObject.name.Equals("btnStore"))
		{
			
			if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.CRASHED){
				GAManager.Instance.LogDesignEvent("PlayArea:LevelCrash:Store");
				Destroy(GameObject.FindGameObjectWithTag("LevelOutOfCoins"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.CRASHED);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			else if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.TIMEOVER){
				GAManager.Instance.LogDesignEvent("PlayArea:LevelTimeUp:Store");
				Destroy(GameObject.FindGameObjectWithTag("LevelOutOfCoins"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.TIMEOVER);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			else if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.VEHICLESELECTIONMENU){
				Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.VEHICLESELECTIONMENU);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			else if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.EPISODEMENU){
				Destroy(GameObject.FindGameObjectWithTag("EpisodeMenu"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEMENU);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			else if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.LEVELSELECTIONMENU){
				Destroy(GameObject.FindGameObjectWithTag("LevelSelectionMenu"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSELECTIONMENU);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelOutOfCoins"));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			}
			
		}
		
	}
	
}
