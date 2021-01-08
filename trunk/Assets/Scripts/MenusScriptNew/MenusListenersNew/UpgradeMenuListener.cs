using UnityEngine;
using System.Collections;

public class UpgradeMenuListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnSettings")){
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel >= VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeBrakes").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text ="0";
			}
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel >= VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeEngine").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text ="0";
			}
	
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel >= VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeTires").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text ="0";
			}
	
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel >= VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeSteering").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text ="0";
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		Debug.Log(this);
		
		if(this.name == "btnGetCoins"){
			
			
		}
		else if(this.name == "btBack"){
			MenuManager.Instance.SwitchPreviousMenu();
			
		}
		else if(this.name == "btnNext"){
			MenuManager.Instance.SwitchNextMenu();
			
		}
		else if(this.name == "btnGetCoins"){
			
			
		}
		else if(this.name == "btnSettings"){
			
			
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
		
		
		
		
	//	UpgradeBrake();
	}
	
	
	void UpgradeBrake(){
		Debug.Log("upgrade brake ");
		int coinsRequire = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins > coinsRequire)
		{
			GameManager.Instance.SubtractCoins(coinsRequire);
			GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel == VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeBrakes").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbBrakesCurrentUpgradeCost.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].brakeCurrentUpgradeLevel-1 ].ToString();
			}	
		}
		SaveandLoad.Save();
	}
	
	void UpgradeEngine(){
		Debug.Log("upgrade engine ");
		int coinsRequire = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins > coinsRequire)
		{
			GameManager.Instance.SubtractCoins(coinsRequire);
			GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel == VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeEngine").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbEngineCurrentUpgradeCost.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].engineCurrentUpgradeLevel-1 ].ToString();
			}	
		}
		SaveandLoad.Save();
	}
	

	void UpgradeTires(){
		Debug.Log("upgrade tires ");
		int coinsRequire = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins > coinsRequire)
		{
			GameManager.Instance.SubtractCoins(coinsRequire);
			GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel == VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeTires").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbTiresCurrentUpgradeCost.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].tiresCurrentUpgradeLevel-1 ].ToString();
			}	
		}
		SaveandLoad.Save();
	}
	
	
	void UpgradeSteering(){
		Debug.Log("upgrade steering ");
		int coinsRequire = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel-1 ];
		if(UserPrefs.totalCoins > coinsRequire)
		{
			GameManager.Instance.SubtractCoins(coinsRequire);
			GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
			VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel++;
			if(VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel == VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringTotalUpgradeLevel){
				GameObject.FindGameObjectWithTag("btnUpgradeSteering").SetActive(false);
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text ="0";
			}
			else
			{
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeValue.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel.ToString();
				GameObject.FindGameObjectWithTag("UpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbSteeringCurrentUpgradeCost.text = VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringUpgradePrice[ VehicleManager.vehicleArray[ConstantsNew.CURRENT_VEHICLE-1].steeringCurrentUpgradeLevel-1 ].ToString();
			}	
		}
		SaveandLoad.Save();
	}
}
