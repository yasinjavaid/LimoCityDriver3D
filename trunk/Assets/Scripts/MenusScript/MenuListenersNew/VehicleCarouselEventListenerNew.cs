using UnityEngine;
using System.Collections;

public class VehicleCarouselEventListenerNew : MonoBehaviour {
	
	public GameObject vehicle1;
	public GameObject vehicle2;
	public GameObject vehicle3;
	public GameObject vehicle1LockedSprite;
	public GameObject vehicle2LockedSprite;
	public GameObject vehicle3LockedSprite;
	//public GameObject EpisodeOverlay ;
//	public GameObject EpisodePrice ;
//	public GameObject panel;
	bool firstTime;
	float startPos;
	float speed ;
	//public GameObject sprite5;
	public int i = 0;
	float [ ,]array;
	// Use this for initialization`
	void Start () {
		
		CheckUnlockvehicles();
			array = new float[3,3]{
			{vehicle1.transform.localPosition.x, vehicle1.transform.localPosition.y , vehicle1.transform.localPosition.z},
			{vehicle2.transform.localPosition.x, vehicle2.transform.localPosition.y , vehicle2.transform.localPosition.z},
			{vehicle3.transform.localPosition.x, vehicle3.transform.localPosition.y , vehicle3.transform.localPosition.z},
		
			
		};
		i = 0;
		UserPrefs.currentFontVehicle = i;
		speed = 1f;
		updateOverlay();
		Invoke("setSpriteDepths",0.5f);
		// just commited.
		//	SlideLeft();
		//setSpriteDepths(1);
	//	move (1);
		setvehicles();
		
	}
	
	void setvehicles(){
	
		switch(UserPrefs.currentVehicle){
			
			case 1:
				i = 0;
				UserPrefs.currentFontVehicle = i;
				vehicle1.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0, 2]);
				vehicle2.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				vehicle3.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
				break;
			
