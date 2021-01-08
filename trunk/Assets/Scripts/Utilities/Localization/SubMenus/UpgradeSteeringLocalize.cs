using UnityEngine;
using System.Collections;

public class UpgradeSteeringLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblMoreCoinsRequired;
	public UILabel lblRequiredCoins;
	public UILabel lblSteeringTitle;
	// Use this for initialization
	void Start () {
	
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel-1 ];
		
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUpgradeSteering");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUpgradeSteering");
		lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUpgradeSteering");
		
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSSTEERINGUPGRADE)
		{
			
		//	lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeEngine");
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeSteering")+" "+ (coinsRequire-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredUpgradeSteering");
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMSTEERINGUPGRADE)
		{
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockVehicleMenuLocalize");
		}
		lblRequiredCoins.GetComponent<UILabel>().text = coinsRequire.ToString()+ " "+ Localization.instance.Get("Coins");
		
		
		lblSteeringTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblSteeringTitleUpgradeSteering");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
