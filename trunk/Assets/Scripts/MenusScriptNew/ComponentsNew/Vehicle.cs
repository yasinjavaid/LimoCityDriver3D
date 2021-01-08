using UnityEngine;
using System.Collections;

public class VehicleClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public class Vehicle
	{
		
		public int price;
		public int carFuel;
		public int engineCurrentUpgradeLevel;
		public int steeringCurrentUpgradeLevel;
		public int brakeCurrentUpgradeLevel;
		public int tiresCurrentUpgradeLevel;
		public int engineTotalUpgradeLevel;
		public int steeringTotalUpgradeLevel;
		public int brakeTotalUpgradeLevel;
		public int tiresTotalUpgradeLevel;
		public int []engineUpgradePrice;
		public int []steeringUpgradePrice;
		public int []brakeUpgradePrice;
		public int []tiresUpgradePrice;
			
		
		public Vehicle(int price,int fuel, int engineCurrentUpgradeLevel, int steeringCurrentUpgradeLevel, int brakeCurrentUpgradeLevel, int tiresCurrentUpgradeLevel, 
			int engineTotalUpgradeLevel, int steeringTotalUpgradeLevel, int brakeTotalUpgradeLevel, int tiresTotalUpgradeLevel, 
			int []engineUpgradePrice , int []steeringUpgradePrice, int []brakeUpgradePrice, int []tiresUpgradePrice
			
			){
			
				this.carFuel=fuel;
				this.price = price;
				this.engineCurrentUpgradeLevel = engineCurrentUpgradeLevel;
				this.steeringCurrentUpgradeLevel = steeringCurrentUpgradeLevel;
				this.brakeCurrentUpgradeLevel = brakeCurrentUpgradeLevel;
				this.tiresCurrentUpgradeLevel = tiresCurrentUpgradeLevel;
				this.engineTotalUpgradeLevel = engineTotalUpgradeLevel;
				this.steeringTotalUpgradeLevel = steeringTotalUpgradeLevel;
				this.brakeTotalUpgradeLevel = brakeTotalUpgradeLevel;
				this.tiresTotalUpgradeLevel = tiresTotalUpgradeLevel;
				this.engineUpgradePrice = new int[engineUpgradePrice.Length];
				this.steeringUpgradePrice = new int[steeringUpgradePrice.Length];
				this.brakeUpgradePrice = new int[brakeUpgradePrice.Length];
				this.tiresUpgradePrice = new int[tiresUpgradePrice.Length];
				for(int i = 0; i<engineUpgradePrice.Length; i++){
					this.engineUpgradePrice[i] = engineUpgradePrice[i];
					this.steeringUpgradePrice[i] = steeringUpgradePrice[i];
					this.brakeUpgradePrice[i] = brakeUpgradePrice[i];
					this.tiresUpgradePrice[i] = tiresUpgradePrice[i];
					
				}
			
			
		}
		
		
		
		
	}
	




}
