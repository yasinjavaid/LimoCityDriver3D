using UnityEngine;
using System.Collections;

public class TutorialDialogPosition : MonoBehaviour {
	
	private UIPanel uIPanel;
	// Use this for initialization
	void Start () {
		uIPanel = this.gameObject.GetComponent<UIPanel>();
		setTutorialDialogPosition();
	}
	
	// Update is called once per frame
	void Update () {
		if(uIPanel.alpha < 1.0f){
			uIPanel.alpha = uIPanel.alpha + 0.01f;
		}
	}
	
	private void setTutorialDialogPosition(){
		switch(UserPrefs.TutorialStep){
			case 1:
				this.gameObject.transform.localPosition = new Vector3(-300f,-150f,0f);
				break;
			case 2:
				this.gameObject.transform.localPosition = new Vector3(300f,-150f,0f);
				break;
			case 3:
				this.gameObject.transform.localPosition = new Vector3(-300f,150f,0f);
				break;			
			case 4:
				this.gameObject.transform.localPosition = new Vector3(200f,250f,0f);
				break;
			case 5:
				this.gameObject.transform.localPosition = new Vector3(0f,250f,0f);
				break;
			case 6:
				this.gameObject.transform.localPosition = new Vector3(0f,250f,0f);
				break;
			case 7:
				this.gameObject.transform.localPosition = new Vector3(0f,250f,0f);
				break;
			case 8:
				this.gameObject.transform.localPosition = new Vector3(0f,250f,0f);
				break;
			default:
				this.gameObject.transform.localPosition = new Vector3(0f,0f,0f);
				break;
			
		}
	}
}
