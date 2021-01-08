using UnityEngine;
using System.Collections;

public class LevelRewardMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick ( )
	{
		Debug.Log(this);
		if ( this.gameObject.name.Equals ("btnOk") ){
			Destroy(GameObject.FindGameObjectWithTag("RewardMenu"));
		//	GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
			Application.Quit();
		}
	
			
	}
}

