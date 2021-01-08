using UnityEngine;
using System.Collections;

public class TutorialManager : SingeltonBase<TutorialManager>  {
	
	private GameObject tutorialDialog; 
	private bool isBrakeMessageDisplayed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void startTutorial(){
		UserPrefs.TutorialStep = 1;
		Instantiate(Resources.Load("SubMenusNew/TutorialWithoutButton"));
		Invoke("MoveStepNext",5.0f);
		
	}
	
	private void MoveStepNext(){
		
		UserPrefs.TutorialStep = UserPrefs.TutorialStep + 1;
		
		tutorialDialog = GameObject.FindGameObjectWithTag("Tutorial02");
		if(tutorialDialog!= null){
			Destroy(tutorialDialog);
			Resources.UnloadUnusedAssets();
		}
		
		switch(UserPrefs.TutorialStep){
			case 1:
			case 2:
			case 3:
			case 5:
			case 8:
				Instantiate(Resources.Load("SubMenusNew/TutorialWithoutButton"));
				Invoke("MoveStepNext",5.0f);
			break;
		}
		
	}
	
	public void showPassengerIndicator(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND ,GameManager.GameState.Tutorial);
		Instantiate(Resources.Load("SubMenusNew/TutorialWithButton"));
	}
	
	public void setNormalGameState(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND ,GameManager.GameState.GAMEPLAY);
		
		tutorialDialog = GameObject.FindGameObjectWithTag("Tutorial01");
		if(tutorialDialog!= null){
			Destroy(tutorialDialog);
			Resources.UnloadUnusedAssets();
		}
		
		if(UserPrefs.TutorialStep == 7){
			Invoke("MoveStepNext",10.0f);
		} else {
			Invoke("MoveStepNext",1.0f);
		}
		
	}
	
	public void showTraficSingleWait(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND ,GameManager.GameState.Tutorial);
		Instantiate(Resources.Load("SubMenusNew/TutorialWithButton"));
	}
	
	public void showPressBrakeIndicator(){
		if(!isBrakeMessageDisplayed && UserPrefs.TutorialStep == 6){
			isBrakeMessageDisplayed = true;
			Instantiate(Resources.Load("SubMenusNew/TutorialWithoutButton"));
			Invoke("MoveStepNext",5.0f);
		}
	}
}
