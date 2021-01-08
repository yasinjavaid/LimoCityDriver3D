using UnityEngine;
using System.Collections;

public class EpisodeMenuLocalize : MonoBehaviour {

	
	public UILabel coinslbl;
	public UILabel selectlevellbl;
	public UILabel settingslbl;
	public UILabel vehicleBtnlbl;
	public UILabel nextBtnlbl;
	public UILabel getCoinsBtnlbl;
	
	public UILabel firstepisodeNamelbl;
	public UILabel secondepisodeNamelbl;
	public UILabel thirdepisodeNamelbl;
	

	public UILabel firstepisodeBestDistancelbl;
	public UILabel secondepisodeBestDistancelbl;
	public UILabel thirdepisodeBestDistancelbl;
	
	
	
	public UILabel firstepisodeBestWordlbl;
	public UILabel secondepisodeBestWordlbl;
	public UILabel thirdepisodeBestWordlbl;
	
	
	public UILabel firstepisodeSpotWordlbl;
	public UILabel secondepisodeSpotWordlbl;
	public UILabel thirdepisodeSpotWordlbl;
	
	
	public UILabel firstEpisodeCompletedlbl;
	public UILabel secondEpisodeCompletedlbl;
	public UILabel thirdEpisodeCompletedlbl;
	
	public UILabel secondepisodeunlockCoinslbl;
	public UILabel thirdepisodeunlockCoinslbl;
	
	void Start () {
	

		
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
		firstepisodeNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_1_Name");
		secondepisodeNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_2_Name");
		thirdepisodeNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_3_Name");

		
/*		selectlevellbl.GetComponent<UILabel>().text = LocalizableString.SELECT_LEVEL;
		settingslbl.GetComponent<UILabel>().text = LocalizableString.Settings;
		vehicleBtnlbl.GetComponent<UILabel>().text = LocalizableString.VEHICLE;
		nextBtnlbl.GetComponent<UILabel>().text = LocalizableString.NEXT;
		getCoinsBtnlbl.GetComponent<UILabel>().text = LocalizableString.GET_COINS;
	
		
		firstepisodeNamelbl.GetComponent<UILabel>().text = LocalizableString.Episode_1_Name;
		secondepisodeNamelbl.GetComponent<UILabel>().text = LocalizableString.Episode_2_Name;
		thirdepisodeNamelbl.GetComponent<UILabel>().text = LocalizableString.Episode_3_Name;
	*/	
		
//		firstepisodeBestDistancelbl.GetComponent<UILabel>().text = LocalizableString.Episode_1_BESTDistance;
//		secondepisodeBestDistancelbl.GetComponent<UILabel>().text = LocalizableString.Episode_2_BESTDistance;
//		thirdepisodeBestDistancelbl.GetComponent<UILabel>().text = LocalizableString.Episode_3_BESTDistance;
		
		
//		firstepisodeBestWordlbl.GetComponent<UILabel>().text = LocalizableString.Episode_BESTWORD;
//		secondepisodeBestWordlbl.GetComponent<UILabel>().text = LocalizableString.Episode_BESTWORD;
//		thirdepisodeBestWordlbl.GetComponent<UILabel>().text = LocalizableString.Episode_BESTWORD;
		
		
		
		firstepisodeSpotWordlbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_SPOTWORD");
		secondepisodeSpotWordlbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_SPOTWORD");
		thirdepisodeSpotWordlbl.GetComponent<UILabel>().text = Localization.instance.Get("Episode_SPOTWORD");
			
		
		firstEpisodeCompletedlbl.GetComponent<UILabel>().text =  UserPrefs.unlockLevelsArrays[0].ToString();
		secondEpisodeCompletedlbl.GetComponent<UILabel>().text =  UserPrefs.unlockLevelsArrays[1].ToString();
		thirdEpisodeCompletedlbl.GetComponent<UILabel>().text = UserPrefs.unlockLevelsArrays[2].ToString();
		
		secondepisodeunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.SecondEpisode_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");
		thirdepisodeunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.ThirdEpisode_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");
				
	}
	public void updateCoions(){
		Debug.LogError("Coins updated");
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}
}
