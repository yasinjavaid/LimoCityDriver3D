using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class GoogleGameCenter :MonoBehaviour, SignInCallBacks, LeaderboardListener, PictureCallBacks 
{
	
	PlayServicesHandler handler;
		
	public GoogleGameCenter()
	{
			
	}
	
	public void Initialize()
	{
		handler =  GameObject.FindGameObjectWithTag("PlayServiceManager").GetComponent<PlayServicesHandler>();
			handler.setSignInCallBackListerner(this);
			handler.setLeaderboardListerner(this);
			handler.setPictureCallBackListner(this);
	}
	GUIText txt;
		
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
//		public bool status()
//		{
//		//	return handler.signedIn();
//		}
		public void GPSSignIn()
		{	
			handler.SignInToServices();
		
		}
		
		public void GPSSignOut()
		{
			handler.SignOutFromServices();
		}
		
		public void GPSStartRandomGame()
		{	handler.StartRandomGame();
		}
		
		public void GPSEndMultiplayerGame()
		{	handler.EndMultiplayerGame();
		}
		
		public void GPSSendMessageRTMP()
		{	handler.SendMessageRTMP("Test");
		}
		
		public void GPSDisplayAchievement()
		{
			handler.displayAchievement();
		}
		
		public void GPSInvitePlayers()
		{	handler.invitePlayers();
		}
		
		public void GPSUnlockAchievement(string achID)
		{	
			handler.unlockAchievement(achID);
		}
		
		public void GPSShowInvitations()
		{	handler.showInvitations();
		}
		
		public void GPSAcceptInvitationPopup()
		{	handler.acceptInvitationPopup();
		}
						
		public void GPSIncrementAchievement(string achID, int count)
		{	handler.incrementAchievement(achID,count);
		}
		
		public void GPSDisplayLeaderboard(string lbID)
		{	handler.displayLeaderboard(lbID);
		}
	
		public void GPSDisplayAllLeaderboards()
		{	
			handler.displayAllLeaderboards();
		}
		
		public void GPSPostScoreToLeaderboard(string lbID, int score)
		{	handler.postScoreToLeaderboard(lbID,score);
		}
		
				
		public void GPSLoadUserDisplayPict()
		{	handler.loadUserDisplayPic();
		}
		
		public void GPSLoadOpponentDisplayPics()
		{handler.loadOpponentDisplayPics();
		}
		
		  
	
	
	public void SignInSucceeded(){
		print ("Call back called: SignInSucceeded");
		UserPrefs.isGoogleSignedIn = true;
		
	}
	
	public void SignInFailed(){
		print ("Call back called: SignInFailed");
		//UserPrefs.isGoogleSignedIn = false;
	}
	
	public void scoreSubmitted(bool highScore){
		print ("Call back called: highscore: "+highScore.ToString());
	}
	
	public void CurrentUserPictureLoaded(Texture2D tex){
		print("Picture loaded self");
		GameObject.Find("tex").GetComponent<GUITexture>().texture = tex;
	}
	
	public void OpponentPictureLoaded(string id,Texture2D tex){
		print("Picture loaded opponent");
		GameObject.Find("tex2").GetComponent<GUITexture>().texture = tex;
	}

}
#endif	
