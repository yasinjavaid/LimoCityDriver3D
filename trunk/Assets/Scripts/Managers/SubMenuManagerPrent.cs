using UnityEngine;
using System.Collections;

public class SubMenuManagerPrent : SingeltonBase<SubMenuManagerPrent>  {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	
	
	public void SwitchMenu(GameManager.GameState currentGameState){
	
		if(isNewMenu())
		{
			SubMenusNew.Instance.SwitchMenu(currentGameState);
				
		}
		else
		{
			SubMenusOld.Instance.SwitchMenu(currentGameState);
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
