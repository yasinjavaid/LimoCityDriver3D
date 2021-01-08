using UnityEngine;
using System.Collections;

public class Steer : MonoBehaviour {

	public static bool  forward = false;
	public static bool  brake = false;
	public static bool  reverse = false;
	public static bool  back = false;
	
	Vector2 acceleratorScreenPoint;
	Vector2 brakeScreenPoint;
	Vector2 gearBaseScreenPoint;
	Vector3 gearWorldPoint;
	
	Vector2 steeringScreenPoint;

	
	static bool  isStreeringMoving = false;
	bool  isMobile ;
	Vector2 preXY ;
	Vector2 postXY ;
	int factor;
	public static float timer = 0;
	public static float maxMovementTimer = 1.8f;
	private bool  isRotatingBack = false;
	private bool click= false;
	private Vector2 ignoreMovement ;
	private int isAcceteratorPress; 
	private int isBrakePress;
	private int isSteerClick;
	private Transform acceleratorPosition;
	private Transform brakePosition;
	
	public Texture acceleratorPress;
	public Texture acceleratorRelease;
	public Texture brakePress;
	public Texture brakeRelease;
	public Texture gearReverse;
	public Texture gearDrive;
	
	#region CollidersConstants
		private int steeringColliderConstant = 350;
		private int accerLationColliderConstantX = 71;
		private int accerLationColliderConstantY = 115;
		private int brakeColliderConstantX = 70;
		private int brakeColliderConstantY = 120;
		private int gearColliderConstantX = 60;
		private int gearColliderConstantY = 85;
	#endregion
	public bool isAccelerationPressed;
	private bool isBreakPressed;
	void  Start ( ){
		isMobile = true;
		#if UNITY_EDITOR
			isMobile = false;
		#endif
		isStreeringMoving  = false;
		forward = false;
		brake = false;
		reverse = false;
		back = false;
		isAcceteratorPress = -1;
		isBrakePress = -1;
		timer = 0;
		factor  = 300; 
		isSteerClick = -1;
		isAccelerationPressed = false;
		UserPrefs.isAccelaratorPressed = isAccelerationPressed;
		isBreakPressed = false;
		#if UNITY_IPHONE
			this.SetCameraFOVForIphone();
		#endif
		UserPrefs.accelerometerFactor = 2;
		this.setCameraControls();
		this.SetControls();
		
		
	}

