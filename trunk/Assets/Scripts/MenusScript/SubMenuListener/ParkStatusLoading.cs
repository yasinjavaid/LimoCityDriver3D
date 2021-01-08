using UnityEngine;
using System.Collections;

public class ParkStatusLoading : MonoBehaviour {
	UISlider parkingSlider;
	// Use this for initialization
	void Start () {
		if(this.gameObject.name=="ParkingStatusLoading"){
			parkingSlider = this.gameObject.GetComponent<UISlider>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(UserPrefs.parkingLotLoadingValue>0){
			parkingSlider.sliderValue = UserPrefs.parkingLotLoadingValue;
		}
	}
}
