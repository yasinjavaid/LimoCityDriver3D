using UnityEngine;
using System.Collections;

public class SaveandLoad : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void Save ( )
	{	
		Debug.Log("Saving at index"+(UserPrefs.currentVehicle-1));
		Debug.Log(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel);
	//	for (int i = 0; i<VehicleManager.vehicleArray.Length; i++){
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleArraybrakeCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel);
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleArrayengineCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel);
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleArraysteeringCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel);
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleArraytiresCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel);
			
	//	}
		PreviewLabs.PlayerPrefs.SetInt("totalCoins",UserPrefs.totalCoins);
		PreviewLabs.PlayerPrefs.Flush ( ) ;
		Debug.Log("ASfter"+VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel);	
	}
	
	
	public static void Load ( )
	{
			Debug.Log("loading from index"+(UserPrefs.currentVehicle-1));
		//for (int i = 0; i<VehicleManager.vehicleArray.Length; i++){
		//	Debug.Log("Loading here  =" +VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].brakeCurrentUpgradeLevel);
			
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArraybrakeCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel);
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArrayengineCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel);
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArraysteeringCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel );
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArraytiresCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel );
			
		//}
		UserPrefs.totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",UserPrefs.totalCoins);
		
	}
}
