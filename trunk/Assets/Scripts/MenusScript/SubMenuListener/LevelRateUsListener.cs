using UnityEngine;
using System.Collections;

public class LevelRateUsListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnRateUs")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		
		if(this.gameObject.name.Equals("btnRateUs"))
		{
			RateUs();
		}
		else if(this.gameObject.name.Equals("btnSkip"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}	
	}
	
	
	void RateUs(){
			
		Debug.Log("makert called.2 ");
		if(UserPrefs.isAmazonBuild){
			 Application.OpenURL(ConstantsNew.AMAZON_RATEUS_LINK); 
	   	} 
		else 
		{
			#if UNITY_ANDROID
	  		  Application.OpenURL ( ConstantsNew.ANDROID_RATEUS_LINK);
			#endif
			
			
			#if UNITY_IPHONE		
			Application.OpenURL(ConstantsNew.IOS7_RATEUS_LINK);
			
			/*
			string iOSVersion = SystemInfo.operatingSystem.Split('.')[0];
			float sysVersion;
			Debug.Log("sysVersion");
			if(float.TryParse(iOSVersion, out sysVersion)){
				if(sysVersion >= 7)
					Application.OpenURL(ConstantsNew.IOS7_RATEUS_LINK);
			else
					Application.OpenURL(ConstantsNew.IOS_RATEUS_LINK);	
			}
			*/
			#endif
	   }
		UserPrefs.isRatesUS = true;
		GameManager.Instance.SubmitAchievement();
	    Destroy ( GameObject.FindGameObjectWithTag ( "RateUs" ) ) ;
	    Resources.UnloadUnusedAssets();
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELCOMPLETE);
   
  
	}
}
