using UnityEngine;
using System.Collections;

public class PauseMenuLocalize : MonoBehaviour {
	public UILabel lblBtnExit;
	public UILabel lblBtnRestart;
	public UILabel lblBtnResume;
	// Use this for initialization
	void Start () {
		lblBtnExit.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnExitPauseMenu");
		lblBtnRestart.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnRestartPauseMenu");
		lblBtnResume.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnResumePauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
