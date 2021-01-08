using UnityEngine;
using System.Collections;

public class StoreMenuListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		if (this.gameObject.name.Equals("btnStore")){
			SubMenusOld.Instance.EnableBackground();
			GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>().text = UserPrefs.totalCoins.ToString();	
			if(UserPrefs.isAllEpisdoesUnlock){
				GameObject gc = GameObject.FindGameObjectWithTag("UnlockAllEpisodes");
				if(gc != null){
					gc.SetActive(false);
				}
			}
			if(UserPrefs.isAllVehiclesUnlock){
				//GameObject.FindGameObjectWithTag("UnlockAllVehicle").SetActive(false);
			}
		 	if(UserPrefs.isIgnoreAds){
				GameObject gc1 = GameObject.FindGameObjectWithTag("Removeads");
				if(gc1 != null){
					gc1.SetActive(false);
				}				
			}
			
			if(UserPrefs.isAllEpisdoesUnlock && UserPrefs.isAllVehiclesUnlock && UserPrefs.isIgnoreAds){
				GameObject gc2 = GameObject.FindGameObjectWithTag("UnlockAll");
				if(gc2 != null){
					gc2.SetActive(false);
				}
			}
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
	/*	if(this.name.Equals("btnLeft")){
			SlideLeft();
		}else if(this.name.Equals("btnRight")){
			SlideRight();
		}
		*/
	//	Debug.Log("caled. " + this);
		if(this.name.Equals("btnPackage1")){
			GameManager.Instance.PurchasePackage(Constants.PACKAGE_1);
		}else if(this.name.Equals("btnPackage2")){
			GameManager.Instance.PurchasePackage(Constants.PACKAGE_2);
		}else if(this.name.Equals("btnPackage3")){
			GameManager.Instance.PurchasePackage(Constants.PACKAGE_3);
		}else if(this.name.Equals("btnPackage4")){
			GameManager.Instance.PurchasePackage(Constants.PACKAGE_4);
		}else if(this.name.Equals("btnUnlockEverything")){
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALL);
		}else if(this.name.Equals("btnUnlockAllVehicle")){
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALLVEHICLE);
		}else if(this.name.Equals("btnUnlockAllEpisodes")){
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALLEPISODE);
		}else if(this.name.Equals("btnRemoveads")){
			GameManager.Instance.PurchasePackage(Constants.REMOVEADS);
		}else if(this.name.Equals("btnBack")){
   
		   Destroy(GameObject.FindGameObjectWithTag("StoreMenu"));
		   Resources.UnloadUnusedAssets();
		   if(GameManager.Instance.GetPreviousGameState()!= GameManager.GameState.CRASHED && GameManager.Instance.GetPreviousGameState()!= GameManager.GameState.TIMEOVER)
		   { 
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		    	MenuManager.Instance.StartMenu();
		   }else{
		   		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			}
		}
		
	}
	
	
	public void UnlockAllEpisodes(){
		GameObject.FindGameObjectWithTag("UnlockAllEpisodes").SetActive(false);
		UserPrefs.isAllEpisdoesUnlock = true;
	}
	
	public void UnlockAllVechicles(){
		
		GameObject.FindGameObjectWithTag("UnlockAllVehicle").SetActive(false);
		UserPrefs.isAllVehiclesUnlock = true;
	}
	
	public void UnlockAll(){
		
		GameObject.FindGameObjectWithTag("UnlockAll").SetActive(false);
	}
	public void UpdateCoins(int coins){
		
		GameObject.FindGameObjectWithTag("storeLabel").GetComponent<UILabel>().text = UserPrefs.totalCoins.ToString();
		Debug.Log("enter in purchase " + "updated " );
		//GameManager.Instance.AddCoins(coins);
	}
	public void Removeads(){
		
		UserPrefs.isIgnoreAds = true;
		GameObject.FindGameObjectWithTag("Removeads").SetActive(false);
	}
	public void Unlock(string package){
		Debug.Log("enter in purchase " + package );
		if(package == Constants.UNLOCKALLEPISODE )
		{
			UnlockAllEpisodes();
		}
		else if (package == Constants.UNLOCKALLVEHICLE)
		{
			UnlockAllVechicles();
		}
		else if (package == Constants.UNLOCKALL)
		{
			UnlockAll();
		}
		else if (package == Constants.REMOVEADS)
		{
			Removeads();
		}
		else if (package == Constants.PACKAGE_1)
		{ Debug.Log("enter in purchase " + "package 1 " );
			UpdateCoins(Constants.PACKAGE_1_AMOUNT);
		}
		else if (package == Constants.PACKAGE_2)
		{
			UpdateCoins(Constants.PACKAGE_2_AMOUNT);
		}
		else if (package == Constants.PACKAGE_3)
		{
			UpdateCoins(Constants.PACKAGE_3_AMOUNT);
		}
		else if (package == Constants.PACKAGE_4)
		{
			UpdateCoins(Constants.PACKAGE_4_AMOUNT);
		}
		
	}
}
