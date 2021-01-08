using UnityEngine;
using System.Collections;

public class VehicleSelectionMenuListener : MonoBehaviour
{	
	
	private UILabel storeLable;
	
	
	void Start(){
		
		UpdateCoins();
		if(this.gameObject.name.Equals("btnBack")){
			if(UserPrefs.isAllVehiclesUnlock){
				GameObject vehiclenlockButton = GameObject.FindGameObjectWithTag("UnlockAllVehicles");
				if(vehiclenlockButton != null)
				{
					vehiclenlockButton.SetActive(false);
				}
			}
			
		}
	}
	
	
	void OnClick ( )
	{
		if ( this.gameObject.name.Equals ("PurchaseVehicle") )
		{
			PurchaseVehicle();
		}
		else if ( this.gameObject.name.Equals ("btnTop") )
		{
			SlideTop();
		}
		else if ( this.gameObject.name.Equals ("btnBottom") )
		{	
			SlideBottom();
		}
		else if(this.gameObject.name.Equals("btnBack"))
		{
			MenuManager.Instance.SwitchPreviousMenu();
		}
		else if(this.gameObject.name.Equals("btnStore"))
		{
			GAManager.Instance.LogDesignEvent("Vehicle:CoinsStore");
			Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		else if(this.gameObject.name.Equals("btnUnLockAllVehicles"))
		{
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALLVEHICLE);
		}
		else if(this.gameObject.name.Equals("btnPlay"))
		{
			GAManager.Instance.LogDesignEvent("Vehicle:Play:Veh#"+UserPrefs.currentVehicle);
			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
			MenuManager.Instance.SwitchNextMenu();
			//Application.LoadLevel("GamePlayDumy");
			
		}
		
	}
	
	
	
	void UpdateCoins ( )
	{
		UILabel coinsDisplay  = GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>();
		coinsDisplay.text = UserPrefs.totalCoins.ToString();	
	}
	
	private void PurchaseVehicle(){
		if ( UserPrefs.totalCoins >= Constants.vehiclePriceArray[UserPrefs.currentSelectedVehicle-1] )
			{
				GAManager.Instance.LogDesignEvent("CoinCons:Vehicle:Success:Veh#"+UserPrefs.currentSelectedVehicle);
				GameManager.Instance.SubtractCoins(Constants.vehiclePriceArray[UserPrefs.currentSelectedVehicle-1]);
				UserPrefs.vehicleUnlockArray[UserPrefs.currentSelectedVehicle-1] = true ;
				UserPrefs.currentVehicle =  UserPrefs.currentSelectedVehicle;
				UpdateCoins ( ) ;
				GameObject.FindGameObjectWithTag ( "vehicleMenuPanel" ).GetComponent < VehicleSelectionDragScript >().updateOverlay();
				
				bool status = false;
				for(int i = 0; i< UserPrefs.vehicleUnlockArray.Length; i++){
					 
					if(UserPrefs.vehicleUnlockArray[i]){
						status= true;
					}
					else
					{
						status = false;
						break;
					}
				
				}
			
				if(status)
				{
					UserPrefs.isAllVehiclesUnlock = true;
					GameObject vehicleUnlockButton = GameObject.FindGameObjectWithTag("UnlockAllVehicles");
					if(vehicleUnlockButton != null)
					{
						vehicleUnlockButton.SetActive(false);
					}
				
				}
				UserPrefs.Save ( ) ;
		}
		else
		{// will come level out of canides.
			GAManager.Instance.LogDesignEvent("CoinCons:Vehicle:Fail:Veh#"+UserPrefs.currentVehicle);
			//Instantiate(Resources.Load("SubMenus/LevelOutofCoins"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.OUTOFCOINS);
		}
	}
	
	private void SlideTop(){
		
		GameObject.FindGameObjectWithTag ( "vehicleMenuPanel" ).GetComponent < VehicleSelectionDragScript >().SlideTop ( ) ;
	}
	
	private void SlideBottom(){
		
		GameObject.FindGameObjectWithTag ( "vehicleMenuPanel" ).GetComponent < VehicleSelectionDragScript >().SlideBottom ( ) ;
				
	}
	
	
	
	
}
