using UnityEngine;
using System.Collections;

public class CarPosition : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.CarPositions();
	}
	
	// Update is called once per frame
	void Update () {
//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentEpisode);
	}
	
	private void CarPositions(){
	//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentEpisode);
			
		if(UserPrefs.currentEpisode==1){
			this.CarPositionFirstEpisode();
		}
		else if(UserPrefs.currentEpisode==2){
			this.CarPositionSecondEpisode();
		}
		else if(UserPrefs.currentEpisode==3){
			this.CarPositionThirdEpisode();
		}

		// level 8 car position
//		this.gameObject.transform.position = new Vector3(43.54512f,5.802897f,-25.73977f);
//			this.gameObject.transform.Rotate(0,180f,0);	
		
		// level 9 car position
//		this.gameObject.transform.position = new Vector3(-25.61581f,5.802897f,40.98045f);
//			this.gameObject.transform.Rotate(0,0f,0);
		
		// level 10 car position
//		this.gameObject.transform.position = new Vector3(42.87842f,5.802897f,18.47994f);
//			this.gameObject.transform.Rotate(0,80f,0);
		
		// level 11 car position
//		this.gameObject.transform.position = new Vector3(13.40938f,9.813167f,35.48162f);
//			this.gameObject.transform.Rotate(3.27f,0f,0);
		
		
	}
	
	private void CarPositionFirstEpisode(){
		if(UserPrefs.currentLevel == 1)
		{    
			
			this.gameObject.transform.position = new Vector3(-1402.373f,-161.6281f,-3433.072f);
			this.gameObject.transform.Rotate(0,90f,0);
	
			
			
		}
		else if(UserPrefs.currentLevel == 2)
		{    
			
			this.gameObject.transform.position = new Vector3(5051.3f,-207.7969f,-3183.391f);
			this.gameObject.transform.Rotate(0,270f,0);
			
		}
		else if(UserPrefs.currentLevel == 3)
		{    
			
			this.gameObject.transform.position = new Vector3(9003.851f,-38.20851f+15.14456f,-3640.704f);
			this.gameObject.transform.Rotate(0,180f,0);
	
			
			
		}
//		else if(UserPrefs.currentLevel == 2)
//		{
//			this.gameObject.transform.position = new Vector3(5247.976f,-229.0438f,-4736.18f);
//			this.gameObject.transform.Rotate(0,-33f,0);
//		}
		else if(UserPrefs.currentLevel == 4)
		{
			this.gameObject.transform.position = new Vector3(-3591.386f,128.1225f+15.14456f,-3817.586f);
			this.gameObject.transform.Rotate(13.32f,192.32f,0);
		}
//		else if(UserPrefs.currentLevel == 4)
//		{
//			this.gameObject.transform.position = new Vector3(815.6421f,-175.6384f,-3225.775f);
//			this.gameObject.transform.Rotate(0,-74.12f,0);
//		}
		else if(UserPrefs.currentLevel == 5)
		{
			this.gameObject.transform.position = new Vector3(3640.201f,353.3163f+15.14456f,7035.312f);
			this.gameObject.transform.Rotate(0,270f,0);
		}
//		else if(UserPrefs.currentLevel == 6)
//		{
//			this.gameObject.transform.position = new Vector3(-6264.123f,-167.675f,3376.438f);
//			this.gameObject.transform.Rotate(0,0,0);
//		}
//		else if(UserPrefs.currentLevel == 7)
//		{
//			this.gameObject.transform.position = new Vector3(422.9185f,-174.098f,-2934.953f);
//			this.gameObject.transform.Rotate(0,0,0);
//		}
		else if(UserPrefs.currentLevel == 6)
		{
			this.gameObject.transform.position = new Vector3(4710.284f,21.57201f+15.14456f,5338.066f);
			this.gameObject.transform.Rotate(0,-116f,0);
		}


	}
	private void CarPositionSecondEpisode(){
		
		if(UserPrefs.currentLevel == 1) {
			
			Debug.Log("---------------------------------------------------------------third episode level 2");
			
			this.gameObject.transform.position = new Vector3(3931.465f,-223.5556f+15.14456f,-3267.409f);
			this.gameObject.transform.Rotate(0,-90f,0);
						
		}
//		else if(UserPrefs.currentLevel == 2) {
//			
//			this.gameObject.transform.position = new Vector3(-9952.963f,-167.3969f,4028.807f);
//			this.gameObject.transform.Rotate(0,90,0);
			
			
				if(UserPrefs.currentLevel == 2) {
			
			this.gameObject.transform.position = new Vector3(6019.16f,-215.7871f,-3970.302f);
			this.gameObject.transform.Rotate(0,180f,0);
			
		 
			
			
			
			
			
		} else if(UserPrefs.currentLevel == 3) {
			
			this.gameObject.transform.position = new Vector3(-269.6081f,-177.625f+15.14456f,-3231.366f);
			this.gameObject.transform.Rotate(0,-90 ,0);
			
		} 
//		else if(UserPrefs.currentLevel == 4) {
//			
//			this.gameObject.transform.position = new Vector3(6779.283f,35.45709f,6448.14f);
//			this.gameObject.transform.Rotate(0,-106.02f,0);
//			
//		} 
		
		
		
		else if(UserPrefs.currentLevel == 4) {
			
		//	this.gameObject.transform.position = new Vector3(-511.3596f,-171.8421f,-3911.678f);
		//	this.gameObject.transform.Rotate(0,-180f,0);
			this.gameObject.transform.position = new Vector3(11172.94f,119.0513f+15.14456f,3690.951f);
			this.gameObject.transform.Rotate(0,22.49242f,0);
			
		} 
		
	}
	private void CarPositionThirdEpisode(){
		if(UserPrefs.currentLevel == 1)
		{
			this.gameObject.transform.position = new Vector3(10111.3f,111.0764f+15.14456f,1436.391f);
			this.gameObject.transform.Rotate(0,201.28f,0);
		}
		
			else if(UserPrefs.currentLevel == 2)
		{
			this.gameObject.transform.position = new Vector3(11165.52f,120.6722f+15.14456f,3688.922f);
			this.gameObject.transform.Rotate(0,17.41565f,0);
		}
		
		else if(UserPrefs.currentLevel == 3) {
			
			this.gameObject.transform.position = new Vector3(-9952.963f,-167.3969f+15.14456f,4028.807f);
			this.gameObject.transform.Rotate(0,90,0);
		}
		
	
		
		else if(UserPrefs.currentLevel == 4) {
			
			this.gameObject.transform.position = new Vector3(6779.283f,35.45709f+15.14456f,6448.14f);
			this.gameObject.transform.Rotate(0,-106.02f,0);
			
		} 
		

	}

//		if(UserPrefs.currentLevel == 1)
//		{
//			this.gameObject.transform.position = new Vector3(10111.3f,111.0764f,1436.391f);
//			this.gameObject.transform.Rotate(0,201.28f,0);
//		}
//
//		else if(UserPrefs.currentLevel == 2)
//		{
//			this.gameObject.transform.position = new Vector3(11165.52f,120.6722f,3688.922f);
//			this.gameObject.transform.Rotate(0,17.41565f,0);
//		}
//		
//		
//		else if(UserPrefs.currentLevel == 3)
//		{
//			this.gameObject.transform.position = new Vector3(-206.203f,-177.3125f,-3239.987f);
//			this.gameObject.transform.Rotate(0,-90,0);
//		}
//		
//		else if(UserPrefs.currentLevel == 4)
//		{
//			this.gameObject.transform.position = new Vector3(422.9185f,-174.098f,-2934.953f);
//			this.gameObject.transform.Rotate(0,0,0);
//		}
}
