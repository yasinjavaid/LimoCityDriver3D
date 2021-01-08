using UnityEngine;
using System.Collections;

public class CarControlBack : MonoBehaviour {
	
	private bool isLevelFinished = false;
	
	void  OnCollisionEnter (Collision collisionInfo){
		
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
			Debug.Log("---------------"+collisionInfo.gameObject.name);
			if(collisionInfo.gameObject.tag!= "MainBase"){
				GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CAMERAROTATION);
				isLevelFinished = true;
			}
		}
	}
}