using UnityEngine;
using System.Collections;

public class HudMenuListener : MonoBehaviour {
	float time ;
	UISprite timerSprite ;
	UIPanel timerTextIndicationPanel;
	bool isTimerIndicator;
	// Use this for initialization
	void Start () {
		timerTextIndicationPanel = GameObject.FindGameObjectWithTag("TimerTextPanel").GetComponent<UIPanel>();
		
		if(this.gameObject.name=="Thumb"){
//			time = Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];//Constants.TIMEPERLEVEL;
			time = 10;
		//	time = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR;
			timerSprite = this.gameObject.GetComponent<UISprite>();
			GameObject.FindGameObjectWithTag("SubMenuBackground").GetComponent<UITexture>().enabled = false;
			UserPrefs.currentCameraControl = 1;	
			UserPrefs.totalParkingLot = Constants.totalParkingLot[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.gameObject.name=="Thumb" && GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			this.SetTimer();
		}
	}
	
	void OnClick(){
		if(this.name.Equals("btnHome"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELEXIT);
			
		}
		if(this.name.Equals("btnCamera"))
		{
			int temp = UserPrefs.currentCameraControl+1;
			if(temp>8 || temp<1){
				temp = 1;
			}
			UserPrefs.currentCameraControl = temp;
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
			
		}
	}
	
	private void SetTimer(){
		time= time-Time.deltaTime;
		float timerAngle;
		if(time>0){
			if(isNewMenu() && isFuelUpgrade())
			{
		//		 timerAngle=270+(180f-((180f/VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR)*time));
				 
				timerAngle=270+(180f-((180f/10)*time));
			
			}
			else
			{
//			timerAngle = 270+(180f-((180f/80)*time));
//			Debug.Log("Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1]="+Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1]);
				 timerAngle = 270+(180f-((180f/Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1])*time));
			}
				timerSprite.transform.eulerAngles = new Vector3(0,0,timerAngle);
		}else{
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.TIMEOVER);
		}
	}
	
	public void AddTime(float timeToAdd){
		Debug.Log("sdfaskfkjasdfh");
		if(this.gameObject.name=="Thumb"){
			time = time + timeToAdd;
		}
	}
	
	public void ScaledTimerText(int time){
//		Debug.Log("sdfaskfkjasdfh");
		if(this.gameObject.name=="TimerText"){
			int liter = 5;
			if(time == 50){
				liter = 10;
			}else if(time == 75){
				liter = 20;
			}
			this.gameObject.GetComponent<UILabel>().text = "+"+liter+"LTR.";
			showTimerTextIndicator();
		}
	}
	
	private void showTimerTextIndicator(){
//		Debug.Log("+++ PA:"+timerTextIndicationPanel.alpha+" +++");
		if(timerTextIndicationPanel.alpha < 1.0f && !isTimerIndicator){
			timerTextIndicationPanel.alpha += 0.05f;
			Invoke("showTimerTextIndicator",0.1f);
		} else if(timerTextIndicationPanel.alpha > 0.0f){
			isTimerIndicator = true;
			timerTextIndicationPanel.alpha -= 0.05f;
			Invoke("showTimerTextIndicator",0.1f);
		} else {
			timerTextIndicationPanel.alpha = 0.0f;
			isTimerIndicator = false;
		}
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
}
