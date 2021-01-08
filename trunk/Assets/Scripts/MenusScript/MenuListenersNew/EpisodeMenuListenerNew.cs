using UnityEngine;
using System.Collections;

public class EpisodeMenuListenerNew : MonoBehaviour {
	

	public UIPanel secondEpisodeSpotsPanel;
	public UIPanel thirdEpisodeSpotsPanel;
	public UIPanel secondEpisodeCoinsPanel;
	public UIPanel thirdEpisodeCoinsPanel;
	
	// Use this for initialization
	void Start () {
		updateCoins();
		Debug.Log("-------------------- " + UserPrefs.isAllEpisdoesUnlock );
		if(this.gameObject.name.Equals("btnBack")){
			if(UserPrefs.isAllEpisdoesUnlock){
				GameObject episodeUnlockButton = GameObject.FindGameObjectWithTag("UnlockAllEpisodes");
				if(episodeUnlockButton != null)
				{Debug.Log("-------------------- " );
					episodeUnlockButton.SetActive(false);
				}
			}	
		}
		if(this.gameObject.name.Equals("Episode1"))
		{
			setepiosdeCoinsPanel();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick ( )
	{
		if ( this.gameObject.name.Equals ("settingsBtn") )
		{
			Debug.Log("settingsBtn" );
			GAManager.Instance.LogDesignEvent("MainMenu:Settings");
			ShowSettingMenu();

		}
		else if(this.gameObject.name.Equals("getCoins"))
		{
			// Get Coins Button
			Debug.Log("getCoins" );
			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);

		}
		else if(name.Equals("nextBtn"))
		{
			// Next called
			Debug.Log("nextBtn" );
//			MenuManager.Instance.SwitchNextMenu();

			
//			PreviewLabs.PlayerPrefs.DeleteAll();
//			PlayerPrefs.DeleteAll();
//		
//			PreviewLabs.PlayerPrefs.Flush();
			unlockLevelorSwitchToUgrade();
		}
		if (this.name.Equals("Episode1"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite1();
		}
		else if (this.name.Equals("Episode2"))
		{
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite2();	
		}
		else if (this.name.Equals("Episode3"))
		{
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite3();	
		}
		else if (this.name.Equals("Episode4"))
		{
//			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
		}
		else if (this.name.Equals("vehicleBtn"))
		{
			//Vehicle Button tapped
			Debug.Log("vehicleBtn" );
			MenuManager.Instance.SwitchPreviousMenu();
		}		
		
		else if (this.name.Equals("btnCoinsUpLeft"))
		{
			//Vehicle Button tapped
			Debug.Log("btnCoinsUpLeft" );
			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}		
		UserPrefs.Save ( ) ;
	}
	
	void updateCoins ( )
	{
		EpisodeMenuLocalize episodeLocalize = GameObject.FindGameObjectWithTag("EpisodeMenu").GetComponent<EpisodeMenuLocalize>() as EpisodeMenuLocalize;	
		episodeLocalize.updateCoions();
	
	}
	public void PurchaseEpisode(){
		if ( UserPrefs.totalCoins >= Constants.episodePriceArray[UserPrefs.currentEpisode-1] )
		{
			//UserPrefs.totalCoins -= Constants.episodePriceArray[UserPrefs.currentEpisode-1] ;
			GameManager.Instance.SubtractCoins(Constants.episodePriceArray[UserPrefs.currentEpisode-1]);
			UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode-1] = true ;
			updateCoins ( ) ;
		}
		else
		{
//				Instantiate ( Resources.Load ( "Menus/OutOfCoinsMenu" ) ) ;

		}
	}
	
	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
				
	}
	void unlockLevelorSwitchToUgrade(){
	
			if(UserPrefs.currentFontEpisode == 0){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite1();
			}
			else if(UserPrefs.currentFontEpisode == 1){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite3();
			}
			else if (UserPrefs.currentFontEpisode == 2){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite2();
			}
			else{
				
			}		
	}
	public void setepiosdeCoinsPanel(){
			Debug.Log("1"+UserPrefs.episodeUnlockArray[1]+ "2"+UserPrefs.episodeUnlockArray[2]);
			if (UserPrefs.episodeUnlockArray[1] == true){
				secondEpisodeSpotsPanel.alpha = 1;
				secondEpisodeCoinsPanel.alpha = 0;
			}
			else{
				secondEpisodeSpotsPanel.alpha= 0;
				secondEpisodeCoinsPanel.alpha =1;
			}
			if(UserPrefs.episodeUnlockArray[2] == true){
				thirdEpisodeSpotsPanel.alpha= 1;
				thirdEpisodeCoinsPanel.alpha = 0;
				
			}
			else{
				thirdEpisodeSpotsPanel.alpha = 0;
				thirdEpisodeCoinsPanel.alpha = 1;
			}
		
	}
}
