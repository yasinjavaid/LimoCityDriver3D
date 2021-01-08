using UnityEngine;
using System.Collections;

public class ParametersDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		guiText.text="Heigth   : "+CameraControl.height+"\n Distance  : "+CameraControl.distance;
	}
}
