using UnityEngine;
using System.Collections;
using System;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public static float height;
	public static float distance;
	private bool upPressed,downPressed,leftPressed,rightPressed;
	
	void Start () {
		upPressed=false;
		downPressed=false;
		leftPressed=false;
		rightPressed=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(upPressed)
		{
			height=height+0.3f;
		}else if(downPressed)
		{
			height=height-0.3f;
		}else if(leftPressed)
		{
			distance=distance+0.3f;
			
		}else if(rightPressed)
		{
			distance=distance-0.3f;
		}
	
		
	}
	void OnPress (bool isDown)
	{
		Debug.Log("************************");
		if(this.name.Equals("Up"))
		{
			if(isDown)
			{
				upPressed=true;
			}else if(!isDown)
			{
				upPressed=false;
			}
		}
		else if(this.name.Equals("Down"))
		{
			if(isDown)
			{
				downPressed=true;
			}else if(!isDown)
			{
				downPressed=false;
			}
		}
		else if(this.name.Equals("Left"))
		{
			if(isDown)
			{
				leftPressed=true;
			}else if(!isDown)
			{
				leftPressed=false;
			}
		}
		else if(this.name.Equals("Right"))
		{
		if(isDown)
			{
				rightPressed=true;
			}else if(!isDown)
			{
				rightPressed=false;
			}
		}
		
}
}
