using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class PlayServicesHandler : MonoBehaviour {
	public struct OpponentData{
		public string opponentID;
		public string opponentName;
		public Texture2D opponentPicture;
	}
	GUIText txt;
	bool signedIn = false;
	bool gameRunning = false;
	private SignInCallBacks mSignInCallBacks;
	private LeaderboardListener mLeaderboardListener;
	private PictureCallBacks mPictureCallBacks;
	private RTMPCallBacks mRTMPCallBacks;
	public int minOpponents = 1;
	public int maxOpponents = 1;
	public Texture2D currentUserDisplayPic;
	public ArrayList opponents;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		AndroidJNI.AttachCurrentThread();
//		//txt = GameObject.Find("GUI Text").GetComponent<GUIText>();
	}
	
//	void callback(string message){
//		print ("Call back called.");
//		//txt.text = "Test Callback";
//	}
//	
//	public void sendMessageTojava(){
//		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
//
//			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
//
//				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
//				cls_CompassActivity.CallStatic("test");
//				
//			}
//		}	
//	}
	
	//User info
	
	public string getUserDisplayName(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return "NULL";
//		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				return cls_CompassActivity.CallStatic<string>("getCurrentPlayerDisplayName");
				
			}
		}
	}
	
	public string getUserID(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return "NULL";
//		}
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				return cls_CompassActivity.CallStatic<string>("getCurrentPlayerID");
				
			}
		}
	}
	
	public void loadUserDisplayPic(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("loadCurrentPlayerDisplayPic");
				
			}
		}
	}
	
	public void loadOpponentDisplayPics(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		if(!gameRunning){
			print ("Multiplayer game not started.");
			return ;
		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("loadOpponentDisplayPics");
				
			}
		}
	}
	
	//Call to RTMP
	
	public void SignInToServices(){
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("signInToServices");
				
			}
		}	
	}
	
	public void SignOutFromServices(){
		signedIn = false;
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("signOutFromServices");
				
			}
		}	
	}
	
	public void StartRandomGame(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		if(gameRunning){
			print ("Multiplayer game is in progress, please end previous game first.");
			return ;
		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("setOpponentCount",new object[]{minOpponents,maxOpponents});
				cls_CompassActivity.CallStatic("startRandomGame");
				
				if(opponents == null){
					opponents = new ArrayList();
				}
				else {
					opponents.Clear();
				}
				
				gameRunning = true;
				//txt.text = "Connecting... Please wait!";
				
			}
		}	
	}
	
	public void invitePlayers(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//		
		if(gameRunning){
			print ("Multiplayer game is in progress, please end previous game first.");
			return ;
		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("invitePlayers");
				
				if(opponents == null){
					opponents = new ArrayList();
				}
				else {
					opponents.Clear();
				}
				
				gameRunning = true;
				//txt.text = "Connecting... Please wait!";
			}
		}	
	}

	public void showInvitations(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		if(gameRunning){
			print ("Multiplayer game is in progress, please end previous game first.");
			return ;
		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("showInvitations");
				
				if(opponents == null){
					opponents = new ArrayList();
				}
				else {
					opponents.Clear();
				}
				//txt.text = "Connecting... Please wait!";
			}
		}	
	}
	
	public void acceptInvitationPopup(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		if(gameRunning){
			print ("Multiplayer game is in progress, please end previous game first.");
			return ;
		}
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("acceptInvitationPopup");
				
				if(opponents == null){
					opponents = new ArrayList();
				}
				else {
					opponents.Clear();
				}
				
				gameRunning = true;
				//txt.text = "Connecting... Please wait!";
			}
		}	
	}
	
	public void EndMultiplayerGame(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("endMultiplayerGame");
				
			}
		}	
	}
	
	public void SendMessageRTMP(string msg){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//		
		if(!gameRunning){
			print ("Multiplayer game not started.");
			return ;
		}
		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("sendRTMPMessage",msg);
				
			}
		}	
	}
	
	// Achievements
	
	public void unlockAchievement(string id){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//		
//		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("unloackAchievement",id);
				
			}
		}	
	}
	
	public void incrementAchievement(string id, int increment){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("incrementAchievement",new object[]{id,increment});
				
			}
		}	
	}
	
	public void displayAchievement(){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("displayAchievement");
				
			}
		}
	}
	
	public void postScoreToLeaderboard(string id, int score){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("postScore",new object[]{id,score});
				
			}
		}	
	}
	
	public void displayLeaderboard(string id){
//		if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
		
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				cls_CompassActivity.CallStatic("displayLeaderboard",id);
				
			}
		}	
	}
	
	public void displayAllLeaderboards(){

//	  if(!signedIn){
//			print ("User is not signed in.");
//			return ;
//		}
//	  
	  using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
	
	   using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
	
	    AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
	    cls_CompassActivity.CallStatic("displayAllLeaderboards");
	    
	   }
	  } 
	 }
	
	//Calls from RTMP
	
	void GameInvitationRecieved(string message){
		print ("Invitation from: " + message);
		//txt.text = "Invitation from: " + message;
		
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.GameInvitationRecieved(message);
		}
	}
	
	void RTMPisPreparing(string message){
		//print ("Call back called:" + message);
		//txt.text = "RTMP Preparing";
		
		gameRunning = true;
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPisPreparing();
		}
	}
	
	void RTMPStarted(string message){
		//print ("Call back called:" + message);
		//txt.text = "Game Started";
		gameRunning = true;
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPStarted();
		}
	}
	
	void RTMPisPreparingToEnd(string message){
		print ("Game is ending:" + message);
		//txt.text = "Game is ending:" + message;
		
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPisPreparingToEnd(message);
		}
	}
	
	void RTMPhasEnded(string message){
		print ("Game ended:" + message);
		//txt.text = "Game ended:" + message;
		gameRunning = false;
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPhasEnded(message);
		}
	}
	
	void RTMPPlayerAdded(string message){
		print ("Player added:" + message);
		//txt.text = "Player added:" + message;
		
		string[] temp = message.Split(',');
		OpponentData data = new OpponentData();
		data.opponentID = temp[0];
		data.opponentName = temp[1];
		opponents.Add(data);
		
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPPlayerAdded(temp[0],temp[1]);
		}
	}
	
	void RTMPPlayerDropped(string message){
		print ("Player dropped:" + message);
		//txt.text = "Player dropped:" + message;
		
		string[] temp = message.Split(',');
		
		foreach (OpponentData op in opponents) {
			if(op.opponentID.Equals(temp[0])){
				opponents.Remove(op);
				break;
			}
		}
		
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPPlayerDropped(temp[0],temp[1]);
		}
		
	}
	
	void RTMPMessageRecieved(string message){
		print ("Message Recieved:" + message);
		//txt.text = "Message Recieved:" + message;
		
		string[] temp = message.Split(',');
		
		if(mRTMPCallBacks != null){
			mRTMPCallBacks.RTMPMessageRecieved(temp[0],temp[1]);
		}
	}
	
	void SignInSucceeded(string message){
		
		//txt.text = "SignInSucceeded";
		signedIn = true;
		
		if(mSignInCallBacks != null){
			mSignInCallBacks.SignInSucceeded();
		}
	}
	
	void SignInFailed(string message){

		//txt.text = "SignInFailed";
		signedIn = false;
		
		if(mSignInCallBacks != null){
			mSignInCallBacks.SignInFailed();
		}
	}
	
	void scoreSubmitted(string message){
		//print ("Call back called: Score submitted");
		//txt.text = "score submitted: " + message;
		
		if(mLeaderboardListener != null){
			if(message.Equals("NULL")){
				mLeaderboardListener.scoreSubmitted(false);
			}
			else{
				mLeaderboardListener.scoreSubmitted(true);
			}
		}
	}
	
	void currentUserPictureLoaded(string message){
		
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				byte[] byteArray = cls_CompassActivity.CallStatic<byte[]>("getLoadedImage");

  				currentUserDisplayPic = new Texture2D(4,4);
        		currentUserDisplayPic.LoadImage(byteArray);
        		
				if(mPictureCallBacks != null){
					mPictureCallBacks.CurrentUserPictureLoaded(currentUserDisplayPic);
				}
			}
		}
		
	}
	
	void opponentPictureLoaded(string id){
		//print("got pic");
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.tapinator.tank.simulator.MainActivity");
				byte[] byteArray = cls_CompassActivity.CallStatic<byte[]>("getOpponentImage",id);
				
				if(byteArray == null){
					return;
				}
				//print ("1");
				//foreach (OpponentData op in opponents) {
				for (int i = 0; i < opponents.Count; i++) {
					OpponentData op = (OpponentData) opponents[i];
					//print ("2");
					if(op.opponentID.Equals(id)){
						//print ("3");
						Texture2D tex = new Texture2D(4,4);
        				tex.LoadImage(byteArray);
        				op.opponentPicture = tex;
						//print ("4");
						if(mPictureCallBacks != null){
							//print ("5");
							mPictureCallBacks.OpponentPictureLoaded(id,tex);
						}
						
						break;
					}
				}
			}
		}
		
	}
	
	
	
	//Call back setups
	
	public void setSignInCallBackListerner(SignInCallBacks cb){
		this.mSignInCallBacks = cb;
	}
	
	public void setLeaderboardListerner(LeaderboardListener cb){
		this.mLeaderboardListener = cb;
	}
	
	public void setPictureCallBackListner(PictureCallBacks cb){
		this.mPictureCallBacks = cb;
	}
	
	public void setRTMPCallBacksListner(RTMPCallBacks cb){
		this.mRTMPCallBacks = cb;
	}
	
	
}

// Interfaces

public interface SignInCallBacks{
	void SignInFailed();
	void SignInSucceeded();
}

public interface LeaderboardListener{
	void scoreSubmitted(bool highScore);
}

public interface PictureCallBacks{
	void CurrentUserPictureLoaded(Texture2D tex);
	void OpponentPictureLoaded(string id,Texture2D tex);
}

public interface RTMPCallBacks{
	void GameInvitationRecieved(string inviter);
	
	void RTMPisPreparing();
	
	void RTMPStarted();
	
	void RTMPisPreparingToEnd(string reason);
	
	void RTMPhasEnded(string reason);
	
	void RTMPPlayerAdded(string id, string displayName);
	
	void RTMPPlayerDropped(string id, string displayName);
	
	void RTMPMessageRecieved(string senderID,string message);
}
 
#endif