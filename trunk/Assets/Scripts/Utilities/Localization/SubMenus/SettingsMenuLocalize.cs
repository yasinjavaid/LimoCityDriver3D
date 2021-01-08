using UnityEngine;
using System.Collections;

public class SettingsMenuLocalize : MonoBehaviour {
	
	public UILabel coinslbl;
	public UILabel getMoreCoinslbl;
	public UILabel settingslbl;
	public UILabel backBtnlbl;
	public UILabel lblMusic;
	public UILabel lblSound;
	
	
	
	// Use this for initialization
	void Start () {
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		getMoreCoinslbl.GetComponent<UILabel>().text = Localization.instance.Get("Settings");
		settingslbl.GetComponent<UILabel>().text = Localization.instance.Get("SettingsSettingsMenuNew");
		backBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("BackSettingsMenuNew");
		lblMusic.GetComponent<UILabel>().text = Localization.instance.Get("MusicSettingsMenuNew");
		lblSound.GetComponent<UILabel>().text = Localization.instance.Get("SoundSettingsMenuNew");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void updateCoions(){
		Debug.LogError("Coins updated");
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}

}
