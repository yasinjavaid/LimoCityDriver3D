using UnityEngine;
using System.Collections;

public class UnlockLevelMenuLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblRequiredCoins;
	public UILabel lblTitle;
	
	// Use this for initialization
	void Start () {
		GAManager.Instance.LogDesignEvent("episodePressed");
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUnlockLevelMenuLocalize");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUnlockLevelMenuLocalize");
		
		SetDescription();
		//lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	 void SetDescription()
	{
		switch(UserPrefs.currentFontEpisode)
		{
		case 0:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockLevel1MenuLocalize");
//			lblRequiredCoins.GetComponent<UILabel>().text = Localization.instance.Get("LblRequiredCoinsUnlockLevel1MenuLocalize")+ConstantsNew.space+Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblLevelUnlockTitleUnlockLevel1MenuLocalize");
			
			break;
		case 2:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockLevel2MenuLocalize");
		lblRequiredCoins.GetComponent<UILabel>().text = ConstantsNew.SecondEpisode_Unlock_Coins.ToString()+" "+ Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblLevelUnlockTitleUnlockLevel2MenuLocalize");
			if(UserPrefs.totalCoins>=ConstantsNew.SecondEpisode_Unlock_Coins)
		{
			
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		}
		else 
		{
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextSkipLevel")+" "+ (ConstantsNew.SecondEpisode_Unlock_Coins-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredSkipLevel");
		}
			break;
		case 1:
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblDescriptionUnlockLevel3MenuLocalize");
		lblRequiredCoins.GetComponent<UILabel>().text = ConstantsNew.ThirdEpisode_Unlock_Coins.ToString()+" "+ Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblLevelUnlockTitleUnlockLevel3MenuLocalize");
			if(UserPrefs.totalCoins>=ConstantsNew.ThirdEpisode_Unlock_Coins)
		{
			
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		}
		else 
		{
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextSkipLevel")+" "+ (ConstantsNew.ThirdEpisode_Unlock_Coins-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredSkipLevel");
		}
			break;
		}
	}
	
}
