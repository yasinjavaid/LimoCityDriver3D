using UnityEngine;
using System.Collections;

public class AnimationBottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	        iTween.MoveFrom(  this.gameObject, iTween.Hash(  "y",  -3f,  "time", 1.5  )  ); 
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
