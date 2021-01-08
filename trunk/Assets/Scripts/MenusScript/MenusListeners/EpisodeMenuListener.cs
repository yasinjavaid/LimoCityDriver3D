using UnityEngine;
using System.Collections;

public class EpisodeMenuListener : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick ( )
	{
		Debug.Log(this);
		if ( this.gameObject.name.Equals ("PurchaseEpisode") )
		{
			PurchaseEpisode();
		}
		else if(this.gameObject.name.Equals("btnBack"))
		{
			MenuManager.Instance.SwitchPreviousMenu();
		}
		else if(name.Equals("btnStore"))
		{

			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			Destroy(GameObject.FindGameObjectWithTag("EpisodeMenu"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
			//MenuManager.Instance.OpenStore();

		}
		if (this.name.Equals("Episode1"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite1();
		}
		else if (this.name.Equals("Episode2"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite2();
		}
		else if (this.name.Equals("Episode3"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite3();
		}
		else if (this.name.Equals("Episode4"))
		{
//			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
		}
		
		else if (this.name.Equals("btnUnLockAllEpisodes"))
		{
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALLEPISODE);
		}
		
		
		UserPrefs.Save ( ) ;
	}
	
	void updateCoins ( )
	{
		UILabel coinsDisplay  = GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>();
		coinsDisplay.text = UserPrefs.totalCoins.ToString();	
	
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
	
	
	public void UnlockAllEpisodes(){
		//			GameObject.FindGameObjectWithTag("StoreManagerHandler").GetComponent<StoreManagerHandler>().BuyPackages(UserPrefs.unLockAllEpisodes);
		
	/*		for(int i = 0; i<UserPrefs.episodeUnlockArray.Length; i++){
				UserPrefs.episodeUnlockArray[i] = true ;
				UserPrefs.totalCoins -= UserPrefs.episodePriceArray[i] ;
			}
			GameObject truckPanel = GameObject.FindGameObjectWithTag ( "episodeMenuPanel" ) ;
		
				EpisodeDragScript PanelScript = truckPanel.GetComponent < EpisodeDragScript > ( ) ;
			PanelScript.updateOverlayAllUnLock();
			
		*/	
	}

}
