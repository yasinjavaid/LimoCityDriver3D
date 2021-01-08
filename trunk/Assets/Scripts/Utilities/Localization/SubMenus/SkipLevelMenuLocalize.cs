using UnityEngine;
using System.Collections;

public class SkipLevelMenuLocalize : MonoBehaviour {

	public UILabel lblBtnUnlockText;
	public UILabel lblCoinsRequiredText;
	public UILabel lblDescription;
	public UILabel lblEnoughCoinsText;
	public UILabel lblRequiredCoins;
	public UILabel lblTitle;
	
	// Use this for initialization
	void Start () {
	
		lblBtnUnlockText.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnUnlockTextUnlockLevelMenuLocalize");
		lblCoinsRequiredText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsRequiredTextUnlockLevelMenuLocalize");
		
		
//		lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		
			lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("SkipLevelDescription");
			lblRequiredCoins.GetComponent<UILabel>().text = ConstantsNew.SKIP_LEVEL_COINS.ToString()+" "+ Localization.instance.Get("Coins");
			lblTitle.GetComponent<UILabel>().text = Localization.instance.Get("SkipLevelTitle");
		
		if(UserPrefs.totalCoins>=ConstantsNew.SKIP_LEVEL_COINS)
		{
			
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextUnlockLevelMenuLocalize");
		}
		else 
		{
			lblEnoughCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblEnoughCoinsTextSkipLevel")+" "+ (ConstantsNew.SKIP_LEVEL_COINS-UserPrefs.totalCoins)+" "+ Localization.instance.Get("LblMoreCoinsRequiredSkipLevel");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
