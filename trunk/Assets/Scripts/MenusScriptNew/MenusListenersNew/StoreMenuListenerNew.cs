using UnityEngine;
using System.Collections;
using System;
public class StoreMenuListenerNew : MonoBehaviour {
		
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		void OnClick(){
		
		if(this.name.Equals("backBtn")){
			Debug.Log("Back");
		   Destroy(GameObject.FindGameObjectWithTag("StoreMenu"));
			Resources.UnloadUnusedAssets();
		   if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.MAINMENU) { 
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
//				MenuManager.Instance.StartNewMenus();
		   }else{
		   		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			}
			
		}if(this.name.Equals("CoinsPackage1Btn")){
			Debug.Log("CoinsPackage1Btn");
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_1);
		}
		else if(this.name.Equals("CoinsPackage2Btn")){
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_2);
		}else if(this.name.Equals("CoinsPackage3Btn")){
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_3);
		}else if(this.name.Equals("CoinsPackage4Btn")){
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_4);
		}
		else if(this.name.Equals("CoinsPackage5Btn")){
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_5);
		}else if(this.name.Equals("settingsBtn")){
			Debug.Log("settingsBtn");
			ShowSettingMenu();
		
		}
	}

	public void Unlock(string package){
		Debug.Log("enter in purchase " + package );
		
		
		 if (package == ConstantsNew.PACKAGE_1)
		{ Debug.Log("enter in purchase " + "package 1 " );
			UpdateCoins(Convert.ToInt32(ConstantsNew.PACKAGE_1_AMOUNT));
		}
		else if (package == ConstantsNew.PACKAGE_2)
		{
			UpdateCoins(Convert.ToInt32(ConstantsNew.PACKAGE_2_AMOUNT));
		}
		else if (package == ConstantsNew.PACKAGE_3)
		{
			UpdateCoins(Convert.ToInt32(ConstantsNew.PACKAGE_3_AMOUNT));
		}
		else if (package == ConstantsNew.PACKAGE_4)
		{
			UpdateCoins(Convert.ToInt32(ConstantsNew.PACKAGE_4_AMOUNT));
		}
		else if (package == ConstantsNew.PACKAGE_5)
		{
			UpdateCoins(Convert.ToInt32(ConstantsNew.PACKAGE_5_AMOUNT));
		}
	}
	
	public void UpdateCoins(int coins){
		GameManager.Instance.AddCoins(coins);
		GameObject.FindGameObjectWithTag("lblStoreNew").GetComponent<UILabel>().text = UserPrefs.totalCoins.ToString();
		Debug.Log("enter in purchase " + "updated " );
		
	}
	public void ShowSettingMenu(){
		
		GameManager.GameState previousState=GameManager.Instance.GetPreviousGameState();
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
		GameManager.Instance.SetPreviousGameState(previousState);
	}
}
