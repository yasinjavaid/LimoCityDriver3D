using UnityEngine;
using System.Collections;

public class HudMenuLocalize : MonoBehaviour {
	
	
	public UILabel lbCoins;
	public UILabel lbCoveredDistance ;
	public UILabel lbDistance1 ;
	public UILabel lbDistance2 ;
	public UILabel lbTotalDistance ;
	public UILabel lbSpot ;
	public UILabel lbTime ;
	public UILabel lbTimeRemaining ;

	// Use this for initialization
	void Start () {
	
		Debug.Log("Coins.ToString= "+UserPrefs.totalCoins.ToString());
//		lbCoveredDistance.GetComponent<UILabel>().text =     LocalizableString.lbCoveredDistance.ToString();
//		lbDistance1.GetComponent<UILabel>().text =     LocalizableString.lbDistance1.ToString();
//		lbDistance2.GetComponent<UILabel>().text =     LocalizableString.lbDistance2.ToString();
//		lbTotalDistance.GetComponent<UILabel>().text =     LocalizableString.lbTotalDistance.ToString();
		lbSpot.GetComponent<UILabel>().text = UserPrefs.currentLevel.ToString();
		lbTime.GetComponent<UILabel>().text =     Localization.instance.Get("lbTime");   
		//lbTimeRemaining.GetComponent<UILabel>().text =     LocalizableString.lbTimeRemaining.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		lbTimeRemaining.GetComponent<UILabel>().text =   UserPrefs.remainingtTimeForCurrentLevel;
		lbCoins.GetComponent<UILabel>().text =string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}
}
