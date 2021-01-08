using UnityEngine;
using System.Collections;

public class TestGamePlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// OnGUI is called once per frame
	void OnGUI(){
		
		//Left line
		if (GUI.Button(new Rect(0, 70, 150, 50), "Crashed")){
			GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CRASHED);
			Debug.Log("Crashed Btn Clicked");
		}
		
		if (GUI.Button(new Rect(0, 130, 150, 50), "Time Over")){
			GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND,GameManager.GameState.TIMEOVER);
			Debug.Log("Time Over Btn Clicked");
		}
		
		if (GUI.Button(new Rect(0, 190, 150, 50), "Level Complete")){
			Debug.Log("Level Complete Btn Clicked");
			GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND,GameManager.GameState.LEVELCOMPLETE);
			Debug.Log("Level Complete Btn Clicked");
		}
		
		if (GUI.Button(new Rect(0, 250, 150, 50), "Rate Us")){
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.RATEUS);
			Debug.Log("Rate Us Btn Clicked");
		}
        	
		//Right Line
		if (GUI.Button(new Rect(Screen.width-150, 70, 150, 50), "Store")){
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.STORE);
			Debug.Log("Bank Btn Clicked");
		}
		
		if (GUI.Button(new Rect(Screen.width-150, 130, 150, 50), "Thank you")){
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.THANKYOU);
			Debug.Log("Thank you Btn Clicked");
		}
		
		if (GUI.Button(new Rect(Screen.width-150, 190, 150, 50), "Out of Coins")){
			GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.OUTOFCOINS);
			Debug.Log("Out of Coins Btn Clicked");
		}
		
		
	}
}