			case 2:
				Debug.Log("case 2 opened. ");
				i=2;
				UserPrefs.currentFontVehicle = i;
				vehicle2.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0,2]);
				vehicle3.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				vehicle1.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
				break;
			
			case 3:
				i=1;
				UserPrefs.currentFontVehicle = i;
				vehicle3.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0,2]);
				vehicle1.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				vehicle2.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
				break;
			
			
		}
		
	}
	void OnClick(){
		
	}
	void Update () {
		if ( Input.GetMouseButtonDown ( 0 ) )
		{
			startPos = Input.mousePosition.x ;
		}
		else if ( Input.GetMouseButtonUp ( 0 ) )
		{
			float offset = Input.mousePosition.x - startPos ;
			if ( offset > 100 )										
			{
				SlideLeft ();
			}
			else if ( offset < -100  )						
			{	
				SlideRight ( ) ;	
			}
		}else{
			
		}
	}
	
	void move(){
			iTween.MoveTo(vehicle1, iTween.Hash("position",new Vector3 ( array[i,0] ,array[i,1] , array[i,2] ),"islocal", true, "time", speed)); 
			iTween.MoveTo(vehicle2, iTween.Hash("position",new Vector3 ( array[(i+1) % 3,0] ,array[(i+1) % 3,1] , array[(i+1) % 3,2] ) , "islocal", true, "time", speed, "oncomplete" , "Zee", "oncompletetarget" , this.gameObject)); //-2307	
			iTween.MoveTo(vehicle3, iTween.Hash("position",new Vector3 ( array[(i+2) % 3,0] ,array[(i+2) % 3,1] , array[(i+2) % 3,2] ), "islocal", true, "time", speed)); //-2307	
	}
	
	public void Zee(){
	// just commited
	/*	if(firstTime){
		setSpriteDepths(i);
			firstTime =false;
		}
		 */
		updateOverlay();
		
	}	
	
	void setSpriteDepths ( )
	{
		GameObject []arr = new GameObject[4] ;
		
		arr [ (i+1) % 3 ] = vehicle1 ;
		arr [ (i+2) % 3 ] = vehicle2 ;
		arr [ (i+3) % 3 ] = vehicle3 ;
		//arr [ (i+4) % 4 ] = episode4 ;
		
		
		UISprite [] spriteArray ;
		
	 	spriteArray = arr[0].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 2 ;
		
	/* 	spriteArray = arr[1].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 4 ;
	*/	
	 	spriteArray = arr[1].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 3 ;
		
	 	spriteArray = arr[2].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 3 ;
		
	 	
	}
	public void  SlideLeft(){
		i++;
		if(i % 3 == 0)
			i = 0;
			UserPrefs.currentFontVehicle = i;
		
		move ();
		
		setSpriteDepths();	
		Debug.Log(" ----------------------------  "+ i +  "  ffdd " );
	}
	
	public void  SlideRight(){
		i--;
		if(i  == -1)
			i = 2;
			UserPrefs.currentFontVehicle = i;
		
		move ();
		setSpriteDepths();
		Debug.Log(" ----------------------------  "+ i +  "  ffdd " );
	}
	
	public void ChecktThePositionSprite1(){
		Debug.Log(" check postion 4 value of i"+i);
		if( i == 0){			
			UserPrefs.currentVehicle = 1 ;
			GAManager.Instance.LogDesignEvent("vehicle:"+UserPrefs.currentVehicle);
			UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[0];			
			CallLevelSelectionMenu();
			
		}else if ( i  == 2){  //
			Debug.Log(" slide left 4 ");
			SlideLeft();
			
		}else if ( i  == 1   ){   //
			Debug.Log(" slide right 4 ");
			SlideRight();
			
		}
		
	}
	public void ChecktThePositionSprite2(){
		Debug.Log(" check postion 1 " +  i);
		if( i == 2){
			
			if(!UserPrefs.vehicleUnlockArray[1]){
				//UnlockVehicle(2);
				//updateOverlay();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUNLOCK); 
			}
			else{
				Debug.Log("Setting current vehicle to 2");
				UserPrefs.currentVehicle = 2 ;
				GAManager.Instance.LogDesignEvent("vehicle:"+UserPrefs.currentVehicle);
				UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[1];
				Debug.LogWarning( " elvel " + UserPrefs.currentLevel );
				CallLevelSelectionMenu();
			}
		}else if ( i  == 0){   //
			SlideRight();
			Debug.Log("right called. ");
			
		}else if ( i  == 1    ){
			SlideLeft();   //
		
		}
		
	}
	
	public void ChecktThePositionSprite3(){
		Debug.Log(" check postion 2 "+i);
		if( i == 1){
			if(!UserPrefs.vehicleUnlockArray[2]){
				//UnlockVehicle(3);
				//updateOverlay();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUNLOCK); 
			}
			else{
				UserPrefs.currentVehicle = 3 ;
				GAManager.Instance.LogDesignEvent("vehicle:"+UserPrefs.currentVehicle);
				UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[2];
				CallLevelSelectionMenu();
			}
		}else if ( i  == 2  ){ //
			SlideRight();
			
		}else if ( i  == 0 ){
			SlideLeft();
			
		}
		
	}
	
	void CallLevelSelectionMenu(){
		
		MenuManager.Instance.SwitchNextMenu();	
	}
	
	public void updateOverlay ( )
	{
	
		
		if ( UserPrefs.vehicleUnlockArray [ UserPrefs.currentVehicle - 1 ] )
		{
//			NGUITools.SetActive(vehicleOverlay,false);
		}
		else
		{
		//	NGUITools.SetActive(vehicleOverlay,true);
//			UILabel priceLabel = vehiclePrice.GetComponent<UILabel>();
//			priceLabel.text = Constants.vehiclePriceArray [ UserPrefs.currentvehicle - 1 ] . ToString ( ) ;
		}
		UserPrefs.Save();
	}
	
	
	
	void CallNextSlideLeft(){
	
		Destroy(GameObject.FindGameObjectWithTag("vehicleSelectionMenu"));
		Resources.UnloadUnusedAssets();
		Instantiate ( Resources.Load ( "Menus/LevelSelection" ) ) ;	
	}
	
	
	
	public void CheckUnlockvehicles(){
		Debug.Log("called. "  + UserPrefs.vehicleUnlockArray[1]);
		if(UserPrefs.vehicleUnlockArray[0]){
			vehicle1LockedSprite.SetActive(false);
		}
		if(UserPrefs.vehicleUnlockArray[1]){
			vehicle2LockedSprite.SetActive(false);
		}
		if(UserPrefs.vehicleUnlockArray[2]){
			vehicle3LockedSprite.SetActive(false);
		
		}	
	}
	public void UnlockVehicle(int vehicle){

		if ( UserPrefs.totalCoins >= ConstantsNew.vehiclePriceArray[vehicle-1] ){
				Debug.Log("vehicle unlocked. ");
				GAManager.Instance.LogDesignEvent("VehicleUnlocked:Success:"+vehicle);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			//	UserPrefs.totalCoins -= Constants.episodePriceArray[episode-1] ;
			
				GameManager.Instance.SubtractCoins(ConstantsNew.vehiclePriceArray[vehicle-1]);
				UserPrefs.vehicleUnlockArray[vehicle-1] = true ;
				updateCoins ( ) ;
				CheckUnlockvehicles();
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
					UserPrefs.isAllEpisdoesUnlock = true;
					GameObject episodeUnlockButton = GameObject.FindGameObjectWithTag("UnlockAllEpisodes");
					if(episodeUnlockButton != null)
					{
						episodeUnlockButton.SetActive(false);
					}
				}
				UserPrefs.Save ( ) ;
			}
		else{
			GAManager.Instance.LogDesignEvent("CoinCons:UnlockTry:Fail:"+vehicle);
			GameManager.GameState previousState= GameManager.Instance.GetPreviousGameState();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
			GameManager.Instance.SetPreviousGameState(previousState);
		}
	}
	
	void updateCoins ( )
	{
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.updateCoions();
	
	}
	
	/*
	public void UnLockAllvehicles(){
		
		// in app success code
		for(int i = 0; i<UserPrefs.episodeUnlockArray.Length; i++){
			UserPrefs.episodeUnlockArray[i] = true ;
		}
		CheckUnlockvehicles();
		updateOverlay();
		GameObject.FindGameObjectWithTag("UnlockAllEpisodes").SetActive(false);
		UserPrefs.isAllEpisdoesUnlock = true;
	}
	
	*/
	
}

