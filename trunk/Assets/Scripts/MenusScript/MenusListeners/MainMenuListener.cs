using UnityEngine;
using System.Collections;

public class MainMenuListener : MonoBehaviour {
	
	GameObject btnLeaderboard;
	GameObject btnAchievemnt;
	GameObject btnGooglePlay;
	private static bool isDisable = false;
	UILabel moregameIndex;

	void Start () {
			btnLeaderboard = GameObject.FindGameObjectWithTag("Leaderboard");
			btnAchievemnt = GameObject.FindGameObjectWithTag("Achievement");
			//btnGooglePlay = GameObject.FindGameObjectWithTag("GooglePlay");
			btnGooglePlay = GameObject.Find("btnGooglePlay");
			if(this.gameObject.name == "lblMoreGameIndex")
			{
			this.gameObject.GetComponent<UILabel>().text = Mathf.Floor(Random.Range(1,6)).ToString();
		}
		#if UNITY_IPHONE	
		if(this.gameObject.name == "btnGooglePlay"){
			this.gameObject.SetActive(false);
		}

		
		#endif
		
		#if UNITY_ANDROID
		
		if(this.gameObject.name.Equals("btnPlay")){
			
			Debug.Log("-------------  :: " + UserPrefs.isGoogleSignedIn);
			if(UserPrefs.isGoogleSignedIn){
				btnAchievemnt.SetActive(true);
				btnLeaderboard.SetActive(true);
				btnGooglePlay.SetActive(false);
			}
			else
			{
				btnAchievemnt.SetActive(false);
				btnLeaderboard.SetActive(false);
				btnGooglePlay.SetActive(true);
			}
		}
		else if(this.name.Equals("btnRestore"))
		{
			if(UserPrefs.isAmazonBuild){
				this.gameObject.SetActive(false);
			}
		}
		
		#endif
			
	}

	void Update () {
#if UNITY_ANDROID
		if(!UserPrefs.isAmazonBuild && UserPrefs.isGoogleSignedIn && !isDisable)
		{
			DisableSignInButton();
			isDisable = true;
		}
#endif
	/*	#if UNITY_ANDROID
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{	
				GameObject settingMenuObject = GameObject.FindGameObjectWithTag("LevelSettings");
				if(settingMenuObject!= null){
					Destroy(settingMenuObject);
					Resources.UnloadUnusedAssets();
				} else {
					Application.Quit(); 
				}
			}
			
		#endif
		
		*/
	}
	
	void OnClick(){
		Debug.Log(this);
		if(this.name.Equals("btnPlay"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Play");
			MenuManager.Instance.SwitchNextMenu();
		}
		else if(this.name.Equals("btnMoreGames"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:MoreGames");
			MoreGames();			
		}
		else if(this.name.Equals("btnSettings"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Settings");
			ShowSettingMenu();
		}
		else if(this.name.Equals("btnFacebook"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Facebook");
			ShowFacebook();
		}
		else if(this.name.Equals("btnTwitter"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Twitter");
			ShowTwitter();
		}
		else if(this.name.Equals("btnAchievement"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Achievements");			
			GameManager.Instance.ShowAchievements();
		}
		else if(this.name.Equals("btnLeaderboard"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:LeaderBoard");
			GameManager.Instance.ShowLeaderBoard();
		}
		else if(this.name.Equals("btnGooglePlay"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Glogin");
#if UNITY_ANDROID
			UserPrefs.googleGameCenter = new GoogleGameCenter();
			UserPrefs.googleGameCenter.Initialize();
#endif
			GameManager.Instance.GoogleSignIn();
		}
		else if(this.name.Equals("btnRestore"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Restore");
			GameManager.Instance.Restore();
		}
	
	}
	
	
	
	public void ShowFacebook(){
		UserPrefs.isFbFan = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(Constants.FACEBOOK_LINK);	
	}
	
	
	public void ShowTwitter(){
		UserPrefs.isTwitterAnnouncer = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(Constants.TWITTER_LINK);	
	}
	
	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
			
		
	}
	public void MoreGames()
	{
		if(UserPrefs.isAmazonBuild){
			Application.OpenURL("amzn://apps/android?s=com.tapinator");	
		} else {
			AdsManager.Instance.PlayHavenOnMoreGames();
		}
	}
	public void DisableSignInButton()
	{
		if(UserPrefs.isGoogleSignedIn){
				btnAchievemnt.SetActive(true);
				btnLeaderboard.SetActive(true);
				btnGooglePlay.SetActive(false);
			}
	}
	
}
	
		
		