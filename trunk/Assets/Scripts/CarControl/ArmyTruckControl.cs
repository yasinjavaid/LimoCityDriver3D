using UnityEngine;
using System.Collections;

public class ArmyTruckControl : MonoBehaviour {
	
	public Transform brakeLights = null;
	public Transform reverseLights = null;
	
	public WheelCollider WCWheelRL;
	public WheelCollider WCWheelRR;
	public WheelCollider WCWheelML;
	public WheelCollider WCWheelMR;
	public WheelCollider WCWheelFL;
	public WheelCollider WCWheelFR;
	 
	public Transform wheelFL;
	public Transform wheelFR;
	public Transform wheelML;
	public Transform wheelMR;
	public Transform wheelRL;
	public Transform wheelRR;
	
	private float steer_max = 30;
	private int STEER_Constant = 30;
	public int motor_max= 25; 
	public int brake_max = 20;
	int steerSpeed = 40; 
	 
	private int steer = 0;
	public  int forward = 0;
	public  int back= 0;
	private bool  brakeRelease= false;
	private int motor = 0;
	private int brake = 0;
	private float speed= 0;
	private bool isLevelFinished = false;
	
	//for Parking indicator
	bool isParkingLotIndicator = false;
	Vector3 preCarPostion ;
	private GameObject emptyBody;
	private bool isLevelFailOrComplete = false; // false means level fail
	
	void  Start (){
		
		steer = 0;
		forward = 0;
		back = 0;
		motor = 0;
		brake = 0;
		isParkingLotIndicator = false;
		rigidbody.centerOfMass = new Vector3 (0, 0, 0);
		isLevelFinished = false;
		emptyBody = GameObject.Find("EmptyBody");
	}

