using UnityEngine;
using System.Collections;

public class CarouselEventListener : MonoBehaviour {
	
	public GameObject episode1;
	public GameObject episode2;
	public GameObject episode3;
	public GameObject episode1LockedSprite;
	public GameObject episode2LockedSprite;
	public GameObject episode3LockedSprite;
	//public GameObject EpisodeOverlay ;
//	public GameObject EpisodePrice ;
//	public GameObject panel;
	bool firstTime;
	float startPos;
	float speed ;
	//public GameObject sprite5;
	int i = 0;
	float [ ,]array;
	// Use this for initialization`
	void Start () {
		
		CheckUnlockEpisodes();
			array = new float[3,3]{
			{episode1.transform.localPosition.x, episode1.transform.localPosition.y , episode1.transform.localPosition.z},
			{episode2.transform.localPosition.x, episode2.transform.localPosition.y , episode2.transform.localPosition.z},
			{episode3.transform.localPosition.x, episode3.transform.localPosition.y , episode3.transform.localPosition.z},
		
			
		};
		i = 0;
		speed = 3f;
		updateOverlay();
		Invoke("setSpriteDepths",0.5f);
		// just commited.
		//	SlideLeft();
		//setSpriteDepths(1);
	//	move (1);
		setEpisodes();
		
	}
	
	void setEpisodes(){
	
		switch(UserPrefs.currentEpisode){
			
			case 1:
				i = 0;
				episode1.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0, 2]);
				episode2.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				episode3.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
				break;
			
