using UnityEngine;
using System.Collections;

public class ButtonPosition : MonoBehaviour {
	
	public GameObject leftButton = null;
	public GameObject rightButton = null;
	
	// Use this for initialization
	void Start () {
		setButtonPositions();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void setButtonPositions()
	{
		Debug.LogError("Set Buttons Position : "+Screen.width);		
						
		if(Screen.width >= 1136)
		{
			
			Debug.Log ("Here");
			if(leftButton!=null){
				Vector3 templeft = leftButton.transform.localPosition;
				templeft.x -= 170.0f;
				leftButton.transform.localPosition = new Vector3(templeft.x, templeft.y, templeft.z);
			}
			if(rightButton!=null)
			{
				Debug.LogError("Right btn");
				Vector3 tempRight = rightButton.transform.localPosition;			
				tempRight.x += 160.0f;
				rightButton.transform.localPosition = new Vector3(tempRight.x, tempRight.y, tempRight.z);
			}
		}		
	}
}