	 void Update()
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

 
	void  FixedUpdate (){
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			if(rigidbody.isKinematic){
				this.AddPhysics();
			}
			if(Steer.forward)
			{
				forward = 1;
				back = 0;
				
			}
			if(Steer.back)
			{
				forward = 0;
				back = 1;
				
			}
			
			if(!Steer.back && !Steer.forward)
			{
				forward = 0;
				back = 0;
				
			}
		
			//for steering
			if(UserPrefs.accelerometerFactor == 0){
				steer_max =	(Steer.timer * STEER_Constant ) / Steer.maxMovementTimer ;
			}
			//for Accelerometer
			else if (UserPrefs.accelerometerFactor == 1)
			{
				steer_max = (Steer.maxMovementTimer/1.2f * Mathf.Clamp(Input.acceleration.x,-0.7f,0.7f)) * STEER_Constant;
			}
			//for Arrows
			else{
				steer_max = 30;
			}
			
			
			if(steer_max < 0)
			steer_max = steer_max * -1;
			
		 
			speed = rigidbody.velocity.sqrMagnitude;
			
			//for Accelerometer
			if(UserPrefs.accelerometerFactor==1){
			
				if(Input.acceleration.x < -0.001f || Input.acceleration.x > 0.001f)
				{
					if(Input.acceleration.x < 0)
					{
						steer = -1;
					}
					else if(Input.acceleration.x > 0)
					{
						steer = 1;
					}
				}
				else
				{
					steer = 0;
				}	
			}
			//for Left right Arrow
			else if(UserPrefs.accelerometerFactor==2){
			
				if(RightLeftControl.move != 0)
				{
					if(RightLeftControl.move < 0)
					{
						steer = -1;
					}
					else if(RightLeftControl.move > 0)
					{
						steer = 1;
					}
				}
				else
				{
					steer = 0;
				}
			}
			//for Steering
			else{
				if(Steer.timer != 0)
				{
					if(Steer.timer < 0)
					{
						steer = -1;
					}
					else if(Steer.timer > 0)
					{
						steer = 1;
					}
				}
				else
				{
					steer = 0;
				}
			}	
		 
			if(speed == 0 && forward == 0 && back == 0) 
			{
				brakeRelease = true;
			}
			 
			if(speed == 0 && brakeRelease)
			{
			}
			if(Steer.brake)
			{	
				brakeLights.renderer.enabled = true;
				brake = 1;
			}
			else
			{
				brakeLights.renderer.enabled = false;
				if(Steer.reverse)
				{
					reverseLights.renderer.enabled = true;
					motor = -1 * back;
					brake = forward;
				}
				else
				{
					reverseLights.renderer.enabled = false;
					motor = forward;
					brake = back;
				}
				if (brake > 0 ) 
				{ 
					brakeRelease = false; 
				}
			}
		 
			WCWheelRL.motorTorque = motor_max * motor;
			WCWheelRR.motorTorque = motor_max * motor;
			WCWheelML.motorTorque = motor_max * motor;
			WCWheelMR.motorTorque = motor_max * motor;
			
			WCWheelRL.brakeTorque = brake_max * brake;
			WCWheelRR.brakeTorque = brake_max * brake;
			WCWheelML.brakeTorque = brake_max * brake;
			WCWheelMR.brakeTorque = brake_max * brake;
		 
			if ( steer == 0 && WCWheelFL.steerAngle != 0) 
			{
				if (Mathf.Abs(WCWheelFL.steerAngle) <= (steerSpeed * Time.deltaTime)) 
				{
					WCWheelFL.steerAngle = 0;
				} 
				else if (WCWheelFL.steerAngle > 0) 
				{
					WCWheelFL.steerAngle = WCWheelFL.steerAngle - (steerSpeed * Time.deltaTime);
				} 
				else
				{
					WCWheelFL.steerAngle = WCWheelFL.steerAngle + (steerSpeed * Time.deltaTime);
				}
			} 
			else 
			{
				WCWheelFL.steerAngle = WCWheelFL.steerAngle + (steer * steerSpeed * Time.deltaTime);
				
				if (WCWheelFL.steerAngle > steer_max) 
				{ 
					WCWheelFL.steerAngle = steer_max; 
				}
				if (WCWheelFL.steerAngle < -1 * steer_max) 
				{ 
					WCWheelFL.steerAngle = -1 * steer_max; 
				}
			}
			
			WCWheelFR.steerAngle = WCWheelFL.steerAngle;
			wheelFL.localEulerAngles = new Vector3 (wheelFL.localEulerAngles.x,WCWheelFL.steerAngle,wheelFL.localEulerAngles.z);//WCWheelFL.steerAngle;
			wheelFR.localEulerAngles = new Vector3 (wheelFR.localEulerAngles.x,WCWheelFR.steerAngle,wheelFR.localEulerAngles.z);//WCWheelFR.steerAngle;
		 	
			wheelFR.Rotate(WCWheelFR.rpm * 6 * Time.deltaTime, 0, 0);
			wheelFL.Rotate(WCWheelFL.rpm * 6 * Time.deltaTime, 0, 0);
			wheelRR.Rotate(WCWheelRR.rpm * 6 * Time.deltaTime, 0, 0);
			wheelRL.Rotate(WCWheelRL.rpm * 6 * Time.deltaTime, 0, 0);
			wheelMR.Rotate(WCWheelMR.rpm * 6 * Time.deltaTime, 0, 0);
			wheelML.Rotate(WCWheelML.rpm * 6 * Time.deltaTime, 0, 0);	
		}
		else{
			if(!rigidbody.isKinematic){
				this.RemovePhysics();
			}
		}
		
			
	}
	


	void  OnTriggerEnter (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			this.AddParkingIndicator();
		}
		if(collisionInfo.name=="ParkingLot"){
			
			AddParkingIndicator();
		}
	}
	void  OnTriggerStay (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
			this.ResetParkingIndicatorValues();
		}
		else if(collisionInfo.name=="ParkingLot"){
			this.AddParkingIndicator();
			float distanceDifference = 0.5f;
			float yAngleParking  = Mathf.Abs(GameObject.Find("ParkingLot").transform.eulerAngles.y);
			float yAngleCar =  Mathf.Abs(this.gameObject.transform.eulerAngles.y-270);
			float differnece = Mathf.Abs(yAngleParking - yAngleCar);
			if(differnece>110){
				differnece = 180-differnece;
			}
			if(differnece>-10 && differnece<25){
				if(GameObject.Find("ParkingLot")){
					float distance  = Vector3.Distance(GameObject.Find("ParkingLot").transform.position,this.gameObject.transform.position);
					Debug.Log("distance " + distance);
					distance = distance/20.0f;
					Debug.Log("distance 9.0f " + distance);
					UserPrefs.parkingLotLoadingValue = 1.2f-distance;
					Debug.Log("UserPrefs.parkingLotLoadingValue " + UserPrefs.parkingLotLoadingValue);
					if(distance<distanceDifference){
						float carMoved = Vector3.Distance(preCarPostion,this.gameObject.transform.position);
						if(carMoved<.005){
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
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
			
			GameManager.Instance.ChangeState(GameManager.SoundState.APPLAUSESOUND ,GameManager.GameState.CAMERAROTATION);
			isLevelFailOrComplete = true;
			isLevelFinished = true;
			this.ResetParkingIndicatorValues();
			UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
			GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
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
			Destroy ( GameObject.FindGameObjectWithTag ("ParkStatus")) ;
			isParkingLotIndicator = false;
		}
		UserPrefs.parkingLotLoadingValue = 0;
	}
	private void RemovePhysics(){
		rigidbody.isKinematic = true;
	}
	private void AddPhysics(){
		rigidbody.isKinematic = false;
	}
}