	void Update (){
	
	//	Debug.LogError("isAccelerationPressed"+isAccelerationPressed);
		
		if(isAccelerationPressed){
	//		Debug.LogError(SoundManager.Instance.vehicleEngineSoundSource.volume);
			if(SoundManager.Instance.vehicleEngineSoundSource.volume < 1.0f)
			{
//				Debug.LogError("Increasing");
				BackgroundSoundManager.Instance.backgrpundmusicSource.volume = .1f;
				SoundManager.Instance.vehicleEngineSoundSource.volume +=.025f; 	
			}
		}
		else{
			if(SoundManager.Instance.vehicleEngineSoundSource.volume >.3f){
//				Debug.LogError("Decreasing"+SoundManager.Instance.vehicleEngineSoundSource.volume);
				SoundManager.Instance.vehicleEngineSoundSource.volume -=.025f;
				if(SoundManager.Instance.vehicleEngineSoundSource.volume <.5f){
					BackgroundSoundManager.Instance.backgrpundmusicSource.volume += .025f;	
				}
			}
			
		}
//		Debug.Log(GameManager.Instance.GetCurrentGameState());
		//if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			if(isMobile){
//				Debug.Log("Is mobile");
				if(Input.GetMouseButtonUp(0)){
					CameraRotation.isBtnClicked = false;
				}
				if(UserPrefs.accelerometerFactor == 0)
					this.ForMobileSteerMoving();
				this.ForMobileMovingControls();
			}
			else{
//				Debug.Log("Computer");
				if(Input.touchCount==0){
					CameraRotation.isBtnClicked = false;
				}
//				Debug.Log(UserPrefs.accelerometerFactor );
				if(UserPrefs.accelerometerFactor == 0)
					this.ForComputerSteerMoving();
				this.ForComputerMovingControls();
			}	
//		}
		
	}

	private void ForComputerSteerMoving ( ){
		if ( Input.GetMouseButtonDown(0) )
		{
			click = true ;
			isRotatingBack=false;		
			preXY = Input.mousePosition;
			postXY = preXY;		
		}
	
		if ( Input.GetMouseButtonUp(0) )
		{
	       	click = false ;
	       	isStreeringMoving = false;
	       	isRotatingBack = true;
	 	}
 	
		if ( click )
		{
			preXY = postXY;
	 		postXY = Input.mousePosition;
			isRotatingBack = true;
			if ( (steeringScreenPoint.x < (Input.mousePosition.x + steeringColliderConstant) && steeringScreenPoint.x > (Input.mousePosition.x - steeringColliderConstant) ) &&
				 (steeringScreenPoint.y < (Input.mousePosition.y + steeringColliderConstant) && steeringScreenPoint.y > (Input.mousePosition.y - steeringColliderConstant) ) )
			{
				CameraRotation.isBtnClicked = true;
				isRotatingBack = false;
				
	 			if ( steeringScreenPoint.x < Input.mousePosition.x && steeringScreenPoint.y > Input.mousePosition.y )
			 	{
			 		if ( (postXY.x > preXY.x || postXY.y > preXY.y) && timer >= -maxMovementTimer )
	 				{
	 					this.RotateSteeringUp();
			 		}
	 				if ( (postXY.x < preXY.x || postXY.y < preXY.y) && timer <= maxMovementTimer )
			 		{
			 			this.RotateSteeringDown();
	 				}
			 	}
	 	
			 	if ( steeringScreenPoint.x > Input.mousePosition.x && steeringScreenPoint.y > Input.mousePosition.y )
	 			{
			 		if ( (postXY.x > preXY.x || postXY.y < preXY.y) && timer >= -maxMovementTimer )
			 		{
	 					this.RotateSteeringUp();
	 				}
			 		if ( (postXY.x < preXY.x || postXY.y > preXY.y) && timer <= maxMovementTimer )
	 				{
	 					this.RotateSteeringDown();
	 				}
			 	}
	 	
			 	if ( steeringScreenPoint.x > Input.mousePosition.x && steeringScreenPoint.y < Input.mousePosition.y )
			 	{
			 		if ( (postXY.x < preXY.x || postXY.y < preXY.y) && timer >= -maxMovementTimer )
			 		{
			 			this.RotateSteeringUp();
			 		}
			 		if ( (postXY.x > preXY.x || postXY.y > preXY.y) && timer <= maxMovementTimer )
			 		{
			 			this.RotateSteeringDown();
			 		}
	 			}
	 	
			 	if ( steeringScreenPoint.x < Input.mousePosition.x && steeringScreenPoint.y < Input.mousePosition.y )
			 	{
		 			if ( (postXY.x < preXY.x || postXY.y > preXY.y) && timer >= -maxMovementTimer )
		 			{
		 				this.RotateSteeringUp();
		 			}
		 			if ( (postXY.x > preXY.x || postXY.y < preXY.y) && timer <= maxMovementTimer )
		 			{
		 				this.RotateSteeringDown();
		 			}
	 			}
	 		}
	 	}
		RotateSteerBack();
	}

	private void ForMobileSteerMoving (){
		
		Vector3 tempTouchPosition;
		
		for(int i= 0; i< Input.touchCount; i++){
			
			tempTouchPosition = Input.GetTouch(i).position;
			
			if((steeringScreenPoint.x < (tempTouchPosition.x + steeringColliderConstant) && steeringScreenPoint.x > (tempTouchPosition.x - steeringColliderConstant)) && 
			(steeringScreenPoint.y < (tempTouchPosition.y + steeringColliderConstant) && steeringScreenPoint.y > (tempTouchPosition.y - steeringColliderConstant)))
			{
				CameraRotation.isBtnClicked = true;
				isRotatingBack = false;
				isSteerClick = i;
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					click = true ;
					isRotatingBack = false;
					isStreeringMoving = true;
					preXY = Input.GetTouch(i).position;
					postXY = preXY;	
					ignoreMovement = Input.GetTouch(i).position;
				}
			
				if ( Input.GetTouch(i).phase == TouchPhase.Ended )
				{
			       	click = false ;
			       	isStreeringMoving = false;
			       	isRotatingBack = true;
			       	isSteerClick = -1;
			 	}
				if (Input.GetTouch(i).phase == TouchPhase.Moved)
				{
				 	
					if(click)
				 	{
				 	
					 	preXY = postXY;
					 	postXY = Input.GetTouch(i).position;
					 	if((postXY.x > ignoreMovement.x + 7) || (postXY.y > ignoreMovement.y + 7) || (postXY.x < ignoreMovement.x - 7) || (postXY.y < ignoreMovement.y - 7))
					 	{
						 	if(steeringScreenPoint.x < Input.GetTouch(i).position.x && steeringScreenPoint.y > Input.GetTouch(i).position.y)
						 	{
						 		if((postXY.x > preXY.x || postXY.y > preXY.y) && timer > -maxMovementTimer)
						 		{
						 			this.RotateSteeringUp();
						 		}
						 	 	if((postXY.x < preXY.x || postXY.y < preXY.y) && timer < maxMovementTimer)
						 		{
									this.RotateSteeringDown();
						 		}
						 	}
						 	
						 	if(steeringScreenPoint.x > Input.GetTouch(i).position.x && steeringScreenPoint.y > Input.GetTouch(i).position.y)
						 	{
						 		if((postXY.x > preXY.x || postXY.y < preXY.y) && timer > -maxMovementTimer)
						 		{
						 			this.RotateSteeringUp();
						 		}
						 		if((postXY.x < preXY.x || postXY.y > preXY.y) && timer < maxMovementTimer)
						 		{
						 			this.RotateSteeringDown();
						 		}
						 	}
						 	
						 	if(steeringScreenPoint.x > Input.GetTouch(i).position.x && steeringScreenPoint.y < Input.GetTouch(i).position.y)
						 	{
						 		if((postXY.x < preXY.x || postXY.y < preXY.y) && timer > -maxMovementTimer)
						 		{
						 			this.RotateSteeringUp();
						 		}
						 		if((postXY.x > preXY.x || postXY.y > preXY.y) && timer < maxMovementTimer)
						 		{
						 			this.RotateSteeringDown();
						 		}
						 	}
						 	
						 	if(steeringScreenPoint.x < Input.GetTouch(i).position.x && steeringScreenPoint.y < Input.GetTouch(i).position.y)
						 	{
						 		if((postXY.x < preXY.x || postXY.y > preXY.y) && timer > -maxMovementTimer)
						 		{
						 			this.RotateSteeringUp();
						 		}
						 		if((postXY.x > preXY.x || postXY.y < preXY.y) && timer < maxMovementTimer)
						 		{
						 			this.RotateSteeringDown();
						 		}
						 	}
					 	}
				 	}
			 	}
			 	else
			 	{
			 	 	ignoreMovement = postXY;
			 	}
			
			}
			else if(!isStreeringMoving || isSteerClick == i)
			{
				isRotatingBack = true;
				isSteerClick = -1;
			}	
		}
		RotateSteerBack();
	}

	private void RotateSteerBack(){
		
	 	if(isRotatingBack)
	 	{
		   	if(timer < -0.02f)
		   	{
			    this.RotateSteeringDown();
			
	   		}
	   	   	else if(timer > 0.02f)
	   	   	{
			     this.RotateSteeringUp();
			
	   		}
	   		else if(timer < 0.02f && timer > 0)
	   		{
			    this.gameObject.transform.Rotate(Vector3.up,timer*factor);
			    timer = 0;
			
	   		}
	   		else if(timer > -0.02f && timer < 0)
	   		{
			    this.gameObject.transform.Rotate(Vector3.down,timer*factor*-1);
			    timer = 0;
	   		}
		   	else
		   	{
			    timer = 0;
			    isRotatingBack = false;
	   		}
	  	}
	
	}
	
	private void ForComputerMovingControls(){
//		Debug.Log(" ForComputerMovingControls");
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY)
		{
			if(Input.GetMouseButtonDown(0))
			{
	//			Debug.Log(Input.mousePosition.x +"     "+ Input.mousePosition.y);
				if((acceleratorScreenPoint.x < (Input.mousePosition.x + accerLationColliderConstantX) && acceleratorScreenPoint.x > (Input.mousePosition.x - accerLationColliderConstantX)) && 
				(acceleratorScreenPoint.y < (Input.mousePosition.y + accerLationColliderConstantY) && acceleratorScreenPoint.y > (Input.mousePosition.y - accerLationColliderConstantY)))
				{	
					if(reverse)
					{
						forward = false;
						back = true;
						brake = false;
					}
					else
					{
						forward = true;
						back = false;
						brake = false;
					}
			//		Debug.Log("Acceleration Pressed");
					isAccelerationPressed =  true;
					UserPrefs.isAccelaratorPressed = isAccelerationPressed; 
					acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
				}	
				
				if((brakeScreenPoint.x < (Input.mousePosition.x + brakeColliderConstantX) && brakeScreenPoint.x > (Input.mousePosition.x - brakeColliderConstantX)) && 
				(brakeScreenPoint.y < (Input.mousePosition.y + brakeColliderConstantY) && brakeScreenPoint.y > (Input.mousePosition.y - brakeColliderConstantY)))
				{
					brake = true;
					forward = false;
					back = false;
					brakePosition.renderer.material.mainTexture = brakePress;		
				}
			
			
				if((gearBaseScreenPoint.x < (Input.mousePosition.x + gearColliderConstantX) && gearBaseScreenPoint.x > (Input.mousePosition.x - gearColliderConstantX)) && 
				(gearBaseScreenPoint.y < (Input.mousePosition.y + gearColliderConstantY) && gearBaseScreenPoint.y > (Input.mousePosition.y - gearColliderConstantY)))
				{
					reverse = !reverse;
					if(reverse)
					{
	//					Debug.Log("ReverSed");
						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearReverse;   	
					}
					else
					{	
	///					Debug.Log("Forward");
						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearDrive;
					}
				}
				
			}
			
			if(Input.GetMouseButtonUp(0))
			{
				forward = false;
				back = false;
				brake = false;
				acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;
				brakePosition.renderer.material.mainTexture = brakeRelease;	
				
				isAcceteratorPress = -1;
				isAccelerationPressed = false;
				UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
	
			}
		}
		
	}
	
	private void ForMobileMovingControls(){
		 
		for ( int i= 0 ; i < Input.touchCount ; i++ ) 
		{
		
			if((acceleratorScreenPoint.x < (Input.GetTouch(i).position.x + accerLationColliderConstantX) && acceleratorScreenPoint.x > (Input.GetTouch(i).position.x - accerLationColliderConstantX)) && 
			(acceleratorScreenPoint.y < (Input.GetTouch(i).position.y + accerLationColliderConstantY) && acceleratorScreenPoint.y > (Input.GetTouch(i).position.y - accerLationColliderConstantY)))
			{
				CameraRotation.isBtnClicked = true;
				isAcceteratorPress = i;
				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					if(reverse)
					{
						forward = false;
						back = true;
						brake = false;
					}
					else
					{
						forward = true;
						back = false;
						brake = false;
					}
						acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
					if(!isAccelerationPressed)
					{
						isAccelerationPressed = true;
				//		Debug.LogError("isAccelerationPressed = true   for mobile");
						UserPrefs.isAccelaratorPressed = isAccelerationPressed;
					}
					
				}
				if(Input.GetTouch(i).phase == TouchPhase.Moved)
				{
					if(reverse)
					{
						forward = false;
						back = true;
						brake = false;
					}
					else
					{
						forward = true;
						back = false;
						brake = false;
					}
					if(!isAccelerationPressed)
					{
						isAccelerationPressed = true;
						UserPrefs.isAccelaratorPressed = isAccelerationPressed;
						acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
					}
					
				}
				
				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					forward = false;
					back = false;
					brake = false;
					isAcceteratorPress = -1;
					acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;	  
					isAccelerationPressed = false;
					UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
				}
			}
			
			else if(isAcceteratorPress == i)
			{
				forward = false;
				brake = false;
				back = false;
				isAcceteratorPress = -1;
				isAccelerationPressed = false;
				UserPrefs.isAccelaratorPressed = isAccelerationPressed;
				acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;
			}
			
			if((brakeScreenPoint.x < (Input.GetTouch(i).position.x + brakeColliderConstantX) && brakeScreenPoint.x > (Input.GetTouch(i).position.x - brakeColliderConstantX)) && 
			(brakeScreenPoint.y < (Input.GetTouch(i).position.y + brakeColliderConstantY) && brakeScreenPoint.y > (Input.GetTouch(i).position.y - brakeColliderConstantY)))
			{
				CameraRotation.isBtnClicked = true;
				
				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					forward = false;
					brake = true;
					back = false;
	
						brakePosition.renderer.material.mainTexture = brakePress;
				}
				if(Input.GetTouch(i).phase == TouchPhase.Moved)
				{
					forward = false;
					brake = true;
					back = false;
					if(!isBreakPressed)
					{
						isBreakPressed = true;
						brakePosition.renderer.material.mainTexture = brakePress;
					}
				}
				
				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					forward = false;
					brake = false;
					back = false;
					isBrakePress = -1;
					isBreakPressed = false;
					brakePosition.renderer.material.mainTexture = brakeRelease;	
				}
				isBrakePress = i;
			
			}
			
			else if(isBrakePress == i)
			{
				forward = false;
				brake = false;
				back = false;
				isBrakePress = -1;
				isBreakPressed = false;
				brakePosition.renderer.material.mainTexture = brakeRelease;			     	
			}
			
			if((gearBaseScreenPoint.x < (Input.GetTouch(i).position.x + gearColliderConstantX) && gearBaseScreenPoint.x > (Input.GetTouch(i).position.x - gearColliderConstantY)) && 
			(gearBaseScreenPoint.y < (Input.GetTouch(i).position.y + gearColliderConstantY) && gearBaseScreenPoint.y > (Input.GetTouch(i).position.y - gearColliderConstantY)))
			{
				CameraRotation.isBtnClicked = true;
				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					reverse = !reverse;
					if(reverse)
					{
			//			Debug.Log("ReverSed");					    
						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearReverse;
					}
					else
					{	
			//			Debug.Log("Forward");
						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearDrive;					    	
					}
				}		  
			}
		}
	}

	private void  setCameraControls (){
		acceleratorPosition = GameObject.FindGameObjectWithTag("Accelerator").transform;
		brakePosition = GameObject.FindGameObjectWithTag("Brake").transform;
		gearBaseScreenPoint   = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("GearBase").transform.position);			
		steeringScreenPoint   = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		acceleratorScreenPoint   = Camera.main.WorldToScreenPoint(acceleratorPosition.position);
		brakeScreenPoint   = Camera.main.WorldToScreenPoint(brakePosition.position);
	}
	
	private void RotateSteeringDown(){
		timer = timer + Time.deltaTime;
	 	this.gameObject.transform.Rotate(Vector3.down,Time.deltaTime*factor);
	}
	private void RotateSteeringUp(){
		timer = timer - Time.deltaTime;
	 	this.gameObject.transform.Rotate(Vector3.up,Time.deltaTime*factor);
	}
	
	private void SetControls(){
		// 0 for Steering, 1 for Accelerometer, 2 for ArrowLeft Right
		
		//For Steering
		if(UserPrefs.accelerometerFactor==0)
		{
			GameObject.FindGameObjectWithTag("LeftTurnSteering").renderer.enabled = false;//to hide Left Arrow
			GameObject.FindGameObjectWithTag("RightTurnSteering").renderer.enabled = false;//to hide right Arrow
		}
		
		//For Accelerometer
		if(UserPrefs.accelerometerFactor==1)
		{
			GameObject.FindWithTag("Steering").renderer.enabled = false;//to hide steering
			GameObject.FindGameObjectWithTag("LeftTurnSteering").renderer.enabled = false;//to hide Left Arrow
			GameObject.FindGameObjectWithTag("RightTurnSteering").renderer.enabled = false;//to hide right Arrow
		}
		//For Arrow Left Right
		else if(UserPrefs.accelerometerFactor==2)
		{
			GameObject.FindWithTag("Steering").renderer.enabled = false;//to hide steering
		}
	}
	
	private void SetCameraFOVForIphone(){
		#if UNITY_IPHONE
		//	Debug.Log("Screen Width" + Screen.width);
			if(Screen.width==960&&Screen.width==480){
				Camera.main.fieldOfView = 48;
			}
			if(Screen.width==2048||Screen.width==1024){
				Camera.main.fieldOfView = 52;
			}
		#endif
	}
	
}
