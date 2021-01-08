using UnityEngine;
using System.Collections;

public class LevelCompleteMenuLocalize : MonoBehaviour {
	
	public UILabel lblCompleteTitle;
	public UILabel lblEarnedCoins;
	public UILabel lblyouEarned;
	public UILabel lblBtnContinue;
	public UILabel lblCoinsText;
	public UILabel lblEpisodeEnd;
	
	public GameObject levelComplePanel;
	public GameObject episodeCompletePanel;
	
	
	// Use this for initialization
	void Start () {
		GAManager.Instance.LogDesignEvent("levelComple:"+"Level"+UserPrefs.currentLevel+"Episode"+UserPrefs.currentEpisode);
		lblCompleteTitle.GetComponent<UILabel>().text = Localization.instance.Get("LevelCompleteTitle");
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode){
			NGUITools.SetActive(levelComplePanel,false);
			NGUITools.SetActive(episodeCompletePanel,true);
			setEpisodeMessage();			
		}
		else{
			NGUITools.SetActive(levelComplePanel,true);
			NGUITools.SetActive(episodeCompletePanel,false);	
			lblyouEarned.GetComponent<UILabel>().text =  Localization.instance.Get("YouEarned");
			lblEarnedCoins.GetComponent<UILabel>().text = Localization.instance.Get("Plus")+ ConstantsNew.Coins_Level_Success.ToString();
			lblBtnContinue.GetComponent<UILabel>().text =  Localization.instance.Get("LblBtnContinueLevelCrashMenuNew");
			lblCoinsText.GetComponent<UILabel>().text =  Localization.instance.Get("Coins");
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void setEpisodeMessage(){
		string epiSodeName = "" ;
		switch (UserPrefs.currentEpisode){
			case 1:
				epiSodeName = Localization.instance.Get("Episode_1_Name"); 
				break;
			case  2:
				epiSodeName = Localization.instance.Get("Episode_2_Name"); 
				break;
			case 3:	
				epiSodeName = Localization.instance.Get("Episode_3_Name"); 
				break;
		}
		lblEpisodeEnd.GetComponent<UILabel>().text = Localization.instance.Get("episodeEndMessage1")+ConstantsNew.space+epiSodeName+Localization.instance.Get("episodeEndMessage2");
	}
}
