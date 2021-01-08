using UnityEngine;
using System.Collections;

public class ParkingLot : MonoBehaviour {
	
	public int parkingLotID = 0;
	
	private GameObject passengers = null;
	private  Animator animator;

	public void StartLoadingPassengers(){		
		
		passengers = GameObject.FindGameObjectWithTag("Passenger");		
		
		if(passengers != null)
		{
			
			Steer.brake = true;
			Invoke("passengerStartWalking", 5.0f);		
			
		}
	}
	
	private void passengerStartWalking()
	{
		PassengerControl passengerControl = (PassengerControl)passengers.GetComponent("PassengerControl");
		passengerControl.startWalking();
		
	}
	
	/// <summary>

	private void changeDoorsStates(){
//		GameManager.Instance.ChangeState(GameManager.SoundState.DOORCLOSESOUND, GameManager.GameState.DOORCLOSED);		
		
		Invoke("checkLevelCompleteState", 5.0f);
	}
	
	private void checkLevelCompleteState(){
		
		Steer.brake = false;
		
		if(UserPrefs.totalParkingLot < 1){
			GameObject.FindGameObjectWithTag("Player").SendMessage("LevelComplete");	
		} else {
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);		
		}
	}
	
	
			
}
