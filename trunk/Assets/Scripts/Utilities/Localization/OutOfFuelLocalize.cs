using UnityEngine;
using System.Collections;

public class OutOfFuelLocalize : MonoBehaviour {

	
	public UILabel outOfFuellbl;
	
	public UILabel fiveLTRlbl;	
	public UILabel tenLTRlbl;
	public UILabel twentyLTRlbl;
	
	public UILabel twentyfiveCoinslbl;	
	public UILabel fiftyCoinslbl;	
	public UILabel seventyFiveCoinslbl;	
	
	
	void Start () {
		GAManager.Instance.LogDesignEvent("levelOutOfFuel:"+"Level"+UserPrefs.currentLevel+"Episode"+UserPrefs.currentEpisode);
		
		outOfFuellbl.GetComponent<UILabel>().text = Localization.instance.Get("outOfFuel");
		fiveLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageOneFuel.ToString() +ConstantsNew.space + Localization.instance.Get("LTR");
		tenLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageTwoFuel.ToString() + ConstantsNew.space +Localization.instance.Get("LTR");
		twentyLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageThreeFuel.ToString() +ConstantsNew.space + Localization.instance.Get("LTR");
				
		twentyfiveCoinslbl.GetComponent<UILabel>().text   = ConstantsNew.outOfFuelPackageOneCoins.ToString() +ConstantsNew.space +Localization.instance.Get("Coins");
		fiftyCoinslbl.GetComponent<UILabel>().text        = ConstantsNew.outOfFuelPackageTwoCoins.ToString() +ConstantsNew.space + Localization.instance.Get("Coins");
		seventyFiveCoinslbl.GetComponent<UILabel>().text  = ConstantsNew.outOfFuelPackageThreeCoins .ToString() +ConstantsNew.space +Localization.instance.Get("Coins");
	}
}
