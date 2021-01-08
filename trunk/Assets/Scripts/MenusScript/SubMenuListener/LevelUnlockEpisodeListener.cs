using UnityEngine;
using System.Collections;

public class LevelUnlockEpisodeListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		
		if(this.gameObject.name.Equals("btnOK")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		Debug.Log(this);
		 if(this.gameObject.name.Equals("btnOK"))
		{Debug.Log(this +  "cccee " );
		//	GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
		//	Application.LoadLevel(Constants.SCENE_MENU); 
			Destroy(GameObject.FindGameObjectWithTag("LevelUnlockEpisode"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());
		}	
	}
}
