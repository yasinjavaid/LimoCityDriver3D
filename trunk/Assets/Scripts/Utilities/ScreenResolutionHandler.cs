using UnityEngine;
using System.Collections;

public class ScreenResolutionHandler : MonoBehaviour {
	
	private float defaultRatio = Constants.SCREEN_WIDTH/ Constants.SCREEN_HEIGHT;



	// Use this for initialization
/*	void Awake() {
		float currRatio = (float)Screen.width/(float)Screen.height;
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(currRatio/defaultRatio,scale.y,scale.z);
		Debug.Log(transform.localScale.ToString());
	}*/
	
	void Awake(){

	//	PlayerPrefs.DeleteAll();

		float currRatio = (float)Screen.width/(float)Screen.height;		
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(currRatio/defaultRatio,scale.y,scale.z);
		
		Constants.XSCALE = currRatio/defaultRatio;
		
		//Debug.LogError(GC.xScale);
	}
}
