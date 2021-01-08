/*
 * Used for Leaderboard Score Submission
 * Used for Unlocking Achievements
 * Used for Showing Leaderboard and  Achievements
 */

using UnityEngine;
using System.Collections;

public class GCManager : SingeltonBase<GCManager> {

	// Use this for initialization

	void Start () {
		return;
		#if UNITY_ANDROID
		if(UserPrefs.isAmazonBuild){
			bool isServiceReady = AGSClient.IsServiceReady();
			
			if(!isServiceReady){
				AGSClient.ServiceReadyEvent += serviceReadyHandler;
				AGSClient.ServiceNotReadyEvent += serviceNotReadyHandler;
				
				AGSClient.Init (true, true, false);//usesLeaderboards, usesAchievements, usesWhispersync	
			}
		}
		#endif
#if UNITY_IPHONE
		GameCenterBinding.authenticateLocalPlayer();
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	#region GameCenterManager
	
	// for Submit Score to Leaderboards
	private void SubmitScore(string leaderBoradID, long score){
		return;
		# if UNITY_IPHONE
			GameCenterBinding.reportScore( score, leaderBoradID );
		# endif
		
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				if(AGSClient.IsServiceReady()){
					AGSLeaderboardsClient.SubmitScoreSucceededEvent += submitScoreSucceeded;
					AGSLeaderboardsClient.SubmitScoreFailedEvent += submitScoreFailed;
					AGSLeaderboardsClient.SubmitScore(leaderBoradID,score);
				}
			}
			else {
				if(UserPrefs.isGoogleSignedIn)
					UserPrefs.googleGameCenter.GPSPostScoreToLeaderboard( leaderBoradID, int.Parse(score.ToString()) );
			}
		# endif
	}
	
	// for Unlock Achievement
	private void UnlockAchievement(string achievementID){
		return;
		# if UNITY_IPHONE
			GameCenterBinding.reportAchievement( achievementID, 100 );
		# endif
		
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				if(AGSClient.IsServiceReady()){
					AGSAchievementsClient.UpdateAchievementFailedEvent += updateAchievementFailed;
					AGSAchievementsClient.UpdateAchievementSucceededEvent += updateAchievementSucceeded;
					AGSAchievementsClient.UpdateAchievementProgress(achievementID,100.0f);
				}
			} 
				else {
				if(UserPrefs.isGoogleSignedIn)
				{
						Debug.Log("------I am in google sign in block---");
						UserPrefs.googleGameCenter.GPSUnlockAchievement(achievementID);
				}
			}
		# endif
	}
	
	// for Showing Leaderboard
	public void ShowLeaderBoard(){
		return;
		# if UNITY_IPHONE
			GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
		# endif
		
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				if(AGSClient.IsServiceReady()){
					AGSLeaderboardsClient.ShowLeaderboardsOverlay();
				}
			}
		else {
				if(UserPrefs.isGoogleSignedIn)
					UserPrefs.googleGameCenter.GPSDisplayAllLeaderboards();
			}
		# endif
	}
	
	public void GoogleSignIn()
	{
		return;
#if UNITY_ANDROID
			UserPrefs.googleGameCenter.GPSSignOut();
			UserPrefs.googleGameCenter.GPSSignIn();
#endif 
	}
	
	// for Showing Achievements
	public void ShowAchievements(){
		return;
		# if UNITY_IPHONE
			GameCenterBinding.showAchievements();
		# endif
		
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				if(AGSClient.IsServiceReady()){
					AGSAchievementsClient.ShowAchievementsOverlay();
				}
			} 
		else {
				if(UserPrefs.isGoogleSignedIn)
					UserPrefs.googleGameCenter.GPSDisplayAchievement();
			}
