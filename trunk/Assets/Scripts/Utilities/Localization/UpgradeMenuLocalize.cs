using UnityEngine;
using System.Collections;

public class UpgradeMenuLocalize : MonoBehaviour {
	
	
	
	public UILabel lbBack;
	public UILabel lbNext;
	public UILabel lbCoins;
	public UILabel lbSettings;
	public UILabel lbSelectLevel;
	public UILabel lbGetCoins;
	
	
	
	public UILabel lbCostEngine;
	public UILabel lbEngineCurrentUpgradeCost;
	public UILabel lbEngine;
	public UILabel lbEngineOf;
	public UILabel lbEngineCurrentUpgradeValue;
	public UILabel lbEngineTotalUpgradeValue;
	public UILabel lbEngineUpgrade;
	public UILabel lbtitleEngine;
	

	public UILabel lbCostTires;
	public UILabel lbTiresCurrentUpgradeCost;
	public UILabel lbTires;
	public UILabel lbTiresOf;
	public UILabel lbTiresCurrentUpgradeValue;
	public UILabel lbTiresTotalUpgradeValue;
	public UILabel lbTiresUpgrade;
	public UILabel lbtitleTires;
	
	
	
	public UILabel lbCostSteering;
	public UILabel lbSteeringCurrentUpgradeCost;
	public UILabel lbSteering;
	public UILabel lbSteeringOf;
	public UILabel lbSteeringCurrentUpgradeValue;
	public UILabel lbSteeringTotalUpgradeValue;
	public UILabel lbSteeringUpgrade;
	public UILabel lbtitleSteering;
	
	
	public UILabel lbCostBrakes;
	public UILabel lbBrakesCurrentUpgradeCost;
	public UILabel lbBrakes;
	public UILabel lbBrakesOf;
	public UILabel lbBrakesCurrentUpgradeValue;
	public UILabel lbBrakesTotalUpgradeValue;
	public UILabel lbBrakesUpgrade;
	public UILabel lbtitleBrakes;
	

	
	// Use this for initialization
	void Start () {
	
		SaveandLoad.Load();
		
		lbBack.text =  Localization.instance.Get("Level");   
		lbNext.text = Localization.instance.Get("START");  
		lbCoins.text = Localization.instance.Get("Coins"); 
		lbSettings.text = Localization.instance.Get("Settings");
		lbSelectLevel.text = Localization.instance.Get("SelectLevel");    
		lbGetCoins.text = Localization.instance.Get("GetCoins");
		lbCostBrakes.text =Localization.instance.Get("CostBrakes");
		lbBrakes.text = Localization.instance.Get("Brakes");
		lbBrakesOf.text = Localization.instance.Get("Of");
		lbBrakesUpgrade.text = Localization.instance.Get("Upgrade");
		lbtitleBrakes.text = Localization.instance.Get("titleBrakes");
		lbCostSteering.text = Localization.instance.Get("CostBrakes");
		lbSteering.text = Localization.instance.Get("Steering");
		lbSteeringOf.text = Localization.instance.Get("Of");
		lbSteeringUpgrade.text = Localization.instance.Get("Upgrade");
		lbtitleSteering.text = Localization.instance.Get("titleSteering");
		lbCostTires.text = Localization.instance.Get("CostBrakes");
		lbTires.text = Localization.instance.Get("Tires");
		lbTiresOf.text = Localization.instance.Get("Of");
		lbTiresUpgrade.text = Localization.instance.Get("Upgrade");
		lbtitleTires.text = Localization.instance.Get("titleTires");
		lbCostEngine.text = Localization.instance.Get("CostBrakes");
		lbEngine.text = Localization.instance.Get("Engine");
		lbEngineOf.text = Localization.instance.Get("Of");
		lbEngineUpgrade.text = Localization.instance.Get("Upgrade");
		lbtitleEngine.text = Localization.instance.Get("titleEngine");
//		Debug.LogError("ConstantsNew.CURRENT_VEHICLE="+ConstantsNew.CURRENT_VEHICLE);
		lbBrakesCurrentUpgradeCost.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].brakeUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel-1].ToString();   
		lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].brakeCurrentUpgradeLevel.ToString();
		lbBrakesTotalUpgradeValue.text= VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].brakeTotalUpgradeLevel.ToString();
		
		lbSteeringCurrentUpgradeCost.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].steeringUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel-1].ToString();   
		lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].steeringCurrentUpgradeLevel.ToString();
		lbSteeringTotalUpgradeValue.text=  VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].steeringTotalUpgradeLevel.ToString();
		
		
		lbTiresCurrentUpgradeCost.text =VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel-1].ToString();   
		lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel.ToString();
		lbTiresTotalUpgradeValue.text=  VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresTotalUpgradeLevel.ToString();
		
		lbEngineCurrentUpgradeCost.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].engineUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel-1].ToString();   
		//lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].engineCurrentUpgradeLevel.ToString();
		Debug.Log("aaa="+VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].engineCurrentUpgradeLevel.ToString());
		lbEngineTotalUpgradeValue.text=  VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].engineTotalUpgradeLevel.ToString();
		lbCoins.text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void updateCoions(){
		Debug.LogError("Coins updated");
		lbCoins.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}
}
