using UnityEngine;
using System.Collections;

public class LevelInstructionMenuLocalize : MonoBehaviour {
	
	public UILabel lblInstructionTitle;
	public UILabel lblInstructionsDesc;
	
	
	
	// Use this for initialization
	void Start () {
		lblInstructionTitle.GetComponent<UILabel>().text = Localization.instance.Get("LevelInstructionsTitle");
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.PICKPASSENGERINSTRUCTIONS)
		{
			lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("PICKPASSENGERINSTRUCTIONS");
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.DROPPASSENGERINSTRUCTIONS)
		{
			lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("DROPPASSENGERINSTRUCTIONS") + " "   +  UserPrefs.remainingtTimeForCurrentLevel  + " " + Localization.instance.Get("DROPPASSENGERINSTRUCTIONS2");
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