			case 2:
				Debug.Log("case 2 opened. ");
				i=2;
				episode2.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0,2]);
				episode3.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				episode1.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
				break;
			
			case 3:
				i=1;
				episode3.transform.localPosition = new Vector3(array[0,0],array[0,1], array[0,2]);
				episode1.transform.localPosition = new Vector3(array[1,0],array[1,1], array[1,2]);
				episode2.transform.localPosition = new Vector3(array[2,0],array[2,1], array[2,2]);
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
			iTween.MoveTo(episode1, iTween.Hash("position",new Vector3 ( array[i,0] ,array[i,1] , array[i,2] ), "islocal", true, "time", speed)); 
			iTween.MoveTo(episode2, iTween.Hash("position",new Vector3 ( array[(i+1) % 3,0] ,array[(i+1) % 3,1] , array[(i+1) % 3,2] ) , "islocal", true, "time", speed, "oncomplete" , "Zee", "oncompletetarget" , this.gameObject)); //-2307	
			iTween.MoveTo(episode3, iTween.Hash("position",new Vector3 ( array[(i+2) % 3,0] ,array[(i+2) % 3,1] , array[(i+2) % 3,2] ), "islocal", true, "time", speed)); //-2307	
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
/*	
	void setSpriteDepths(int i){
		
		if (i== 0){
			sprite1.GetComponent<UISprite>().depth = 2;
			sprite2.GetComponent<UISprite>().depth = 2;
			sprite3.GetComponent<UISprite>().depth = 0;
			sprite4.GetComponent<UISprite>().depth = 2;
			UserPrefs.currentEpisode = 0;
		//	UserPrefs.currentLevel = UserPrefs.episode3LevelCleared;
			UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1];	
		}else if ( i == 1){
			sprite1.GetComponentInChildren<UISprite>().depth = 2;
			sprite2.GetComponentInChildren<UISprite>().depth = 0;
			sprite3.GetComponentInChildren<UISprite>().depth = 2;
			sprite4.GetComponentInChildren<UISprite>().depth = 2;
			UserPrefs.currentEpisode = 1;
			UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1];		
		}else if ( i == 2){
			sprite1.GetComponent<UISprite>().depth = 0;
			sprite2.GetComponent<UISprite>().depth = 2;
			sprite3.GetComponent<UISprite>().depth = 2;
			sprite4.GetComponent<UISprite>().depth = 2;
			UserPrefs.currentEpisode = 4;
			UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1];	
		}else if ( i == 3){
			sprite1.GetComponent<UISprite>().depth = 2;
			sprite2.GetComponent<UISprite>().depth = 2;
			sprite3.GetComponent<UISprite>().depth = 2;
			sprite4.GetComponent<UISprite>().depth = 0;
			UserPrefs.currentEpisode = 3;
			UserPrefs.currentLevel = UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1];	
		}
	}
	
	*/
	
	
	/*
	void setSpriteDepths ( )
	{
		GameObject []arr = new GameObject[4] ;
		
		arr [ (i+1) % 4 ] = episode1 ;
		arr [ (i+2) % 4 ] = episode2 ;
		arr [ (i+3) % 4 ] = episode3 ;
		arr [ (i+4) % 4 ] = episode4 ;
		
		
		UISprite [] spriteArray ;
		
	 	spriteArray = arr[0].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 3 ;
		
	 	spriteArray = arr[1].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 4 ;
		
	 	spriteArray = arr[2].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 3 ;
		
	 	spriteArray = arr[3].GetComponentsInChildren<UISprite>();
		for ( int j = 0 ; j < spriteArray.Length ; j ++ )
			spriteArray[j].depth = 2 ;
		
	 	
	}
	*/
	
	
	void setSpriteDepths ( )
	{
		GameObject []arr = new GameObject[4] ;
		
		arr [ (i+1) % 3 ] = episode1 ;
		arr [ (i+2) % 3 ] = episode2 ;
		arr [ (i+3) % 3 ] = episode3 ;
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
		
		
		move ();
		
		setSpriteDepths();	
		Debug.Log(" ----------------------------  "+ i +  "  ffdd " );
	}
	
	public void  SlideRight(){
		i--;
		if(i  == -1)
			i = 2;
		
		
		move ();
		setSpriteDepths();
		
	}
	
	public void ChecktThePositionSprite1(){
		Debug.Log(" check postion 4 ");
		if( i == 0){			
			UserPrefs.currentEpisode = 1 ;
			GAManager.Instance.LogDesignEvent("Episode:"+UserPrefs.currentEpisode);
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
			
			if(!UserPrefs.episodeUnlockArray[1]){
				UnlockEpisdoe(2);
				updateOverlay();
			}
			else{
				UserPrefs.currentEpisode = 2 ;
				GAManager.Instance.LogDesignEvent("Episode:"+UserPrefs.currentEpisode);
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
		Debug.Log(" check postion 2 ");
		if( i == 1){
			if(!UserPrefs.episodeUnlockArray[2]){
				UnlockEpisdoe(3);
				updateOverlay();
			}
			else{
				UserPrefs.currentEpisode = 3 ;
				GAManager.Instance.LogDesignEvent("Episode:"+UserPrefs.currentEpisode);
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
	
		
		if ( UserPrefs.episodeUnlockArray [ UserPrefs.currentEpisode - 1 ] )
		{
//			NGUITools.SetActive(EpisodeOverlay,false);
		}
		else
		{
		//	NGUITools.SetActive(EpisodeOverlay,true);
//			UILabel priceLabel = EpisodePrice.GetComponent<UILabel>();
//			priceLabel.text = Constants.episodePriceArray [ UserPrefs.currentEpisode - 1 ] . ToString ( ) ;
		}
		UserPrefs.Save();
	}
	
	
	
	void CallNextSlideLeft(){
	
		Destroy(GameObject.FindGameObjectWithTag("EpisodeSelectionMenu"));
		Resources.UnloadUnusedAssets();
		Instantiate ( Resources.Load ( "Menus/LevelSelection" ) ) ;	
	}
	
	
	
	public void CheckUnlockEpisodes(){
		Debug.Log("called. "  + UserPrefs.episodeUnlockArray[1]);
		if(UserPrefs.episodeUnlockArray[0]){
			episode1LockedSprite.SetActive(false);
		}
		
		if(UserPrefs.episodeUnlockArray[1]){
			episode2LockedSprite.SetActive(false);
		}
		if(UserPrefs.episodeUnlockArray[2]){
			episode3LockedSprite.SetActive(false);
		
		}
		
		
	}
	
	
	public void UnlockEpisdoe(int episode){

		if ( UserPrefs.totalCoins >= Constants.episodePriceArray[episode-1] ){
				Debug.Log("episode unlocked. ");
				GAManager.Instance.LogDesignEvent("CoinCons:UnlockTry:Success:"+episode);
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.EPISODEUNLOCK);
			//	UserPrefs.totalCoins -= Constants.episodePriceArray[episode-1] ;
				GameManager.Instance.SubtractCoins(Constants.episodePriceArray[episode-1]);
				UserPrefs.episodeUnlockArray[episode-1] = true ;
				updateCoins ( ) ;
				CheckUnlockEpisodes();
				bool status = false;
				for(int i = 0; i< UserPrefs.episodeUnlockArray.Length; i++){
					 
					if(UserPrefs.episodeUnlockArray[i]){
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
			GAManager.Instance.LogDesignEvent("CoinCons:UnlockTry:Fail:"+episode);
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.OUTOFCOINS);
		}
	}
	
	void updateCoins ( )
	{
		UILabel coinsDisplay  = GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>();
		coinsDisplay.text = UserPrefs.totalCoins.ToString();	
	
	}
	
	
	public void UnLockAllEpisodes(){
		
		// in app success code
		for(int i = 0; i<UserPrefs.episodeUnlockArray.Length; i++){
			UserPrefs.episodeUnlockArray[i] = true ;
		}
		CheckUnlockEpisodes();
		updateOverlay();
		GameObject.FindGameObjectWithTag("UnlockAllEpisodes").SetActive(false);
		UserPrefs.isAllEpisdoesUnlock = true;
	}
	
	
	
}

