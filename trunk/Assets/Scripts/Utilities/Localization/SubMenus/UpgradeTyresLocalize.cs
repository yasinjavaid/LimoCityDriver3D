using UnityEngine;
using System.Collections;

public class UpgradeTyresLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblMoreCoinsRequired;
	public UILabel lblRequiredCoins;
	public UILabel lblTyresTitle;
	// Use this for initialization
	void Start () {
	
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].tiresCurrentUpgradeLevel-1 ];
		
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUpgradeTyres");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUpgradeTyres");
		lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUpgradeTyres");
		
	
		
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSTYRESUPGRADE)
		{
			
		//	lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeEngine");
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeTyres")+" "+ (coinsRequire-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredUpgradeTyres");
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMTYRESUPGRADE)
		{
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockVehicleMenuLocalize");
		}
		lblRequiredCoins.GetComponent<UILabel>().text = coinsRequire.ToString()+ " "+ Localization.instance.Get("Coins");
		lblTyresTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblTyresTitleUpgradeTyres");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
