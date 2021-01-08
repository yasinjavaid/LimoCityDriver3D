using UnityEngine;
using System.Collections;
using System;

public class FuelTimer : MonoBehaviour {
		public float time ;
	// Use this for initialization
	void Start () {
		int carFuelwithUpgrade = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR;
		if(UserPrefs.currentEpisode==1)
		{
			switch(UserPrefs.currentLevel)
			{
			case 1:
				break;
			case 2:
				carFuelwithUpgrade+=20;
				break;
			case 3:
				carFuelwithUpgrade+=100;
				break;
			case 4:
				carFuelwithUpgrade+=135;
				break;
			default:
				break;
			}
		}
		
		time = carFuelwithUpgrade;
		Invoke("InitiatePopup",1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY)
		{
			this.SetTimer();
			UserPrefs.remainingtTimeForCurrentLevel = (Math.Truncate(1 * time) / 1).ToString();
			
		}
	}
	void InitiatePopup()
	{
		GameManager.Instance.ChangeState(GameManager.GameState.PICKPASSENGERINSTRUCTIONS);
	}
	public bool isFuelUpgrade()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().additionalUpgradeSelection.Equals("Fuel",System.StringComparison.InvariantCultureIgnoreCase))
		{
			// upgrade fuel here
			return true;
		}
		return false;
	}
	public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}
		
	private void SetTimer(){
		time= time-Time.deltaTime;
		
		float timerAngle;
		if(time>0){
			
			if(isNewMenu() && isFuelUpgrade())
			{
				int carFuelwithUpgrade = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR;
				timerAngle=270+(180f-((180f/carFuelwithUpgrade)*time));			
			}
			else
			{
				 timerAngle = 270+(180f-((180f/Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1])*time));
			}
			//timerSprite.transform.eulerAngles = new Vector3(0,0,timerAngle);
		}else{
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.TIMEOVER);
		}
	}
	public void AddTime(float timeToAdd)
	{
  
  		if(this.gameObject.name=="btnSpots")
		{
 		  time = time + timeToAdd;
  		}
 	}
	
	
}
