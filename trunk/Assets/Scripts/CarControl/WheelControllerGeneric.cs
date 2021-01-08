 using UnityEngine;
using System.Collections;

public class WheelControllerGeneric : MonoBehaviour {
	
	public Texture brakeLightsLeft ;
	public Texture brakeLightsRight ;
	public Texture leftPakingLights;
	public Texture rightPakingLights;
	private Texture leftLights;
	private Texture rightLights;
	private GameObject brakeLeft;
	private GameObject brakeRight;
	
	public Transform vehicleTyres;
	public Transform vehicleTyresColliders;
	public Transform steerLeftTyreCollider;
	public Transform steerLeftTyre;
	public Transform steerRightTyreCollider;
	public Transform steerRightTyre;
	
//	public WheelCollider[] wheelColliders;
	public WheelCollider[] workingWheelColliders;
	public WheelCollider[] nonWorkingWheelColliders;
//	public Transform[] wheelsTransform;
	public Transform[] workingWheelsTransform;
	public Transform[] nonWorkingWheelsTransform;
	
	
	
//	public WheelCollider WCWheelRL;
//	public WheelCollider WCWheelRR;
//	public WheelCollider WCWheelFL;
//	public WheelCollider WCWheelFR;
//	public WheelCollider WCWheelML;
//	public WheelCollider WCWheelMR;
//	
//	public Transform wheelFL;
//	public Transform wheelFR;
//	public Transform wheelRL;
//	public Transform wheelRR;
//	public Transform wheelML;
//	public Transform wheelMR;
	
	private float steer_max = 30;
	private int STEER_Constant = 30;
	private float motor_max= 12; 
	private int brake_max = 80;
	int steerSpeed = 30; 
	 
	private int steer = 0;
	public  int forward = 0;
	public  int back= 0;
	private bool  brakeRelease= false;
	private int motor = 0;
	private int brake = 0;
	private float speed= 0;
	private float blinkingTime= 0;
	private bool parkingLightStatus= false;
	private bool isLevelFinished = false;
	
	//for Parking indicator
	bool isParkingLotIndicator = false;
	Vector3 preCarPostion ;
	private GameObject emptyBody;
	private bool isLevelFailOrComplete = false; // false means level fail
	
	
	void Awake ()
	{
		GameManager.Instance.ChangeState(GameManager.GameState.GAMEPLAY);
		//UserPrefs.currentLevel=1;
	}
	
