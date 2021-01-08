using UnityEngine;
using System.Collections;

public class SettingsMenuListenerNew : MonoBehaviour {
	
	
	GameObject btnSound;
	GameObject btnMusic;
	
	// Use this for initialization
	void Start () {
		btnSound  =	GameObject.FindGameObjectWithTag("btnSoundSlider");
		btnMusic  =	GameObject.FindGameObjectWithTag("btnMusicSlider");

		if(!UserPrefs.isSound)
		{
			Debug.LogError("Setting off");
			btnSound.GetComponentInChildren<UISprite>().spriteName = "slider-btn-off" ;
				
		}
		else{
			btnSound.GetComponentInChildren<UISprite>().spriteName = "slider-btn-ON" ;
		}
		
		
		if(!UserPrefs.isMusic)
		{
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-off" ;
				
		}
		else
		{
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-ON" ;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	void OnClick(){
		if(this.name.Equals("backBtn")){
			Debug.Log("backBtn Pressed");
			//Resources.UnloadUnusedAssets();
			Destroy(GameObject.FindGameObjectWithTag("LevelSettings"));
			if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.MAINMENU) { 
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		   }else{
		   		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			}
			
		}
		
		if(this.name.Equals("btnEmail")){
			Debug.Log("btnEmail Pressed");
			GAManager.Instance.LogDesignEvent("SettingsMenu:Email");
			ShowEmail();
			
		}
		
		if(this.name.Equals("btnFacebook")){
			Debug.Log("btnFacebook Pressed");
			GAManager.Instance.LogDesignEvent("SettingsMenu:Facebook");
			ShowFacebook();
		}
		
		if(this.name.Equals("btnTwitter")){
			Debug.Log("btnTwitter Pressed");
			GAManager.Instance.LogDesignEvent("SettingsMenu:Twitter");
			ShowTwitter();			
		}
		
		if(this.name.Equals("btnMusicSlider")){
			Debug.Log("btnMusicSlider Pressed");
			
			//Uncomment during final integration
			SetMusic();
			
		}
		
		if(this.name.Equals("btnSoundSlider")){
			Debug.Log("btnSoundSlider Pressed");
			//Uncomment during final integration
			SetSound();
		}	
		
		if(this.name.Equals("btnCoinsUpLeft")){
			Debug.Log("btnCoinsUpLeft");
			GameManager.GameState previousState=GameManager.Instance.GetPreviousGameState();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
			GameManager.Instance.SetPreviousGameState(previousState);
		}	
		
	}
	public void Close(){
		
		Destroy(GameObject.FindGameObjectWithTag("SettingsMenuNew"));
		Resources.UnloadUnusedAssets();
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState()); 
		Debug.Log("current state is " +GameManager.Instance.GetCurrentGameState());
	}
	
	public void SetSound(){
		if(UserPrefs.isSound)
		{
			UserPrefs.isSound = false;
			this.GetComponentInChildren<UISprite>().spriteName = "slider-btn-off" ;
			GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
		}
		else
		{
			UserPrefs.isSound = true;
			this.GetComponentInChildren<UISprite>().spriteName = "slider-btn-ON" ;
			GameManager.Instance.ChangeState(GameManager.SoundState.UNMUTESOUND);
		}
		UserPrefs.Save();
		
	}
	
	public void SetMusic(){
		if(UserPrefs.isMusic)
		{

			UserPrefs.isMusic = false;
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-off" ;
			//GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);	
		}
		else
		{
			UserPrefs.isMusic = true;
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-ON" ;
			//GameManager.Instance.ChangeState(GameManager.SoundState.UNMUTESOUND);
		}
		UserPrefs.Save();
		BackgroundSoundManager.Instance.playOrStopMusic();
	}
	
	public void ShowFacebook(){
		UserPrefs.isFbFan = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(ConstantsNew.FACEBOOK_LINK);	
	}
	
	public void ShowTwitter(){
		UserPrefs.isTwitterAnnouncer = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(ConstantsNew.TWITTER_LINK);	
	}
	public void ShowEmail(){
	
		Application.OpenURL(ConstantsNew.EmailID+"?subject="+ConstantsNew.EmailSubject+"+&body="+ConstantsNew.EmailBody);
		
	}
	

	
}
