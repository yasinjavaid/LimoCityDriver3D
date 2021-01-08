using UnityEngine;
using System.Collections;
using System;
public class HudMenuListenerMeter : MonoBehaviour {
		int  cameraPosition = 1;
		GameObject btnCamera;
		Quaternion currentRPMAngle;
		Quaternion maxRPMAngle;
		Quaternion minRPMAngle;
	
	public bool isAccelerationPressed;
	private bool isBreakPressed;
	
	// Fuel Manager
		public float time ;
		UISprite timerSprite ;
		UIPanel timerTextIndicationPanel;
		bool isTimerIndicator;
		UISprite RPMsprite;
		UISprite MPHsprite;
		float previousRPMAngle=0f;
		float previousRPMVal = 0.0f;
		float	reverseTime = 0;
	public static bool  forward = false;
	public static bool  brake = false;
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
//		maxRPMAngle= Quaternion.Euler(new Vector3(0,0,260));
		minRPMAngle= Quaternion.Euler(new Vector3(0,0,150));


		if(this.gameObject.name == "rpmNeedle"){
			RPMsprite = this.gameObject.GetComponent<UISprite>();
			reverseTime = 10;
		}
		if(this.gameObject.name == "mphNeedle"){
			MPHsprite = this.gameObject.GetComponent<UISprite>();
		}
		
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
//			Debug.LogError("max zAngle="+zAngle);
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,0));
			maxRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		
		
	}
	
//	 Update is called once per frame
	void Update () {
		
	 if(this.gameObject.name == "rpmNeedle"){			
//			Debug.Log("isAccelerationPressed"+UserPrefs.isAccelaratorPressed);
			if(UserPrefs.isAccelaratorPressed){
				//Debug.Log("accelerator Pressed pressed");
				setRPMmeter();	
			}
			else{
//				Debug.Log("NOTTTTT ");
				//revertRPMMeter();
//				setRPMmeter();
				revertRPMMeter();
			}
		}
		else if (this.gameObject.name == "mphNeedle")
		{
			setMPHmeter();
			if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY)
			{
				float mphAngle = 150;
				MPHsprite.transform.eulerAngles = new Vector3(0,0,mphAngle);
			}
		}
		
		
		
		
		
		
//		{
//		}
		
		
		
		
	}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	
	
	void OnClick(){
		
		
		
		
		
	}
	
	
		
	
	
	private void setRPMmeter(){
		
		//float currentRPMAngel;
		
//		float rpmAngle;

//		if(UserPrefs.rpmValue<5){
//			int rotationFactor = -55;
//			rpmAngle = 150+Math.Abs(UserPrefs.rpmValue)*(rotationFactor);
//			previousRPMVal = UserPrefs.rpmValue;
//			RPMsprite.transform.eulerAngles = new Vector3(0,0,rpmAngle);
//		}
//		float currentRPMAngle=previousRPMAngle;
//		if(currentRPMAngle<260)
//		{
//			currentRPMAngle+=20;
//			if(currentRPMAngle>260)
//			{
//				currentRPMAngle=260;
//			}
//			Debug.LogError("I am in setrpm meter");
//			 RPMsprite.transform.eulerAngles = new Vector3(0,0,currentRPMAngle);
//		Debug.LogError(RPMsprite.transform.eulerAngles.z);
		if(RPMsprite.transform.eulerAngles.z>0 && RPMsprite.transform.eulerAngles.z<240)
		{
			RPMsprite.transform.rotation=Quaternion.RotateTowards( RPMsprite.transform.rotation,currentRPMAngle,Time.deltaTime*120);
		}
		 else
		{
			//if(currentRPMAngle.z)
			RPMsprite.transform.rotation=Quaternion.RotateTowards( RPMsprite.transform.rotation,maxRPMAngle,Time.deltaTime*120);
		}
		
		
//				previousRPMAngle=currentRPMAngle;
//		}
	}
	private void revertRPMMeter(){
		
		
//			float rpmReverseAngle;
//			reverseTime =  reverseTime-Time.deltaTime;
//			int rotationFactor = -25;
////			rpmAngle = 150+Math.Abs(UserPrefs.rpmValue)*(rotationFactor);
//			rpmReverseAngle =  150+ ((Math.Abs(UserPrefs.rpmValue)*(rotationFactor)/reverseTime));
//			//UserPrefs.rpmValue = 0;
//			//RPMsprite.transform.eulerAngles = new Vector3(0,0,rpmReverseAngle);
//			Debug.Log(rpmReverseAngle);
//			if(rpmReverseAngle>155 && rpmReverseAngle<360){
//				RPMsprite.transform.Rotate (0, 0,rpmReverseAngle);
//			}
		
		if( RPMsprite.transform.eulerAngles.z>238    )
		{
			RPMsprite.transform.rotation=Quaternion.RotateTowards( RPMsprite.transform.rotation,currentRPMAngle,Time.deltaTime*180);
		}
		 else
		{
			RPMsprite.transform.rotation=Quaternion.RotateTowards( RPMsprite.transform.rotation,minRPMAngle,Time.deltaTime*180);
		}
		
//		Quaternion.Slerp(150+Math.Abs(UserPrefs.rpmValue)*(rotationFactor),
		
	}
	
	private void setMPHmeter(){
		float mphAngle;
//		Debug.LogError("UserPrefs.rpmValue"+UserPrefs.rpmValue);
//		if( Math.Abs(UserPrefs.rpmValue)<(10+VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel)){
//			mphAngle = 150+Math.Abs(UserPrefs.rpmValue)*(-15);
		if(UserPrefs.rpmValue<0)
		{
			mphAngle = 150+(UserPrefs.rpmValue*(-0.8f)*-1);
		}
			else
			{
				mphAngle = 150+(UserPrefs.rpmValue*(-0.8f));
			}
			MPHsprite.transform.eulerAngles = new Vector3(0,0,mphAngle);
//		}
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
						Debug.LogError("isAccelerationPressed = true   for mobile");
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
						Debug.Log("Forward");
						GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().hoverSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().pressedSprite = "Gear-D";
					}
					
				}
			}
		
		
		
		
	}
	
	
	
	
	
	
}
