using UnityEngine;
using System.Collections;
using System;
public class VehicleSelectionMenuListenerNew : MonoBehaviour {
	
	public UIPanel secondVehicleCoinsPanel;
	public UIPanel thirdVehicleCoinsPanel;
//	public GameObject inAppFuelPanel;
	
	
	// Use this for initialization
	void Start () {
//		#if UNITY_ANDROID
//			NGUITools.SetActive(inAppFuelPanel,false);
//		#endif
		updateCoins();
	//	Debug.Log("-------------------- " + UserPrefs.isAllEpisdoesUnlock );
		if(this.gameObject.name.Equals("getCoins")){
			
			this.playHavenIAPTracker(ConstantsNew.PACKAGE_VGP);
			/*
			if(UserPrefs.isAllEpisdoesUnlock){
				GameObject episodeUnlockButton = GameObject.FindGameObjectWithTag("UnlockAllEpisodes");
				if(episodeUnlockButton != null)
				{Debug.Log("-------------------- " );
					episodeUnlockButton.SetActive(false);
				}
			}
			*/
		}
		if(this.name.Equals("Vehicle1")){
			setVehicleCoinsPanel();	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick ( )
	{
		Debug.Log(this);
		if ( this.gameObject.name.Equals ("settingsBtn") )
		{
			Debug.Log("settingsBtn" );
			GAManager.Instance.LogDesignEvent("MainMenu:Settings");
			ShowSettingMenu();

		}
		else if(this.gameObject.name.Equals("getCoins"))
		{
			// Get Coins Button
			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		else if(name.Equals("nextBtn"))
		{
			// Next called
			Debug.Log("nextBtn Vehilce selection" );
//			MenuManager.Instance.SwitchNextMenu();
			unlockorSwitchToEpisodes();			
		}
		if (this.name.Equals("Vehicle1"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite1();
		}
		else if (this.name.Equals("Vehicle2"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
		}
		else if (this.name.Equals("Vehicle3"))
		{
			Debug.Log("vehile3" );
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
		}
		else if (this.name.Equals("vehicle4"))
		{
//			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
		}
		else if (this.name.Equals("vehicleBtn"))
		{
			//Vehicle Button tapped
			Debug.Log("vehicleBtn" );
		}
		else if (this.name.Equals("scratchBtn"))
		{
			//Vehicle Button tapped
//			 InAppFuel.showZone("93", "AiPAujmKgL",SystemInfo.deviceUniqueIdentifier, 1, "Vehicle1");
			 Debug.Log("scratchBtn"+SystemInfo.deviceUniqueIdentifier);
		}
		else if (this.name.Equals("SlotsBtn"))
		{
			//Vehicle Button tapped
			 Debug.Log("SlotsBtn"+SystemInfo.deviceUniqueIdentifier);
//			InAppFuel.showZone("93", "AiPAujmKgL", SystemInfo.deviceUniqueIdentifier, 2, "Vehicle1");
			//getUnawardedCurrency("22");
		}
		
		else if (this.name.Equals("btnCoinsUpLeft"))
		{
			Debug.Log("btnCoinsUpLeft" );
			
			// Get Coins Button
			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		UserPrefs.Save ( ) ;
	}
	
	void updateCoins ( )
	{
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.updateCoions();
	
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
	void unlockorSwitchToEpisodes(){
			Debug.Log("I val "+ GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().i);
			int frontVehicle = GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().i;
			if(frontVehicle == 0){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite1();
			}
			else if(frontVehicle == 1){
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
			}
			else if (frontVehicle == 2){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
			}
			else{
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
			}
	}
	
	public void setVehicleCoinsPanel(){
		if(UserPrefs.vehicleUnlockArray[1]==true){
			secondVehicleCoinsPanel.alpha = 0;	
		}
		else{
			secondVehicleCoinsPanel.alpha = 1;
		}
		if(UserPrefs.vehicleUnlockArray[2] == true){
			thirdVehicleCoinsPanel.alpha = 0;
		}
		else{
			thirdVehicleCoinsPanel.alpha = 1;
		}
	}
	
#region InAppFuel
	
	public void onGameClosed(string message) {

//		InAppFuel.getUnawardedCurrency("93", "AiPAujmKgL",SystemInfo.deviceUniqueIdentifier, "Vehicle1");
	}
	public void onZoneAlreadyFulfilled(string message)
	{
		Debug.LogError(message);
	}
	public void onError(string message)
	{
		Debug.LogError(message);
	}
	public void getUnawardedCurrency(string message){
		float coinsWon;
		//GameManager.Instance.AddCoins(Convert.ToInt32(message.ToString()));
		if(float.TryParse(message, out coinsWon))
		GameManager.Instance.AddCoins((int)Math.Ceiling(coinsWon));
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.updateCoions();
	}
#endregion

#region VGP
	
	public void playHavenIAPTracker(string productId) // Added by Majid
 	{
		Debug.Log("Tracking vgp");
//		PlayHaven.Purchase purchase = new PlayHaven.Purchase();
//  		purchase.productIdentifier = productId;
//  		purchase.receipt = "Purchased 1 item of id " + productId;
//  		purchase.quantity = 1;
  		
//  		PlayHavenManager.Instance.ProductPurchaseTrackingRequest(purchase,PlayHaven.PurchaseResolution.Buy);
 }
	
#endregion
}
