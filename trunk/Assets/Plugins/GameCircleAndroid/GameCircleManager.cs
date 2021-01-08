using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Game circle manager.
/// </summary>
/// <remarks>
/// Helper script for managing native to unity messages
/// </remarks>
#if UNITY_ANDROID
public class GameCircleManager : MonoBehaviour
{
	
	void Awake()
	{
		// Set the GameObject name to the class name for easy access from native code
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
	}

	public void serviceReady( string empty )
	{		
		Debug.Log ("GameCircleManager - serviceReady");
		
		AGSClient.
			ServiceReady(empty);
	}
	
	public void serviceNotReady( string param )
	{
		Debug.Log ("GameCircleManager - serviceNotReady");

		AGSClient.
			ServiceNotReady( param );
	}
	
	public void playerAliasReceived( string json )
	{
		Debug.Log ("GameCircleManager - playerAliasReceived");
		
		AGSProfilesClient.
			PlayerAliasReceived( json );
	}
	
	public void playerAliasFailed( string json )
	{
		Debug.Log ("GameCircleManager - playerAliasFailed");	
		AGSProfilesClient.
			PlayerAliasFailed( json );
	}
	
	public void submitScoreFailed( string json )
	{
		Debug.Log ("GameCircleManager - submitScoreFailed");

		AGSLeaderboardsClient.
			SubmitScoreFailed( json );
	}

	public void submitScoreSucceeded( string json )
	{
		Debug.Log ("GameCircleManager - submitScoreSucceeded");
		AGSLeaderboardsClient.
			SubmitScoreSucceeded( json );
	}

	public void requestLeaderboardsFailed( string json )
	{
		Debug.Log ("GameCircleManager - requestLeaderboardsFailed");
		AGSLeaderboardsClient.
			RequestLeaderboardsFailed( json );
	}

	public void requestLeaderboardsSucceeded( string json )
	{	
		Debug.Log ("GameCircleManager - requestLeaderboardsSucceeded");
		AGSLeaderboardsClient.
			RequestLeaderboardsSucceeded(json);
	}

	public void requestLocalPlayerScoreFailed( string json )
	{
		Debug.Log ("GameCircleManager - requestLocalPlayerScoreFailed");
		AGSLeaderboardsClient.
			RequestLocalPlayerScoreFailed( json );
	}

	public void requestLocalPlayerScoreSucceeded( string json )
	{
		Debug.Log ("GameCircleManager - requestLocalPlayerScoreFailed");
		AGSLeaderboardsClient.
				RequestLocalPlayerScoreSucceeded(json);
	}

	public void updateAchievementSucceeded( string json )
	{
		Debug.Log ("GameCircleManager - updateAchievementSucceeded");
		AGSAchievementsClient.UpdateAchievementSucceeded( json );
	}
	
	public void updateAchievementFailed( string json )
	{
		Debug.Log ("GameCircleManager - updateAchievementsFailed");
		AGSAchievementsClient.
			UpdateAchievementFailed( json );
	}
	
	public void requestAchievementsSucceeded( string json )
	{	
		Debug.Log ("GameCircleManager - requestAchievementsSucceeded");

		AGSAchievementsClient.
			RequestAchievementsSucceeded( json );
	}
	
	public void requestAchievementsFailed( string json )
	{
		Debug.Log ("GameCircleManager -  requestAchievementsFailed");
		AGSAchievementsClient.
			RequestAchievementsFailed( json );
	}

	public void onNewCloudData( string empty ){
		AGSWhispersyncClient.OnNewCloudData();	
	}
	
	public void OnApplicationFocus(Boolean focusStatus){
		if(!AGSClient.IsServiceReady()){
			return;
		}
		
		if(!focusStatus){
			AGSClient.release();	
		}
	}
	
}

#endif