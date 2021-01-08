using UnityEngine;
using System.Collections;

public class VehicleSelectionMenuLocalize : MonoBehaviour {

	
	public UILabel coinslbl;
	public UILabel selectlevellbl;
	public UILabel settingslbl;
	public UILabel nextBtnlbl;
	public UILabel getCoinsBtnlbl;
	
	public UILabel firstVehicleNamelbl;
	public UILabel secondVehicleNamelbl;
	public UILabel thirdVehicleNamelbl;
				
	
	public UILabel secondVehicleunlockCoinslbl;
	public UILabel thirdVehicleunlockCoinslbl;
	
	
	void Start () {
	
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		selectlevellbl.GetComponent<UILabel>().text = Localization.instance.Get("SELECT_VEHICLE");
		settingslbl.GetComponent<UILabel>().text = Localization.instance.Get("Settings");
		nextBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("NEXT");
		getCoinsBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("GET_COINS");
		
		
		firstVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_1_Name");;
		secondVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_2_Name");;
		thirdVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_3_Name");;
		
		secondVehicleunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.SecondVehicle_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");
		thirdVehicleunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.ThirdVehicle_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");
	}
	
	public void updateCoions(){
		Debug.Log("Coins updated");
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}
}
