using UnityEngine;
using System.Collections;

public class StoreMenuLocalize : MonoBehaviour {
	
	public UILabel coinslbl;
	public UILabel getMoreCoinslbl;
	public UILabel settingslbl;
	public UILabel backBtnlbl;
	
	public UILabel firstPackageCoinslbl;
	public UILabel secondPackageCoinslbl;
	public UILabel thirdPackageCoinslbl;
	public UILabel fourthPackageCoinslbl;
	public UILabel fifthPackageCoinslbl;
	
	public UILabel firstpackageDetailslbl;
	public UILabel secondpackageDetailslbl;
	public UILabel thirdpackageDetailslbl;
	public UILabel fourthpackageDetailslbl;
	
	
	public UILabel firstpackageAmountbl;
	public UILabel secondpackageAmountbl;
	public UILabel thirdpackageAmountbl;
	public UILabel fourthpackageAmountbl;
	public UILabel fifthpackageAmountbl;
	
	public UILabel currenylbl1;
	public UILabel currenylbl2;
	public UILabel currenylbl3;
	public UILabel currenylbl4;
	public UILabel currenylbl5;
	
	
	// Use this for initialization
	void Start () {
	
		coinslbl.GetComponent<UILabel>().text =  string.Format("{0:#,###0}", UserPrefs.totalCoins);
		getMoreCoinslbl.GetComponent<UILabel>().text = Localization.instance.Get("GetMore_Coins");
		settingslbl.GetComponent<UILabel>().text = Localization.instance.Get("Settings");
		backBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("Back");
		

		firstPackageCoinslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_1_AMOUNT;
		secondPackageCoinslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_2_AMOUNT;
		thirdPackageCoinslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_3_AMOUNT;
		fourthPackageCoinslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_4_AMOUNT;
		fifthPackageCoinslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_5_AMOUNT;
		
		firstpackageDetailslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_1_Detail;
		secondpackageDetailslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_2_Detail;
		thirdpackageDetailslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_3_Detail;
		fourthpackageDetailslbl.GetComponent<UILabel>().text = ConstantsNew.PACKAGE_4_Detail;

		firstpackageAmountbl.GetComponent<UILabel>().text = ConstantsNew.Coins_Package1Price;
		secondpackageAmountbl.GetComponent<UILabel>().text = ConstantsNew.Coins_Package2Price;
		thirdpackageAmountbl.GetComponent<UILabel>().text = ConstantsNew.Coins_Package3Price;
		fourthpackageAmountbl.GetComponent<UILabel>().text = ConstantsNew.Coins_Package4Price;
		fifthpackageAmountbl.GetComponent<UILabel>().text = ConstantsNew.Coins_Package5Price;
		
		currenylbl1.GetComponent<UILabel>().text =Localization.instance.Get("INAPP_CURRENCY");
		currenylbl2.GetComponent<UILabel>().text = Localization.instance.Get("INAPP_CURRENCY");
		currenylbl3.GetComponent<UILabel>().text = Localization.instance.Get("INAPP_CURRENCY");
		currenylbl4.GetComponent<UILabel>().text = Localization.instance.Get("INAPP_CURRENCY");
		currenylbl5.GetComponent<UILabel>().text = Localization.instance.Get("INAPP_CURRENCY");
	}
	
	public void updateCoions(){
		Debug.LogError("Coins updated");
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}
}
