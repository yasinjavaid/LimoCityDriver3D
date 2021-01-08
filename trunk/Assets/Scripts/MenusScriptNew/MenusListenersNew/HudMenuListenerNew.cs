using UnityEngine;
using System.Collections;
using System;
public class HudMenuListenerNew : MonoBehaviour {
		int  cameraPosition = 1;
		GameObject btnCamera;
		Quaternion currentRPMAngle;
		Quaternion maxRPMAngle;
		Quaternion minRPMAngle;
	
	public bool isAccelerationPressed;
	private bool isBreakPressed;
	public static float stteringBtnPressedTime=0;
	
	// Fuel Manager
		
		UISprite timerSprite ;
		UIPanel timerTextIndicationPanel;
		bool isTimerIndicator;
		UISprite RPMsprite;
		UISprite MPHsprite;
		float previousRPMAngle=0f;
		float previousRPMVal = 0.0f;
		float	reverseTime = 0;
	public static bool  forward = false;
	public static bool  brake = true;
	public static bool  reverse = false;
	public static bool  back = false;
	private int isAcceteratorPress; 
	private int isBrakePress;
	int leftMove ;
	int rightMove ;
	private bool isLeftArrowPressed;
	private bool isRightArrowPressed;
	public static int move ;
	public Texture gearReverse;
	public Texture gearDrive;
	void Start () {	
		
		setCurrentRPMAngle();
		minRPMAngle= Quaternion.Euler(new Vector3(0,0,150));
	
		if(this.gameObject.name == "btnCamera"){
			btnCamera = GameObject.FindGameObjectWithTag("btnCamera");
			
			UserPrefs.currentCameraControl = 1;	
			UserPrefs.totalParkingLot = Constants.totalParkingLot[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];

		}
		if(this.gameObject.name == "rpmNeedle"){
			RPMsprite = this.gameObject.GetComponent<UISprite>();
			reverseTime = 10;
		}
		if(this.gameObject.name == "mphNeedle"){
			MPHsprite = this.gameObject.GetComponent<UISprite>();
		}
		GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-D";
		reverse = false;
		forward = false;
		brake = true;
		
		back = false;
		isAcceteratorPress = -1;
		isBrakePress = -1;
	}
	