//		
		# endif
	}
	
	#endregion
	
	#region BussinessLogicForAchievements
	
		
	public void ValidateAchievement(){
		return;
		//for level Achievements
		int maxUnlockLevel = 0;
		for(int i = 0; i < UserPrefs.unlockLevelsArrays.Length; i++){
			maxUnlockLevel = maxUnlockLevel + UserPrefs.unlockLevelsArrays[i]-1;		
		}
		
		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LEVELCOMPLETE)
			maxUnlockLevel++;
		
		Debug.Log("Max Unlock Level " + maxUnlockLevel);
		if(maxUnlockLevel >= 3 && !UserPrefs.isAcidHonkerCompleted){
			this.UnlockAchievement(Constants.ACIDHONKER);
			GameManager.Instance.AddCoins(Constants.ACIDHONKERCOMPLETEDREWARD);
			UserPrefs.isAcidHonkerCompleted = true;
			
		}
		else if(maxUnlockLevel >= 10 && !UserPrefs.isAcidLasherCompleted){
			this.UnlockAchievement(Constants.ACIDLASHER);
			GameManager.Instance.AddCoins(Constants.ACIDLASHERCOMPLETEDREWARD);
			UserPrefs.isAcidLasherCompleted = true;
			
		}
		else if(maxUnlockLevel >= 25 && !UserPrefs.isAcidChuffeurCompleted){
			this.UnlockAchievement(Constants.ACIDCHAUFFEUR);
			GameManager.Instance.AddCoins(Constants.ACIDCHAUFFEURCOMPLETEDREWARD);
			UserPrefs.isAcidChuffeurCompleted = true;
		}
//		else if(maxUnlockLevel >= 48 && !UserPrefs.isAcidCabbyCompleted){
//			this.UnlockAchievement(Constants.ACIDCABBY);
//			GameManager.Instance.AddCoins(Constants.ACIDCABBYCOMPLETEDREWARD);
//			UserPrefs.isAcidCabbyCompleted = true;
//		}
		
		//For Parking Achievements
		if(UserPrefs.vehiclesParked == 5 && !UserPrefs.isAcidRiderCompleted){
			this.UnlockAchievement(Constants.ACIDRIDER);
			GameManager.Instance.AddCoins(Constants.ACIDRIDERCOMPLETEDREWARD);
			UserPrefs.isAcidRiderCompleted = true;
		}
		else if(UserPrefs.vehiclesParked == 10 && !UserPrefs.isAcidDriverCompleted){
			this.UnlockAchievement(Constants.ACIDDRIVER);
			GameManager.Instance.AddCoins(Constants.ACIDDRIVERCOMPLETEDREWARD);
			UserPrefs.isAcidDriverCompleted = true;
		}
		else if(UserPrefs.vehiclesParked == 20 && !UserPrefs.isAcidParkerCompleted){
			this.UnlockAchievement(Constants.ACIDPARKER);
			GameManager.Instance.AddCoins(Constants.ACIDPARKERCOMPLETEDREWARD);
			UserPrefs.isAcidParkerCompleted = true;
		}
		else if(UserPrefs.vehiclesParked == 40 && !UserPrefs.isAcidBusManCompleted){
			this.UnlockAchievement(Constants.ACIDBUSMAN);
			GameManager.Instance.AddCoins(Constants.ACIDBUSMANCOMPLETEDREWARD);
			UserPrefs.isAcidBusManCompleted = true;
		}
		
		//Social Achievements
		if(UserPrefs.isFbFan && !UserPrefs.isAcidFbFanCompleted){
			this.UnlockAchievement(Constants.ACIDFBFAN);
			GameManager.Instance.AddCoins(Constants.ACIDFBFANCOMPLETEDREWARD);
			UserPrefs.isAcidFbFanCompleted = true;
		}
		else if(UserPrefs.isRatesUS && !UserPrefs.isAcidSupporterCompleted){
			this.UnlockAchievement(Constants.ACIDSUPPORTER);
			GameManager.Instance.AddCoins(Constants.ACIDSUPPORTERCOMPLETEDREWARD);
			UserPrefs.isAcidSupporterCompleted = true;
		}
		else if(UserPrefs.isTwitterAnnouncer && !UserPrefs.isAcidTwitterAnnouncerCompleted){
			this.UnlockAchievement(Constants.ACIDTWITTERANNOUNCER);
			GameManager.Instance.AddCoins(Constants.ACIDTWITTERANNOUNCERCOMPLETEDREWARD);
			UserPrefs.isAcidTwitterAnnouncerCompleted = true;
		}
		
		//Environment Achievements
		if(UserPrefs.episodeUnlockArray[1] && !UserPrefs.isAcidExplorerCompleted){
			this.UnlockAchievement(Constants.ACIDEXPLORER);
			GameManager.Instance.AddCoins(Constants.ACIDEXPLORERCOMPLETEDREWARD);
			UserPrefs.isAcidExplorerCompleted = true;
		}
		// else if(UserPrefs.episodeUnlockArray[2] && !UserPrefs.isAcidShoppingKingCompleted){
			// this.UnlockAchievement(Constants.ACIDSHOPPINGKING);
			// GameManager.Instance.AddCoins(Constants.ACIDSHOPPINGKINGCOMPLETEDREWARD);
			// UserPrefs.isAcidShoppingKingCompleted = true;
		// }