	void  Start (){
		
		InitializeVehicleTyresAndColliders();
		UserPrefs.totalParkingLot = Constants.totalParkingLot[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];
		steer = 0;
		forward = 0;
		back = 0;
		motor = 0;
		brake = 0;
		isParkingLotIndicator = false;
		rigidbody.centerOfMass = new Vector3 (0, 0, 0);
		isLevelFinished = false;
		emptyBody = GameObject.Find("EmptyBody");
		brakeLeft=GameObject.FindGameObjectWithTag("LeftBrake");
		brakeRight=GameObject.FindGameObjectWithTag("RightBrake");
		leftLights=brakeLeft.renderer.material.mainTexture;
		rightLights=brakeRight.renderer.material.mainTexture;
		
		this.BusSpeed();
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
		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PARKED)
		{
			ActivateParkinglights();
		}
	}

 
	void  FixedUpdate (){
	
		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.GAMEPLAY)
		{
			if(rigidbody.isKinematic){
				this.AddPhysics();
			}
			else if(HudMenuListenerNew.forward)
			{
				
				forward = 1;
				back = 0;
			
			}
			else if(HudMenuListenerNew.back)
			{
				forward = 0;
				back = 1;
				
			}
			else if(!HudMenuListenerNew.back && !HudMenuListenerNew.forward)
			{
				forward = 0;
				back = 0;

			}
		
			//for steering
			if(UserPrefs.accelerometerFactor == 0){
				steer_max =	(Steer.timer * STEER_Constant ) / Steer.maxMovementTimer ;
				
			}
			//for Arrows
			else{
				steer_max = 30;
			}
			if(isNewMenu())
			{
				setSteerMax();
				
			}
			if(steer_max < 0)
			steer_max = steer_max * -1;
			
		 
			speed = rigidbody.velocity.sqrMagnitude;
			
	
			//for Accelerometer
			if(UserPrefs.accelerometerFactor==1)
			{
				steer_max = (Steer.maxMovementTimer/1.2f * Mathf.Clamp(Input.acceleration.x,-0.7f,0.7f)) * STEER_Constant;
				
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
			
				if(HudMenuListenerNew.move != 0)
				{
					if(HudMenuListenerNew.move < 0)
					{
						steer = -1;
					}
					else if(HudMenuListenerNew.move > 0)
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
			if(HudMenuListenerNew.brake)
			{	
				brakeLeft.renderer.material.mainTexture =brakeLightsLeft; 
				brakeRight.renderer.material.mainTexture =brakeLightsRight; 
				brake = 1;
			}
			else
			{
				brakeLeft.renderer.material.mainTexture =leftLights; 
				brakeRight.renderer.material.mainTexture =rightLights; 
				if(HudMenuListenerNew.reverse)
				{
					
					motor = -1 * back;
					brake = forward;
				}
				else
				{
				//	brakeLights.renderer.enabled = false;
					motor = forward;
					brake = back;
				}
				if (brake > 0 ) 
				{ 
					brakeRelease = false; 
				}
			}
		 
			
			ApplyMotorTorqueOnTyres();
			ApplyBrakeTorqueOnTyres();

			ApplySteeringControl();
	
			RotateWheels();
		}
		else{
			if(!rigidbody.isKinematic){
				Invoke("RemovePhysics",1);
			}
		}
		
			
	}
	


	void  OnTriggerEnter (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			if(collisionInfo.name=="ParkingLot"){
				this.AddParkingIndicator();
			}
		}
	}
	void  OnTriggerStay (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
			this.ResetParkingIndicatorValues();
		}
		else if(collisionInfo.name=="ParkingLot"){
			this.AddParkingIndicator();
			float distanceDifference = 0.45f;
			float yAngleParking  = Mathf.Abs(collisionInfo.gameObject.transform.eulerAngles.y);
			float yAngleCar =  Mathf.Abs(this.gameObject.transform.eulerAngles.y);
			float differnece = Mathf.Abs(yAngleParking - yAngleCar);
		//	Debug.Log("differnece before" + differnece);
			if(differnece>110 && differnece < 340){
				differnece = 180-differnece;
			}
			else if(differnece >= 340 ){
				differnece = 360-differnece;
			}
		//	Debug.Log("differnece " + differnece);
			if(differnece>-10 && differnece<25){
				if(collisionInfo.gameObject.name=="ParkingLot"){
					float distance  = Vector3.Distance(collisionInfo.gameObject.transform.position,this.gameObject.transform.position);
			//		Debug.Log("distance " + distance);
					distance = distance / 60.0f;
			//		Debug.Log("distance diff 9.0f " + distance);
					UserPrefs.parkingLotLoadingValue = 1.2f-distance;
			//		Debug.Log("UserPrefs.parkingLotLoadingValue " + UserPrefs.parkingLotLoadingValue);
						if(distance<distanceDifference){
							float carMoved = Vector3.Distance(preCarPostion,this.gameObject.transform.position);
							TutorialManager.Instance.showPressBrakeIndicator();
							if(carMoved<.005 && HudMenuListenerNew.brake){								
								collisionInfo.transform.position = new Vector3(0.0f,-1000f,0f);
								this.ParkingComplete(collisionInfo.gameObject);       
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
		
		//Debug.Log("---------------"+collisionInfo.gameObject.name);
		//Debug.Log("---------------"+collisionInfo.collider.gameObject.name);
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished){
		//	Debug.LogError("---------saddsaasddsa----------"+collisionInfo.gameObject.tag);
			if(collisionInfo.gameObject.tag!= "MainBase"){
				GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CAMERAROTATION);
				isLevelFailOrComplete = false;
				isLevelFinished = true;
				this.ResetParkingIndicatorValues();
			}
		}
	}
	
	private void ParkingComplete(GameObject parkingLotObj){
	
		if(UserPrefs.totalParkingLot > 1)
		{	
			if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY)
			{
				
				OpenDoors.openDoor=true;
				UserPrefs.currentCameraControl = 9;
				Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
				if(GameObject.FindGameObjectWithTag("Passenger")!=null)
					parkingLotObj.SendMessage("StartLoadingPassengers");
				GameManager.Instance.ChangeState(GameManager.GameState.PARKED);
			}
		}
		else
		{
			if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished)
			{
				
					GameManager.Instance.ChangeState(GameManager.SoundState.APPLAUSESOUND ,GameManager.GameState.CAMERAROTATION);
					isLevelFailOrComplete = true;
					isLevelFinished = true;
					this.ResetParkingIndicatorValues();
					UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
					if(isNewMenu())
				{
					if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode )
					{
						
						UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
						UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
					}
					else
					{
						UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
					}
					GameManager.Instance.AddCoins(ConstantsNew.Coins_Level_Success);
				}
				else
				{
					GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
				}
				
				
				
			}
		}
	}
	
	private void CompleteLevel()
	{
		StartCoroutine(Complete());
	}
	IEnumerator Complete()
	{
		yield return new WaitForSeconds(2);
		OpenDoors.closeDoor=true;
		OpenDoors.openDoor=false;
		yield return new WaitForSeconds(6);
		UserPrefs.currentCameraControl = 1;
		Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
		UserPrefs.totalParkingLot = UserPrefs.totalParkingLot - 1 ;
		this.ResetParkingIndicatorValues();
		UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
		GameManager.Instance.ChangeState(GameManager.SoundState.APPLAUSESOUND ,GameManager.GameState.DROPPASSENGERINSTRUCTIONS);
		
//		if(isNewMenu())
//				{
//					if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode )
//					{
//						
//						UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
//						UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
//					}
//					else
//					{
//						UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
//					}
//					//GameManager.Instance.AddCoins(ConstantsNew.Coins_Level_Success);
//				}
//				else
//				{
//					//GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
//				}
				
				
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
	
	private void BusSpeed(){
		
		switch (UserPrefs.currentVehicle){
			
			case 1: 
				brake_max = 200;
				motor_max= 10;			 	
				break;
			case 2: 
				brake_max = 80;
				motor_max= 20;			 	
				break;
			case 3: 
			 	brake_max = 80;
				motor_max= 8;
				break;
			
			default :
				brake_max = 80;
				motor_max= 20;
				break;
				
			
			
		}
		
		
				if(isNewMenu())
				{
					SetCarSpeed();
					SetCarBrakes();
			
				
//		brake_max=10;
				}
	}
	
	void ActivateParkinglights()
	{
		if(Time.time>blinkingTime && !parkingLightStatus)
		{
				brakeLeft.renderer.material.mainTexture =leftPakingLights; 
				brakeRight.renderer.material.mainTexture =rightPakingLights; 
				blinkingTime=Time.time+1;
				parkingLightStatus=true;
		}
		else if(Time.time>blinkingTime && parkingLightStatus)
		{
			brakeLeft.renderer.material.mainTexture =leftLights; 
			brakeRight.renderer.material.mainTexture =rightLights; 
			blinkingTime=Time.time+1;
			parkingLightStatus=false;
		}
		
	}
	private void InitializeVehicleTyresAndColliders()
	{
//		wheelColliders = new WheelCollider[vehicleTyresColliders.childCount]();
//		wheelsTransform = new Transform[vehicleTyres.childCount]();
		
		int i = 0;
		foreach(Transform tyre in vehicleTyres)
		{
			if(tyre.gameObject.name=="WorkingTyres")
			{
				workingWheelsTransform = new Transform[tyre.childCount];
				
				foreach(Transform workingTyre in tyre)
				{
					workingWheelsTransform[i++]=workingTyre;
				}
			}
			else{
				
				nonWorkingWheelsTransform = new Transform[tyre.childCount];
				
				foreach(Transform nonWorkingTyre in tyre)
				{
					nonWorkingWheelsTransform[i++]=nonWorkingTyre;
				}
			}
			i = 0;
		}
		
		i = 0;
		
		foreach(Transform wheelCollider in vehicleTyresColliders)
		{
			if(wheelCollider.gameObject.name=="WorkingColliders")
			{
				workingWheelColliders = new WheelCollider[wheelCollider.childCount];
				foreach(Transform workingCollider in wheelCollider)
				{
					workingWheelColliders[i++]=workingCollider.gameObject.GetComponent<WheelCollider>();
				}
			}
			else{
				nonWorkingWheelColliders = new WheelCollider[wheelCollider.childCount];
				foreach(Transform nonWorkingCollider in wheelCollider)
				{
					nonWorkingWheelColliders[i++]=nonWorkingCollider.gameObject.GetComponent<WheelCollider>();
				}
			}
			i = 0;
		}
	}
	
	
	
	public void ApplyMotorTorqueOnTyres()
	{
		foreach(WheelCollider workingTyre in workingWheelColliders)
		{
			
//			if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==1)
//			{
//				workingTyre.motorTorque = motor_max * motor;
//			}
//			else
//			{
//				//for new menus
//				Debug.Log("new menus");
//				int currentEngineUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel;
//					motor_max+=2*ConstantsNew.ENGINE_UPGRADE_FACTOR;
					workingTyre.motorTorque = motor_max * motor;
//			}
		}
	}
	
	
	public void ApplyBrakeTorqueOnTyres()
	{
//		Debug.Log("Brake");
		foreach(WheelCollider workingTyre in workingWheelColliders)
		{
//			if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==1)
//			{
//				workingTyre.brakeTorque = brake_max * brake;
//			}
//			else
//			{
//				//for new menus
//				int currentBrakeUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel;
//					brake_max+=2*ConstantsNew.BRAKE_UPGRADE_FACTOR;
					workingTyre.brakeTorque = brake_max * brake;
//			}
		}
	}
	
	public void RotateWheels()
	{
		
		foreach(Transform workingWheels in workingWheelsTransform)
		{
			workingWheels.Rotate(workingWheelColliders[0].rpm * 6 * Time.deltaTime, 0, 0);
		//	Debug.Log("workingWheelColliders[0].rpm"+workingWheelColliders[0].rpm);
		}
		
		foreach(Transform nonWorkingWheels in nonWorkingWheelsTransform)
		{
			nonWorkingWheels.Rotate(nonWorkingWheelColliders[0].rpm * 6 * Time.deltaTime, 0, 0);
		}
		UserPrefs.rpmValue = workingWheelColliders[0].rpm * 6 * Time.deltaTime;
		
	}
	
	
	public void ApplySteeringControl()
	{
		WheelCollider leftWheelCollider = steerLeftTyreCollider.GetComponent<WheelCollider>();
		WheelCollider rightWheelCollider = steerRightTyreCollider.GetComponent<WheelCollider>();
		Transform stLeftTyre=steerLeftTyre.GetComponent<Transform>();
		Transform stRightTyre=steerRightTyre.GetComponent<Transform>();
		if ( steer == 0 && leftWheelCollider.steerAngle != 0) 
			{
				if (Mathf.Abs(leftWheelCollider.steerAngle) <= (steerSpeed * Time.deltaTime)) 
				{
					leftWheelCollider.steerAngle = 0;
				} 
				else if (leftWheelCollider.steerAngle > 0) 
				{
					leftWheelCollider.steerAngle = leftWheelCollider.steerAngle - (steerSpeed * Time.deltaTime);
				} 
				else
				{
					leftWheelCollider.steerAngle = leftWheelCollider.steerAngle + (steerSpeed * Time.deltaTime);
				}
			} 
			else 
			{
				leftWheelCollider.steerAngle = leftWheelCollider.steerAngle + (steer * steerSpeed * Time.deltaTime);
				
				if (leftWheelCollider.steerAngle > steer_max) 
				{ 
					leftWheelCollider.steerAngle = steer_max; 
				}
				if (leftWheelCollider.steerAngle < -1 * steer_max) 
				{ 
					leftWheelCollider.steerAngle = -1 * steer_max; 
				}
			}
			
			rightWheelCollider.steerAngle = leftWheelCollider.steerAngle;
			stLeftTyre.localEulerAngles = new Vector3 (stLeftTyre.localEulerAngles.x,leftWheelCollider.steerAngle,stLeftTyre.localEulerAngles.z);//WCWheelFL.steerAngle;
			stRightTyre.localEulerAngles = new Vector3 (stRightTyre.localEulerAngles.x,rightWheelCollider.steerAngle,stRightTyre.localEulerAngles.z);//WCWheelFR.steerAngle;	 
	}
	
	public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
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
	
	
	void setSteerMax()
	{
		int currentSteeringUpgradeLevel = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel;
				//steer_max=currentSteeringUpgradeLevel*ConstantsNew.STEERING_UPGRADE_FACTOR;
		
		if(currentSteeringUpgradeLevel==1)
		{
			steer_max=4;
		}
		else{
			steer_max=4+(ConstantsNew.STEERING_UPGRADE_FACTOR*(currentSteeringUpgradeLevel-1));
		}
		if(HudMenuListenerNew.stteringBtnPressedTime>0)
		{
		//	Debug.LogError("aslkdj laksdj laksdj alksd jalksdj alkjsd  laksjd lkajsd lakjsd lakjsd stteringBtnPressedTime="+HudMenuListenerNew.stteringBtnPressedTime);
			if(HudMenuListenerNew.stteringBtnPressedTime>15 && steer_max < 24)
			{
				steer_max+=(HudMenuListenerNew.stteringBtnPressedTime/10)*currentSteeringUpgradeLevel;
				if(steer_max>24)
				{
					steer_max=24;
				}
//				Debug.LogError("aslkdj laksdj laksdj alksd jalksdj alkjsd  laksjd lkajsd lakjsd lakjsd steer max="+steer_max);
			
			}
		
		}
		
		
	}
	
	void SetCarSpeed()
	{
	
		int currentEngineUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel;
		if(currentEngineUpgradeLvl==1)
		{
			motor_max=2;
		}
		else
		{
			motor_max=2+(ConstantsNew.ENGINE_UPGRADE_FACTOR*(currentEngineUpgradeLvl-1));
		}
//		motor_max=10;
	}
	
	void SetCarBrakes()
	{
		int currentBrakeUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel;
					
	
		if(currentBrakeUpgradeLvl==1)
		{
			brake_max=12;
		}
		else
		{
			brake_max=12+(ConstantsNew.BRAKE_UPGRADE_FACTOR*(currentBrakeUpgradeLvl-1));
		}
//		brake_max=140;
		
	}
		
	
}