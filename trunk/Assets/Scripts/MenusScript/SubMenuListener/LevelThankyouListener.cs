using UnityEngine;
using System.Collections;

public class LevelThankyouListener : MonoBehaviour {

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
		 if (this.name.Equals("btnOk"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelThankyou"));
			Resources.UnloadUnusedAssets();
		//	GameManager.Instance.ChangeState(GameManager.Instance.GetPreviousGameState());
		}	
	}
}
