using UnityEngine;
using System.Collections;

public class LevelSelectionMenuListener : MonoBehaviour {
	public GameObject lockedSprite;
//	GameObject label;

	void Start () {
		
		if( !this.gameObject.name.Equals("btnBack") &&  !this.gameObject.name.Equals("btnStore" ) && !this.gameObject.name.Equals("btnUnlockAllLevels")){
		//	label = this.GetComponentInChildren<UILabel>().gameObject;
			CheckLevelStatus();
		}
		else if (this.gameObject.name.Equals("btnStore")){
			GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>().text = UserPrefs.totalCoins.ToString();	
			
		}
		else if(this.gameObject.name.Equals("btnUnlockAllLevels")){
			if(UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] >= 12){
				this.gameObject.SetActive(false);
			}
		}
		
	}

	void Update () {
	
	}
	
	void OnClick(){
		
		if(this.gameObject.name.Equals("btnBack"))
		{
			MenuManager.Instance.SwitchPreviousMenu();
		}
		else if(name.Equals("btnStore"))
		{

			GAManager.Instance.LogDesignEvent("Levels:CoinsStore");
			Destroy(GameObject.FindGameObjectWithTag("LevelSelectionMenu"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
			//MenuManager.Instance.OpenStore();
			
		}
		else if(this.gameObject.name.Equals("btnUnlockAllLevels")){
			UnlockAllLevel();			
		}
		else 
		{
			// else clicked on level button
			
			UserPrefs.currentLevel = int.Parse(this.name) ;
			if(UserPrefs.currentLevel <= UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]){
				GAManager.Instance.LogDesignEvent("Levels:EP"+UserPrefs.currentEpisode+":Lvl#"+UserPrefs.currentLevel);
				MenuManager.Instance.SwitchNextMenu();
			} else {
				UnlockCurrentLevel();
			}
		}
	}
	
	
	void CheckLevelStatus(){
	//	if(	UserPrefs.episodeLevelUnlockArray[UserPrefs.currentEpisode-1 ,(int.Parse(this.name)-1)]){
		if(UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]   >=  int.Parse(this.name)     ){
			this.GetComponent<BoxCollider>().enabled = true;
		//	label.SetActive(true);
			lockedSprite.SetActive(false);
		}if((UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] + 1)  >=  int.Parse(this.name)     ){
			this.GetComponent<BoxCollider>().enabled = true;
//			label.SetActive(true);
//			lockedSprite.SetActive(false);
		} else{
		//	label.SetActive(false);
		}
	
	}
	
	void UnlockAllLevel(){
		if(UserPrefs.totalCoins >= 499){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.UNLOCKALLLEVELS);			
		} else {
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.OUTOFCOINS);
		}
	}
	
	void UnlockCurrentLevel(){
		if(UserPrefs.totalCoins >= 50){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOCKEDLEVELUNLOCK);			
		} else {
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.OUTOFCOINS);
		}
	}
	

}
