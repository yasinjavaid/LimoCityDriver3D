using UnityEngine;
using System.Collections;

public class UnlockVehicleMenuListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnClose")){
			//Uncomment during final integration
		//	Destroy(GameObject.FindGameObjectWithTag("unlockVehicleMenu"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			
		}
		
		if(this.name.Equals("btnUnlock")){
			Debug.Log("UnlockVehicleMenuListenerNew btnUnlock Pressed"+UserPrefs.currentFontVehicle);
			//Destroy(GameObject.FindGameObjectWithTag("unlockVehicleMenu"));
			if(UserPrefs.currentFontVehicle == 0){
			
			}
			else if(UserPrefs.currentFontVehicle == 1){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().UnlockVehicle(3);
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().updateOverlay();
			}
			else if (UserPrefs.currentFontVehicle == 2){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().UnlockVehicle(2);
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().updateOverlay();
			}
			else{				

				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite4();
			}			
			VehicleSelectionMenuListenerNew vehicleMenu = GameObject.Find("Vehicle1").GetComponent<VehicleSelectionMenuListenerNew>() as VehicleSelectionMenuListenerNew;
			vehicleMenu.setVehicleCoinsPanel();
//			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
			
			
			
	}
	
}