//		else if(UserPrefs.episodeUnlockArray[3] && !UserPrefs.isAcidAllOutCompleted){
//			this.UnlockAchievement(Constants.ACIDALLOUT);
//			GameManager.Instance.AddCoins(Constants.ACIDALLOUTCOMPLETEDREWARD);
//			UserPrefs.isAcidAllOutCompleted = true;
//		}
		
		//Vehicles Achievements
//		if(UserPrefs.vehicleUnlockArray[1] && !UserPrefs.isAcidThrillLoverCompleted){
//			this.UnlockAchievement(Constants.ACIDTHIRLLLOVER);
//			GameManager.Instance.AddCoins(Constants.ACIDTHIRLLLOVERCOMPLETEDREWARD);
//			UserPrefs.isAcidThrillLoverCompleted = true;
//		}
//		else if(UserPrefs.vehicleUnlockArray[2] && !UserPrefs.isAcidMasterBlasterCompleted){
//			this.UnlockAchievement(Constants.ACIDMASTERBLASTER);
//			GameManager.Instance.AddCoins(Constants.ACIDMASTERBLASTERCOMPLETEDREWARD);
//			UserPrefs.isAcidMasterBlasterCompleted = true;
//		}
//		else if(UserPrefs.vehicleUnlockArray[3] && !UserPrefs.isAcidTurnKeyCompleted){
//			this.UnlockAchievement(Constants.ACIDTURNKEY);
//			GameManager.Instance.AddCoins(Constants.ACIDTURNKEYCOMPLETEDREWARD);
//			UserPrefs.isAcidTurnKeyCompleted = true;
//		}
		
		//Coins Achievement
		if(UserPrefs.isCoinsPurchsed && !UserPrefs.isAcidManOfMeansCompleted){
			this.UnlockAchievement(Constants.ACIDMANOFMEANS);
			GameManager.Instance.AddCoins(Constants.ACIDMANOFMEANSCOMPLETEDREWARD);
			UserPrefs.isAcidManOfMeansCompleted = true;
		}	
		
	}
	
		
	#endregion
	
	#region BusinessLogicForLeaderBoards
	public void ValidateScore(long vehiclesParked, long coinsCollected){
		return;
		if(vehiclesParked>0){
			this.SubmitScore(Constants.LIDMASTERBLASTER,vehiclesParked);
		}
		if(coinsCollected>0){
			this.SubmitScore(Constants.LIDTHEBENEFACTOR,coinsCollected);
		}
	}
	#endregion
	
	#region AmazonGameCircle
	
	private void serviceNotReadyHandler (string error) {}	      
	private void serviceReadyHandler () {}
	
	private void updateAchievementSucceeded(string achievementId){}		
	private void updateAchievementFailed(string achievementId, string error){}
	
	
	public void OnGPGUnlockAchievementResult(string result){}
	
	  
	private void submitScoreSucceeded(string leaderboardId){}      
	private void submitScoreFailed(string leaderboardId, string error){} 
	
	#endregion
	
}
