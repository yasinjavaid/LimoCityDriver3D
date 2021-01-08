

using UnityEngine;
using System.Collections;

public class SmoothFollow: MonoBehaviour {
/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
public Transform target;
// The distance in the x-z plane to the target
public static float distance;
// the height we want the camera to be above the target
public static float height;
// How much we 
public float heightDamping= 2.0f;
public float rotationDamping= 3.0f;
private int lerpSpeed = 8;
private float localHeight;

// Place the script in the Camera-Control group in the component menu
//@script AddComponentMenu("Camera-Control/Smooth Follow")
	void Start(){
		
		UserPrefs.isTutorialStart = false;
		
		Debug.Log("in on start");
		this.setCurrentVehicles();
		this.InitiateCar();
		this.setCameraDistanceHeight();
		
		UserPrefs.currentCameraControl = 1;
		this.SetCameraFOVForIphone();
		this.SetCameraAngle();
		localHeight = height;
	}
	void Update()
	{
		distance=CameraControl.distance;
		height=CameraControl.height;
//		height = Mathf.Lerp(height,CameraRotation.y/8  , Time.deltaTime * lerpSpeed);
//		if(height < 0.4f)
//			height = 0.4f;
//		if(height > 1)
//			height = 1.0f;
	}
	

	void  LateUpdate (){
		/*if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
			return;
		}*/
		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle= target.eulerAngles.y;
		float wantedHeight= target.position.y + height;
			
		float currentRotationAngle= transform.eulerAngles.y;
		float currentHeight= transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
	
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
		// Convert the angle into a rotation
		Quaternion currentRotation= Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
	
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
		
		// Always look at the target
		transform.LookAt (target);
	}
	
	private void SetCameraFOVForIphone(){
		#if UNITY_IPHONE
			Debug.Log("Screen Width" + Screen.width);
			if(Screen.width==960&&Screen.width==480){
				Camera.main.fieldOfView = 48;
			}
			if(Screen.width==2048||Screen.width==1024){
				Camera.main.fieldOfView = 52;
			}
		#endif
	}
	
	public  void SetCameraAngle(){
		if(UserPrefs.currentCameraControl == 1){
			this.SetMainCameraView();
		}else if(UserPrefs.currentCameraControl == 6){
			SetBottomLeftCameraView();
		}else if(UserPrefs.currentCameraControl == 4){
			SetTopLeftCameraView();
		}else if(UserPrefs.currentCameraControl == 3){
			SetTopCameraView();
		}else if(UserPrefs.currentCameraControl == 2){
			SetTopRightCameraView();
		}else if(UserPrefs.currentCameraControl == 8){
			SetBottomRightCameraView();
		
		}else if(UserPrefs.currentCameraControl == 9){
			ParkedView();
		}
		else if(UserPrefs.currentCameraControl == 5){
			SetTopFrontCameraView();
		}
		else if(UserPrefs.currentCameraControl == 7){
			SetBottomCameraView();
		}else{
			UserPrefs.currentCameraControl = 1;
		}
		
	}
	
	
	
	
	private void  SetTopCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,270,0));		
		CameraRotation.x = 270 + CameraRotation.rotationFactor;
		
	}	
	private void  SetBottomCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,90,0));		
		CameraRotation.x = 90 + CameraRotation.rotationFactor;
	}
	
	private void  SetTopLeftCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,226,0));
		CameraRotation.x = 227 + CameraRotation.rotationFactor;
	}
	
	private void  SetTopRightCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,317,0));	
		CameraRotation.x = 330 + CameraRotation.rotationFactor;
	}
	
	private void  SetBottomLeftCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,137,0));		
		CameraRotation.x = 136 + CameraRotation.rotationFactor;
	}
	
	private void  SetBottomRightCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,47,0));
		CameraRotation.x = 47 + CameraRotation.rotationFactor;
	}
	private void SetTopFrontCameraView()
	{
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
		CameraRotation.x = 180 + CameraRotation.rotationFactor;
	}

	private void  SetMainCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));	
		CameraRotation.x = CameraRotation.rotationFactor;
	}
	private void  ParkedView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,15,0));
		CameraRotation.x = 15 + CameraRotation.rotationFactor;
	}
	
	private void SetDefaultsPosition(){
	//	distance = 20.0f;
	//	height = 3.0f;
	}
	
	private void InitiateCar(){
		
		if(UserPrefs.currentVehicle == 1){
//			Instantiate(Resources.Load("Vehicles/US_taxi"),new Vector3(0,100,0),Quaternion.identity);			
			Instantiate(Resources.Load("Vehicles/limo_car_01"),new Vector3(0,100,0),Quaternion.identity);						
		}else if(UserPrefs.currentVehicle == 2){
			Instantiate(Resources.Load("Vehicles/limo_02"),new Vector3(0,100,0),Quaternion.identity);
		}else if(UserPrefs.currentVehicle == 3){
			Instantiate(Resources.Load("Vehicles/limo_03"),new Vector3(0,100,0),Quaternion.identity);
		}
		Debug.Log("in InitiateCar");
		target = GameObject.Find("EmptyBody").transform;
	}
	
	private void setCurrentVehicles(){
		if(!isNewMenu()){
			if(UserPrefs.currentEpisode == 1){
				UserPrefs.currentVehicle = 1;		
			}else if(UserPrefs.currentEpisode == 2){
				UserPrefs.currentVehicle = 2;
			}else if(UserPrefs.currentEpisode == 3){
				UserPrefs.currentVehicle = 3;
			}	
		}
	}
	private void setCameraDistanceHeight(){
		if(UserPrefs.currentVehicle == 1){
			distance = 400.0f;
			height = 116.3f;
			CameraControl.distance=distance;
			CameraControl.height=height;
		} else if(UserPrefs.currentVehicle == 2){
			distance = 380.0f;
			height = 116.3f;
			CameraControl.distance=distance;
			CameraControl.height=height;
		} else if(UserPrefs.currentVehicle == 3){
			distance = 289.89f;
			height = 116.3f;	
			CameraControl.distance=distance;
			CameraControl.height=height;
		}		
	}
	
public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}


}