	void setCurrentRPMAngle()
	{
		int currentEngineUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel;
		float zAngle=60;
		if(currentEngineUpgradeLvl==1)
		{
			zAngle=60;
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		else if(currentEngineUpgradeLvl<=4)
		{
			 zAngle=60-(15*currentEngineUpgradeLvl);
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		else
		{
			zAngle=360-(20*(currentEngineUpgradeLvl-4));
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,0));
			maxRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
			
//		if(UserPrefs.isAccelaratorPressed){
//			Debug.LogError("UserPrefs.isAccelaratorPressed="+UserPrefs.isAccelaratorPressed);
//			Debug.LogError("Volume sound is "+SoundManager.Instance.vehicleEngineSoundSource.volume);
//			if(SoundManager.Instance.vehicleEngineSoundSource.volume < 0.5f)
//			{
//		//		Debug.LogError("Increasing");
//				BackgroundSoundManager.Instance.backgrpundmusicSource.volume = .1f;
//				SoundManager.Instance.vehicleEngineSoundSource.volume +=.025f; 	
//			}
//		}
//		else{
//			if(SoundManager.Instance.vehicleEngineSoundSource.volume >.3f){
//		//		Debug.LogError("Decreasing"+SoundManager.Instance.vehicleEngineSoundSource.volume);
//				SoundManager.Instance.vehicleEngineSoundSource.volume -=.025f;
//				if(SoundManager.Instance.vehicleEngineSoundSource.volume <.5f){
//					BackgroundSoundManager.Instance.backgrpundmusicSource.volume += .025f;	
//				}
//			}
//			
//		}

		if(Input.GetMouseButtonUp(0))
		{
					CameraRotation.isBtnClicked = false;
		}
		
		
		
		if(isLeftArrowPressed || isRightArrowPressed)
		{
			stteringBtnPressedTime++;
		}
		
	}
				
	
	void OnClick(){
		if(this.name.Equals("btnHome"))
		{
			if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.PARKED)
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.PAUSED);
			
		}
		if(this.name.Equals("btnCamera"))
		{	cameraPosition++;
			if(cameraPosition> 4)
				cameraPosition = 1;
			ChangeTexture();
			
			int temp = UserPrefs.currentCameraControl+1;
			if(temp>8 || temp<1){
				temp = 1;
			}
			UserPrefs.currentCameraControl = temp;
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
			
		}
		
		
		
		
		
	}
	
	void ChangeTexture(){
		
		if(cameraPosition == 1 ){
			
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-front" ;
		}
		else if(cameraPosition == 2 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-right" ;
			
		}
		else if(cameraPosition == 3 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-rear" ;
			
		}
		else if(cameraPosition == 4 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-left" ;
			
		}
		
	}
	
	
	
	
	public void ScaledTimerText(int time){

		if(this.gameObject.name=="TimerText"){
			int liter = 5;
			if(time == 50){
				liter = 10;
			}else if(time == 75){
				liter = 20;
			}
			this.gameObject.GetComponent<UILabel>().text = "+"+liter+"LTR.";

		}
	}
	
	private void showTimerTextIndicator(){
		if(timerTextIndicationPanel.alpha < 1.0f && !isTimerIndicator){
			timerTextIndicationPanel.alpha += 0.05f;
		} else if(timerTextIndicationPanel.alpha > 0.0f){
			isTimerIndicator = true;
			timerTextIndicationPanel.alpha -= 0.05f;

		} else {
			timerTextIndicationPanel.alpha = 0.0f;
			isTimerIndicator = false;
		}
	}
	

	void OnPress (bool isDown)
	{
		if(this.name.Equals("btnAccel"))
		{
			if(isDown)
			{
				CameraRotation.isBtnClicked = true;
				
				
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
//						acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
					if(!isAccelerationPressed)
					{
						isAccelerationPressed = true;
				//		Debug.LogError("isAccelerationPressed = true   for mobile");
						UserPrefs.isAccelaratorPressed = isAccelerationPressed;
					}
			}
			else if(!isDown)
			{
				CameraRotation.isBtnClicked = false;
					forward = false;
					back = false;
					brake = false;
					isAcceteratorPress = -1;
//					acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;	  
					isAccelerationPressed = false;
					UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
			}
		}
		
		
		
			if(this.name.Equals("btnBrake"))
			{
				CameraRotation.isBtnClicked = true;
			if(isDown)
			{
					forward = false;
					brake = true;
					back = false;
					if(!isBreakPressed)
					{
						isBreakPressed = true;
						
					}
			}
			
			else if(!isDown)
			{
				CameraRotation.isBtnClicked = false;
					forward = false;
					brake = false;
					back = false;
					isBrakePress = -1;
					isBreakPressed = false;
					
			}
		}
		
		
		
		
		
		
		if(this.name.Equals("btlLeftsteer"))
		{
			if(isDown)
			{
				CameraRotation.isBtnClicked = true;
					move = -1;
					if(!isLeftArrowPressed)
					{
						isLeftArrowPressed = true;
						
					}
			}
			else if(!isDown)
			{
				stteringBtnPressedTime=0;
				CameraRotation.isBtnClicked = false;
					move = 0;
					leftMove = -1;
					isLeftArrowPressed = false;
			}
		}
		
		
			if(this.name.Equals("btnRightSteer"))
			{
				if(isDown)
				{
					CameraRotation.isBtnClicked = true;
					move = 1;
					if(!isRightArrowPressed)
					{
						isRightArrowPressed = true;
								
					}
				}
				else if(!isDown)
				{
				stteringBtnPressedTime=0;
					CameraRotation.isBtnClicked = false;
					move = 0;
					rightMove = -1;
					isRightArrowPressed = false;
				}
			}
		
		
		
		
		if(this.name.Equals("Gear"))
			{
				if(isDown)
				{
					reverse = !reverse;
					if(reverse)
					{
	//					Debug.Log("ReverSed");
						GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-R";  
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().hoverSprite = "Gear-R";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().pressedSprite = "Gear-R";
					}
					else
					{	
		//				Debug.Log("Forward");
						GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().hoverSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().pressedSprite = "Gear-D";
					}
					
				}
			}
		
		
		
		
	}
	
	
	
	
	
	
}
