using UnityEngine;
using System.Collections;

public class UpgradeBreaksLocalize : MonoBehaviour {
	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblMoreCoinsRequired;
	public UILabel lblRequiredCoins;
	public UILabel lblBreaksTitle;
	// Use this for initialization
	void Start () {
	
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ];
			
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUpgradeBreaks");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUpgradeBreaks");
		lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUpgradeBreaks");
		
		
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSBRAKESUPGRADE)
		{
			//	lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeEngine");
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUpgradeBreaks")+" "+ (coinsRequire-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredUpgradeBreaks");
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMBRAKESUPGRADE)
		{
			lblMoreCoinsRequired.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockVehicleMenuLocalize");
		}
		
		
		lblRequiredCoins.GetComponent<UILabel>().text = coinsRequire.ToString()+ " "+ Localization.instance.Get("Coins");
		lblBreaksTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblBreaksTitleUpgradeBreaks");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
