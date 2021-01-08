using UnityEngine;
using System.Collections;

public class VehicleManager : MonoBehaviour {
	public static VehicleClass.Vehicle []vehicleArray;
	// Use this for initialization
	void Awake () {
		vehicleArray = new VehicleClass.Vehicle[4];
	
		 vehicleArray[0] = new VehicleClass.Vehicle(
			1000,
			85,
			1,
			1,
			1,
			1,
			10,
			10,
			10,
			10,
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500}
		);
		
		vehicleArray[1] = new VehicleClass.Vehicle(
			1000,
			115,
			1,
			1,
			1,
			1,
			10,
			10,
			10,
			10,
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500}
		);
		
		
		vehicleArray[2] = new VehicleClass.Vehicle(
			1000,
			135,
			1,
			1,
			1,
			1,
			10,
			10,
			10,
			10,
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500}
		);
		
		vehicleArray[3] = new VehicleClass.Vehicle(
			1000,
			155,
			1,
			1,
			1,
			1,
			10,
			10,
			10,
			10,
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500},
			new int[10]{1500,1500,1500,1500,1500,1500,1500,1500,1500,1500}
		);
		
		
	//	int price, int engineUpgradeLevel, int steeringUpgradeLevel, int brakeUpgradeLevel, int tiresUpgradeLevel, 
	//		int []engineUpgradePrice , int []steeringUpgradePrice, int []brakeUpgradePrice, int []tiresUpgradePrice
			
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
