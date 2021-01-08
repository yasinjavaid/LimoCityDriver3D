using UnityEngine;
using System.Collections;

public class OpenDoors : MonoBehaviour {
	
	public static bool openDoor=false;
	public static bool closeDoor=false;
	// Use this for initialization
	void Start () 
	{
		openDoor=false;
		closeDoor=false;
	}
	
	// Update is called once per frame
	void Update () {
	//	transform.Rotate(Vector3.forward,Time.deltaTime*20);
		if(openDoor && !closeDoor)
			OpenDoor();
		if(!openDoor && closeDoor)
			CloseDoor();
		

	}
	void OpenDoor()
	{
		if(transform.localEulerAngles.y>290 || transform.localEulerAngles.y<1)
			transform.Rotate(new Vector3(0,0,-90),Time.deltaTime*20);
		else
			openDoor=false;
			
	}
	void CloseDoor()
	{
		if(transform.localEulerAngles.y>1)
			transform.Rotate(new Vector3(0,0,90),Time.deltaTime*20);
		else
			closeDoor=false;
		
	}
	void OnGUI()
	{
//		if(GUI.Button(new Rect(0,Screen.height*0.5f,100,50),"Open"))
//		{
//			openDoor=true;
//			closeDoor=false;
//			
//		}if(GUI.Button(new Rect(0,Screen.height*0.6f,100,50),"close"))
//		{
//			openDoor=false;
//			closeDoor=true;
//		}
		
	}
}
