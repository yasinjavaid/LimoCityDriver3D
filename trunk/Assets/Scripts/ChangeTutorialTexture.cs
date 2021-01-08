using UnityEngine;
using System.Collections;

public class ChangeTutorialTexture : MonoBehaviour {
	
	  
	public Texture imageLeft;
	public Texture imageRight;
	public Texture image_bottom_left;
	public Texture image_bottom_right;
	public Texture image_top_left;
	public Texture image_top_right;
	
	// Use this for initialization
	void Start () {
		
		setTutorialTexture();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void setTutorialTexture(){
		
		UITexture uitx = this.gameObject.GetComponent<UITexture>();
		
		switch(UserPrefs.TutorialStep){
			case 1:
				uitx.mainTexture = imageLeft;
				break;
			case 2:
				uitx.mainTexture = imageRight;
				break;
			case 3:
				uitx.mainTexture = image_top_left;
				break;			
			case 4:
				uitx.mainTexture = image_bottom_right;
				break;
			case 5:
				uitx.mainTexture = image_bottom_left;
				break;
			case 6:
				uitx.mainTexture = image_bottom_right;
				break;
			case 7:
				uitx.mainTexture = image_bottom_right;
				break;
			case 8:
				uitx.mainTexture = image_bottom_right;
				break;
			default:
				uitx.mainTexture = image_bottom_left;
				break;
			
		}
	}
}
