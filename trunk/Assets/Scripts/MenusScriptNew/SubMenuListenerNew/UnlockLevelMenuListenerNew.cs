using UnityEngine;
using System.Collections;

public class UnlockLevelMenuListenerNew : MonoBehaviour {
// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnClose")){
			//Destroy(GameObject.FindGameObjectWithTag("unlockLevelMenu"));
			Debug.Log("GameManager.Instance.GetPreviousGameState()"+GameManager.Instance.GetPreviousGameState());
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState()); 
		}
		
		if(this.name.Equals("btnUnlock")){
			if(UserPrefs.currentFontEpisode == 0){
			
			}
			else if(UserPrefs.currentFontEpisode == 1){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().UnlockEpisdoe(3);
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().updateOverlay();
			}
			else if (UserPrefs.currentFontEpisode == 2){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().UnlockEpisdoe(2);
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().updateOverlay();
			}
			else{				

				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListenerNew>().ChecktThePositionSprite4();
			}			
			EpisodeMenuListenerNew episodeMenu = GameObject.Find("Episode1").GetComponent<EpisodeMenuListenerNew>() as EpisodeMenuListenerNew;
			episodeMenu.setepiosdeCoinsPanel();
//			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
	}
}
