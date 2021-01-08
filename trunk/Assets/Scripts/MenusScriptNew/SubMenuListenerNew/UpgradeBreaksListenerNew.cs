using UnityEngine;
using System.Collections;

public class UpgradeBreaksListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnClose")){
			Debug.Log("btnClose Pressed");


			GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();	
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
			GameManager.Instance.SetPreviousGameState(previous);
		}
		
		if(this.name.Equals("btnUnlock")){
			Debug.Log("btnUnlock Pressed");
				if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSBRAKESUPGRADE)
			{
				GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
				GameManager.Instance.SetPreviousGameState(previous);
			}
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMBRAKESUPGRADE)
			{
				
				VehicleUpgradeMenuListener.purchaseBrakeUpgrade();
				GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
				GameManager.Instance.SetPreviousGameState(previous);
			}
			
			
		}
	}
}
