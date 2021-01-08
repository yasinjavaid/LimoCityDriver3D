using UnityEngine;
using System.Collections;

public class LevelExitListener : MonoBehaviour {

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
		 if(this.name.Equals("btnCancel"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelExit"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if (this.name.Equals("btnOk"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelExit"));
			Resources.UnloadUnusedAssets();
			Application.LoadLevel("MenusScene");
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
		}	
	}
}
