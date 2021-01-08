using UnityEngine;
using System.Collections;

public class TutorialColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void  OnTriggerEnter (Collider collisionInfo){
		
		if(collisionInfo.tag == "Player"){			
			if(UserPrefs.TutorialStep == 4){
				TutorialManager.Instance.showPassengerIndicator();
				Destroy(this.gameObject);
			}
			else if(UserPrefs.TutorialStep == 7){
				TutorialManager.Instance.showTraficSingleWait();				
				Destroy(this.gameObject);
			}
		}
	}
	
	
}
