using UnityEngine;
using System.Collections;

public class LevelCrashMenuLintenerNew : MonoBehaviour {
	GameObject btnContinue;
	// Use this for initialization  btnContinueOnCrash
	void Start () {
		btnContinue  =	GameObject.FindGameObjectWithTag("btnContinueOnCrash");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnContinue")){
			Debug.Log("btnContinue Pressed");
			
			Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
			Application.LoadLevel(Constants.SCENE_MENU);
			//MenuManager.Instance.StartNewMenus();
			//Uncomment during final integration
			
			
		}
	}
}
