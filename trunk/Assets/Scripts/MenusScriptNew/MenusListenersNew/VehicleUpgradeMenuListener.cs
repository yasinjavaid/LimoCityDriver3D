using UnityEngine;
using System.Collections;

public class VehicleUpgradeMenuListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnSettings")){
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel >= VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeBrakes").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text ="0";
			}
			else{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ].ToString();

			}
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel >= VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeEngine").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text ="0";
			}
			else{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ].ToString();

			}
	
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel >= VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeTires").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text ="0";
			}
			else{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ].ToString();

			}
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel >= VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeSteering").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text ="0";
			}
			else{
				Debug.Log("value is"+ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel);
				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = ""+VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel;
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ].ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		
		Debug.Log("Current Vehicle"+UserPrefs.currentVehicle+ "Current Episode"+UserPrefs.currentEpisode);
		
		if(this.name == "btnGetCoins"){
			
			Debug.Log("getCoins" );
			GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);

		}
		else if(this.name == "btnBack"){
			Debug.Log("backBtn" );
			MenuManager.Instance.SwitchPreviousMenu();

		}
		else if(this.name == "btnNext"){
			
			Debug.Log("nextBtn" );
			MenuManager.Instance.SwitchNextMenu();

		}
		else if(this.name == "btnSettings"){
			
			Debug.Log("settingsBtn" );
			GAManager.Instance.LogDesignEvent("MainMenu:Settings");
			ShowSettingMenu();

		}
		else if(this.name == "btnUpgradeEngine"){
			UpgradeEngine();
		}
		else if(this.name == "btnUpgradeSteering"){
			UpgradeSteering();
		}
		else if(this.name == "btnUpgradeTires"){
			UpgradeTires();
		}
		else if(this.gameObject.name.Equals("btnUpgradeBrakes")){
			UpgradeBrake();
		}
		
		
		
		else if(this.gameObject.name.Equals("btnCoinsUpLeft")){
			GAManager.Instance.LogDesignEvent("btnCoinsTopLeft");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		
	//	UpgradeBrake();
	}
	
	
	void UpgradeBrake(){
		Debug.Log("upgrade brake "+VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel);
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins >= coinsRequire)
		{
			GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMBRAKESUPGRADE);
//			GameManager.Instance.SubtractCoins(coinsRequire);
//			GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
//			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel++;
//			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeTotalUpgradeLevel){
//				GameObject.FindGameObjectWithTag("btnUpgradeBrakes").SetActive(false);
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text ="0";
//			}
//			else
//			{
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
//				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ].ToString();
//			}	
		}
		else
		{
			GameManager.Instance.ChangeState(GameManager.GameState.OUTOFCOINSBRAKESUPGRADE);
		}
//		SaveandLoad.Save();
	}
	
	void UpgradeEngine(){
		Debug.Log("upgrade engine ");
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins >= coinsRequire)
		{
			GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMENGINEUPGRADE);
			
//			GameManager.Instance.SubtractCoins(coinsRequire);
//			GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
//			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel++;
//			Debug.Log("Incrementing engine val at ="+ (UserPrefs.currentVehicle-1));
//			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineTotalUpgradeLevel){
//				GameObject.FindGameObjectWithTag("btnUpgradeEngine").SetActive(false);
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text ="0";
//			}
//			else
//			{
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
//				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ].ToString();
//			}	
		}
		else
		{
			GameManager.Instance.ChangeState(GameManager.GameState.OUTOFCOINSENGINEUPGRADE);
		}
		
	}
	

	void UpgradeTires(){
		Debug.Log("upgrade tires ");
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ];
		//int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice;
		Debug.Log("coinsRequire"+coinsRequire);
		if(UserPrefs.totalCoins >= coinsRequire)
		{
			GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMTYRESUPGRADE);
//			GameManager.Instance.SubtractCoins(coinsRequire);
//			GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
//			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel++;
//			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresTotalUpgradeLevel){
//				GameObject.FindGameObjectWithTag("btnUpgradeTires").SetActive(false);
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text ="0";
//			}
//			else
//			{
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
//				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ].ToString();
//			}	
		}
		else
		{
			GameManager.Instance.ChangeState(GameManager.GameState.OUTOFCOINSTYRESUPGRADE);
		}
//		SaveandLoad.Save();
	}
	
	
	void UpgradeSteering(){
		Debug.Log("upgrade steering ");
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins >= coinsRequire)
		{
			GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMSTEERINGUPGRADE);
//			GameManager.Instance.SubtractCoins(coinsRequire);
//			GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
//			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel++;
//			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringTotalUpgradeLevel){
//				GameObject.FindGameObjectWithTag("btnUpgradeSteering").SetActive(false);
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel.ToString();
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text ="0";
//			}
//			else
//			{
//				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel.ToString();
//				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ].ToString();
//			}	
		}
		else
		{
			GameManager.Instance.ChangeState(GameManager.GameState.OUTOFCOINSSTEERINGUPGRADE);
		}
//		SaveandLoad.Save();
	}

	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
			
		
	}
	 static void updateCoins()
	{
		UpgradeMenuLocalize upgradeLocalize = GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>() as UpgradeMenuLocalize;	
		upgradeLocalize.updateCoions();
	}
	
	public static void purchaseEngineUpgrade()
	{
			int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ];
			GAManager.Instance.LogDesignEvent("engineUpgrade");
			GameManager.Instance.SubtractCoins(coinsRequire);
			//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel++;
			Debug.Log("Incrementing engine val at ="+ (UserPrefs.currentVehicle-1));
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeEngine").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel.ToString();
				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ].ToString();
			}	
		SaveandLoad.Save();
	}
	
	
	public static void purchaseBrakeUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ];
		GAManager.Instance.LogDesignEvent("brakeUpgrade");
		GameManager.Instance.SubtractCoins(coinsRequire);
			//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeBrakes").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel.ToString();
				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ].ToString();
			}	
		SaveandLoad.Save();
	}
	
	public static void purchaseTyresUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ];
		GAManager.Instance.LogDesignEvent("tyresUpgrade");
		GameManager.Instance.SubtractCoins(coinsRequire);
		//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeTires").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel.ToString();
				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ].ToString();
			}	
		SaveandLoad.Save();
	}
	
	
	public static void purchaseSteerUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ];
		GAManager.Instance.LogDesignEvent("steeringUpgrade");
		GameManager.Instance.SubtractCoins(coinsRequire);
		//	GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel == VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeSteering").SetActive(false);
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel.ToString();
				//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ].ToString();
			}	
		SaveandLoad.Save();
	}
}
