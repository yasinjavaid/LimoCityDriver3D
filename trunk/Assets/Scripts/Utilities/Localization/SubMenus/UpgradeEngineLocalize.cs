using UnityEngine;
using System.Collections;

public class UpgradeEngineLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblMoreCoinsRequired;
	public UILabel lblRequiredCoins;
	public UILabel lblEngineTitle;
	// Use this for initialization
	void Start () {
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ];
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUpgradeEngine");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUpgradeEngine");
		lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUpgradeEngine");
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSENGINEUPGRADE)
		{
			
		//	lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeEngine");
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeEngine")+" "+ (coinsRequire-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredUpgradeEngine");
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMENGINEUPGRADE)
		{
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockVehicleMenuLocalize");
		}
		lblRequiredCoins.GetComponent<UILabel>().text = coinsRequire.ToString()+ " "+ Localization.instance.Get("Coins");
		lblEngineTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblEngineTitleUpgradeEngine");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
