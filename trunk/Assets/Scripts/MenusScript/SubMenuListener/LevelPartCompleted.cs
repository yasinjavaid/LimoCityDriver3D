using UnityEngine;
using System.Collections;

public class LevelPartCompleted : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnOk")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
//		 if(this.name.Equals("btnCancel"))
//		{
//			Destroy(GameObject.FindGameObjectWithTag("LevelExit"));
//			Resources.UnloadUnusedAssets();
//			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
//		}
//		else
		if (this.name.Equals("btnOk"))
		{
			Destroy(GameObject.FindGameObjectWithTag("ParkingAchieved"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}	
	}
}
