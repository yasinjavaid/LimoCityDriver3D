/*
 * This script is use to drag the vehicle up and down and change vehicle price according to currecnt vehicle in focus.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class VehicleSelectionDragScript : MonoBehaviour 
{
	float startPos ;
	
	//public GameObject vehicleMenuCamera ;

	public GameObject AccelerateSlider ;
	public GameObject HandlingSlider ;
	public GameObject SpeedSlider ;
	public GameObject BrakeSlider;
	public GameObject ResistanceSlider;
	public GameObject VehicleSelectionSlider;
	public GameObject VehicleOverlay ;
	public GameObject VehiclePrice ;
	public GameObject panel;
	public GameObject btnTop ;
	public GameObject btnBottom ;
	
	
	
	void Start ( )
	{	
		UserPrefs.currentSelectedVehicle = UserPrefs.currentVehicle;
		Debug.Log("curent vehicle " + UserPrefs.currentVehicle );
		if ( UserPrefs.currentVehicle == 1 ){
			btnTop.GetComponent<BoxCollider>().enabled = false;
		}else{
			btnTop.GetComponent<BoxCollider>().enabled = true;
		}
		if ( UserPrefs.currentVehicle == 3 ){
			btnBottom.GetComponent<BoxCollider>().enabled = false;
		}else{
			btnBottom.GetComponent<BoxCollider>().enabled = true;
		}
		setVehiclePosition();

	}
		
	void setVehiclePosition ( )
	{
/*		if ( UserPrefs.currentVehicle == 5  )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 3249, 0 ), "islocal", true, "time", 1)); 
			btnBottom.GetComponent<BoxCollider>().enabled = false;
			btnTop.GetComponent<BoxCollider>().enabled = true;
		}
		
		if ( UserPrefs.currentVehicle == 4  )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 2549+40, 0 ), "islocal", true, "time", 1)); 
			btnBottom.GetComponent<BoxCollider>().enabled = true;
			btnTop.GetComponent<BoxCollider>().enabled = true;
		}
	*/	
		 if ( UserPrefs.currentVehicle == 3 )
		{	
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 1746+40, 0), "islocal", true, "time", 1)); 
			btnBottom.GetComponent<BoxCollider>().enabled = false;
			btnTop.GetComponent<BoxCollider>().enabled = true;
		} 
		
		 if ( UserPrefs.currentVehicle == 2 )
		{	
		iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128,1050+40 ,  0 ), "islocal", true, "time", 1));	
			btnBottom.GetComponent<BoxCollider>().enabled = true;
			btnTop.GetComponent<BoxCollider>().enabled = true;
			
		}
		
		if ( UserPrefs.currentVehicle == 1  )
		{	
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128,345 ,  0 ), "islocal", true, "time", 1)); 
			btnTop.GetComponent<BoxCollider>().enabled = false;
			btnBottom.GetComponent<BoxCollider>().enabled = true;
			
		}
		Invoke ( "updateOverlay" , 0.2f ) ;
	//	iTween.MoveFrom(  panel.gameObject, iTween.Hash(  "y",  -3f,  "time", 1.5  )  ); 
	
		
	/*	else if ( UserPrefs.currentVehicle == 6 )
		{
			panel.transform.localPosition = new Vector3(-128, 3948  ,0);
		}
		*/
	}

	void Update ( )
	{
		if ( Input.GetMouseButtonDown ( 0 ) )
		{
			startPos = Input.mousePosition.y ;
		}
		
		if ( Input.GetMouseButtonUp ( 0 ) )
		{
			float offset = Input.mousePosition.y - startPos ;
			
			if ( offset < -100 )									// goto lower vehicle
			{
				SlideTop ( ) ;
			}
			else if ( offset > 100 )							// goto higher vehicle
			{
				SlideBottom( ) ;
			}
		}
	}
	
	public void SlideTop ( )
	{	
		if (  UserPrefs.currentSelectedVehicle == 2 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128,345 ,  0), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 1 ;
			btnTop.GetComponent<BoxCollider>().enabled = false;
		}
		else if (  UserPrefs.currentSelectedVehicle == 3 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 1050+40, 0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 2 ;
			btnBottom.GetComponent<BoxCollider>().enabled = true;
		}
	/*	else if (  UserPrefs.currentSelectedVehicle == 4 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128, 1746+40,0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 3 ;
		}
		else if (  UserPrefs.currentSelectedVehicle == 5 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 2549,0), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 4 ;
			btnBottom.GetComponent<BoxCollider>().enabled = true;
		}
	*/	
		if(UserPrefs.vehicleUnlockArray[UserPrefs.currentSelectedVehicle-1]){
			UserPrefs.currentVehicle =  UserPrefs.currentSelectedVehicle;
		}
	/*	else if ( currentSelectedVehicle == 6 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 3249, 0), "islocal", true, "time", 1)); //-2307
			currentSelectedVehicle = 5 ;
			
			btnBottom.GetComponent<BoxCollider>().enabled = true;
		}
		*/
		
		Invoke ( "updateOverlay" , 0.2f ) ;
	}
	
	public void SlideBottom( )
	{
		if (  UserPrefs.currentSelectedVehicle == 1 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128,1050+40 ,  0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 2 ;
			btnTop.GetComponent<BoxCollider>().enabled = true;
		}
		else if (  UserPrefs.currentSelectedVehicle == 2 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 1746+40, 0), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 3 ;
			btnBottom.GetComponent<BoxCollider>().enabled = false;
		}
	/*	else if (  UserPrefs.currentSelectedVehicle == 3 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 2549+40, 0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 4 ;
		}
		else if ( UserPrefs.currentSelectedVehicle == 4 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 3249, 0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 5 ;
			btnBottom.GetComponent<BoxCollider>().enabled = false;
		}
	*/	
		if(UserPrefs.vehicleUnlockArray[UserPrefs.currentSelectedVehicle-1]){
			UserPrefs.currentVehicle =  UserPrefs.currentSelectedVehicle;
		}
	/*	else if ( UserPrefs.currentSelectedVehicle == 5 )
		{
			iTween.MoveTo(panel, iTween.Hash("position",new Vector3 ( -128 , 3948, 0 ), "islocal", true, "time", 1)); //-2307
			UserPrefs.currentSelectedVehicle = 6 ;
			btnBottom.GetComponent<BoxCollider>().enabled = false;
		}
	*/
		Invoke ( "updateOverlay" , 0.2f ) ;
	}
	
	
	
	
	public void updateOverlay ( )
	{
		if ( UserPrefs.vehicleUnlockArray [   UserPrefs.currentSelectedVehicle- 1 ] )
		{
			NGUITools.SetActive(VehicleOverlay,false);
		}
		else
		{
			NGUITools.SetActive(VehicleOverlay,true);
			UILabel priceLabel = VehiclePrice.GetComponent<UILabel>();
			priceLabel.text = Constants.vehiclePriceArray [  UserPrefs.currentSelectedVehicle - 1 ] . ToString ( ) ;
		}
		updateAttribute ( ) ;
	}
	void updateAttribute ( )
	{
		Debug.Log("vehicle attributes called. "  );
		Debug.Log(  UserPrefs.currentVehicle-1);
		AccelerateSlider.GetComponent<UIFilledSprite>().fillAmount=chopValue(Constants.vehicleAccelerationArray[UserPrefs.currentSelectedVehicle-1]);
		HandlingSlider.GetComponent<UIFilledSprite>().fillAmount=chopValue(Constants.vehicleHandlingArray		 [UserPrefs.currentSelectedVehicle-1]);
		SpeedSlider	.GetComponent<UIFilledSprite>().fillAmount=chopValue(Constants.vehicleSpeedArray	 [UserPrefs.currentSelectedVehicle-1]);
		ResistanceSlider	.GetComponent<UIFilledSprite>().fillAmount=chopValue(Constants.vehicleResistanceArray	 [UserPrefs.currentSelectedVehicle-1]);
		BrakeSlider	.GetComponent<UIFilledSprite>().fillAmount=chopValue(Constants.vehicleBrakingArray[UserPrefs.currentSelectedVehicle-1]);
		VehicleSelectionSlider.GetComponent<UIFilledSprite>().fillAmount=Constants.vehicleSelectionArray[UserPrefs.currentSelectedVehicle-1];

	}
	
	float chopValue ( int valueToChop )				// hard coded hash values for the bars
	{
		float currentValue = 0 ;
		
		switch ( valueToChop )
		{
			case 1 :	currentValue = 0.075f ;
						break ;
			
			case 2 :	currentValue = 0.13f ;
						break ;
			
			case 3 :	currentValue = 0.185f ;
						break ;
			
			case 4 :	currentValue = 0.245f ;
						break ;
			
			case 5 :	currentValue = 0.31f ;
						break ;
			
			case 6 :	currentValue = 0.37f ;
						break ;
			
			case 7 :	currentValue = 0.43f ;
						break ;
			
			case 8 :	currentValue = 0.50f ;
						break ;
			
			case 9 :	currentValue = 0.565f ;
						break ;
			
			case 10 :	currentValue = 0.63f ;
						break ;
			
			case 11 :	currentValue = 0.70f ;
						break ;
			
			case 12 :	currentValue = 0.765f ;
						break ;
			
			case 13 :	currentValue = 0.835f ;
						break ;
			
			case 14 :	currentValue = 0.905f ;
						break ;
			
			case 15 :	currentValue = 1f ;
						break ;
			
			default :	currentValue = 0f ;
						break ;
		}
		return currentValue ;
	}
	
	public void updateOverlayAllUnLock(){
		for(int i = 0; i<UserPrefs.vehicleUnlockArray.Length; i++){
			if ( UserPrefs.vehicleUnlockArray [ i ] )
			{
				NGUITools.SetActive(VehicleOverlay,false);
			}
		}
		GameObject.FindGameObjectWithTag("UnlockAllVehicles").SetActive(false);
		
	}
	
	public void UnLockAllVehicles(){
		for(int i = 0; i<UserPrefs.vehicleUnlockArray.Length; i++){
				UserPrefs.vehicleUnlockArray[i] = true ;				
		}
		UserPrefs.isAllVehiclesUnlock = true;
		updateOverlayAllUnLock();
		
	}
	
}
