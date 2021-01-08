using UnityEngine;
using System.Collections;

public class TankCollisionControl : MonoBehaviour {
	
	//for Parking indicator
	bool isParkingLotIndicator = false;
	Vector3 preCarPostion ;
	private GameObject emptyBody;
	private bool isLevelFailOrComplete = false; // false means level fail
	private bool isLevelFinished = false;
	
	void  Start (){
		isParkingLotIndicator = false;		
		isLevelFinished = false;
		emptyBody = GameObject.Find("EmptyBody");
//		this.BusSpeed();
	}
	
	void Update () 
	{			
		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CAMERAROTATION)
			{
				emptyBody.transform.Rotate(Vector3.down * Time.deltaTime * 50);
				if(Input.GetMouseButtonDown(0))
				{
					if(!isLevelFailOrComplete)
					{
						GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);		
					}
					else
					{
						GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND ,GameManager.GameState.LEVELCOMPLETE);
					}
				}
			}
	}
	
	void  OnTriggerEnter (Collider collisionInfo){

		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			if(collisionInfo.name != "Collider" && collisionInfo.name != "Gun_Geo_Collider")
			{
				Debug.Log("Collider name :: ------" + collisionInfo.name);
				if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
					Debug.Log("---------------"+collisionInfo.gameObject.name);
					if(collisionInfo.name=="ParkingLot"){
						if(!isParkingLotIndicator)
							this.AddParkingIndicator();
					}
					else if(collisionInfo.gameObject.tag!= "MainBase"){
						GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CAMERAROTATION);
						isLevelFailOrComplete = false;
						isLevelFinished = true;
						this.ResetParkingIndicatorValues();
					}
				}
			}		
			
		}
	}
	void  OnTriggerStay (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
			this.ResetParkingIndicatorValues();
		}
		else if(collisionInfo.name=="ParkingLot"){
			if(!isParkingLotIndicator)
				this.AddParkingIndicator();
			float distanceDifference = 0.45f;
			float yAngleParking  = Mathf.Abs(collisionInfo.gameObject.transform.eulerAngles.y);
			float yAngleCar =  Mathf.Abs(this.gameObject.transform.eulerAngles.y);
			float differnece = Mathf.Abs(yAngleParking - yAngleCar);
			Debug.Log("differnece before" + differnece);
			if(differnece>110 && differnece < 340){
				differnece = 180-differnece;
			}
			else if(differnece >= 340 ){
				differnece = 360-differnece;
			}
			Debug.Log("differnece " + differnece);
			if(differnece>-10 && differnece<25){
				if(collisionInfo.gameObject.name=="ParkingLot"){
					float distance  = Vector3.Distance(collisionInfo.gameObject.transform.position,this.gameObject.transform.position);
					Debug.Log("distance " + distance);
					distance = distance / 9.0f;
					Debug.Log("distance 9.0f " + distance);
					UserPrefs.parkingLotLoadingValue = 1.2f-distance;
					Debug.Log("UserPrefs.parkingLotLoadingValue " + UserPrefs.parkingLotLoadingValue);
						if(distance<distanceDifference){
							float carMoved = Vector3.Distance(preCarPostion,this.gameObject.transform.position);
							if(carMoved<.005 && Steer.brake){								
								collisionInfo.transform.position = new Vector3(-40.0f,0.04263139f,0f);
								this.ParkingComplete();       
							}
						}
					preCarPostion = this.gameObject.transform.position;
				}
			}
			else{
				UserPrefs.parkingLotLoadingValue = 0.0f;
			}
		}
		else{
			this.ResetParkingIndicatorValues();
		}
	 }
	void  OnTriggerExit (Collider collisionInfo){
		this.ResetParkingIndicatorValues();
	}
	
	void  OnCollisionEnter (Collision collisionInfo){
		
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
			Debug.Log("---------------"+collisionInfo.gameObject.name);
			if(collisionInfo.gameObject.tag!= "MainBase"){
				GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CAMERAROTATION);
				isLevelFailOrComplete = false;
				isLevelFinished = true;
				this.ResetParkingIndicatorValues();
			}
		}
	}
	
	private void ParkingComplete(){
		if(UserPrefs.totalParkingLot > 1){	
			if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
				UserPrefs.totalParkingLot = UserPrefs.totalParkingLot - 1 ;
				this.ResetParkingIndicatorValues();
				UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.PAUSED);
			}
		} else {
			if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
				GameManager.Instance.ChangeState(GameManager.SoundState.APPLAUSESOUND ,GameManager.GameState.CAMERAROTATION);
				isLevelFailOrComplete = true;
				isLevelFinished = true;
				isParkingLotIndicator = true;
				Debug.Log("+++ --- Completed --- +++");
				this.ResetParkingIndicatorValues();
				this.HideParkingIndicators();
				UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
				GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
			}
		}
	}
	
	private void AddParkingIndicator(){
		if(!isParkingLotIndicator && !isLevelFinished){
			preCarPostion = this.gameObject.transform.position;
			Instantiate(Resources.Load("SubMenus/ParkStatus"));
			isParkingLotIndicator = true;
			UserPrefs.parkingLotLoadingValue = 0;
		}
	}
	
	private void ResetParkingIndicatorValues(){
		if(isParkingLotIndicator){
			isParkingLotIndicator = false;
//			while(GameObject.FindGameObjectWithTag ("ParkStatus") != null){
				Destroy ( GameObject.FindGameObjectWithTag ("ParkStatus")) ;
//			}
		}
		UserPrefs.parkingLotLoadingValue = 0;
	}
	
	private void HideParkingIndicators(){
		GameObject[] pIndicators = GameObject.FindGameObjectsWithTag("ParkStatus");  
		if(pIndicators != null && pIndicators.Length > 0){
			for(int i = 0; i < pIndicators.Length; i++){
				GameObject pInd = pIndicators[i];
				pInd.SetActive(false);				
			}
		}
	}
}
