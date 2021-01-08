using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		MenuManager.Instance.StartNewMenus();
	/*	GameObject temp = GameObject.FindGameObjectWithTag("Background");
		
		if(temp == null){
			Instantiate(Resources.Load("SubMenus/Background"));
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
