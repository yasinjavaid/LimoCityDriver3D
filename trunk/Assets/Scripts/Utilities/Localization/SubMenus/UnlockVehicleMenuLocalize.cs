using UnityEngine;
using System.Collections;

public class UnlockVehicleMenuLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblRequiredCoins;
	public UILabel lblTitle;
	
	// Use this for initialization
	void Start () {
		GAManager.Instance.LogDesignEvent("vehiclePressed");
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUnlockVehicleMenuLocalize");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUnlockVehicleMenuLocalize");
		SetDescription();
//		lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockVehicleMenuLocalize");
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void SetDescription()
	{
		switch(UserPrefs.currentFontVehicle)
		{
		case 0:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockVehicle1MenuLocalize");
			lblRequiredCoins.GetComponent<UILabel>().text = Localization.instance.Get("LblRequiredCoinsUnlockVehicle1MenuLocalize");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblVehicleTitleUnlockVehicle1MenuLocalize");
		
			break;
		case 2:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockVehicle2MenuLocalize");
			lblRequiredCoins.GetComponent<UILabel>().text = ConstantsNew.SecondVehicle_Unlock_Coins.ToString()+" "+ Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblVehicleTitleUnlockVehicle2MenuLocalize");
			if(UserPrefs.totalCoins>=ConstantsNew.SecondVehicle_Unlock_Coins)
		{
			
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		}
		else 
		{
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextSkipLevel")+" "+ (ConstantsNew.SecondVehicle_Unlock_Coins-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredSkipLevel");
		}
			break;
		case 1:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockVehicle3MenuLocalize");
			lblRequiredCoins.GetComponent<UILabel>().text = ConstantsNew.ThirdVehicle_Unlock_Coins.ToString()+" "+ Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblVehicleTitleUnlockVehicle3MenuLocalize");
		if(UserPrefs.totalCoins>=ConstantsNew.ThirdVehicle_Unlock_Coins)
		{
			
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		}
		else 
		{
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextSkipLevel")+" "+ (ConstantsNew.ThirdVehicle_Unlock_Coins-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredSkipLevel");
		}
			break;
		}
	}
}
