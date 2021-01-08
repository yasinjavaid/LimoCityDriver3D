using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
/// <summary>
/// Client used to submit and read achievements for the current logged in or guest player
/// </summary>
public class AGSAchievementsClient : MonoBehaviour{
	
	private static AndroidJavaObjectFrameManagerWrapper JavaObject;
	
	private static readonly string PROXY_CLASS_NAME = "com.amazon.ags.api.unity.AchievementsClientProxyImpl"; 
	
	/// <summary>
	/// Event called when a request to update achievements fails
	/// </summary>
	/// <param name="achievementId">the id of the achievement that failed to update</param>
	/// <param name="failureReason">a string indicating the failure reason</param>
	public static event Action<string,string> UpdateAchievementFailedEvent;
	
	/// <summary>
	/// Event called when a request to update achievements succeeds
	/// </summary>
	/// <param name="achievementId">the id of the achievement that has been updated</param>
	public static event Action<string> UpdateAchievementSucceededEvent;
	
	/// <summary>
	/// Event called when a request to get all achievements succeeds
	/// </summary>
	/// <param name="achievementsList"></param>	
	public static event Action<List<AGSAchievement>> RequestAchievementsSucceededEvent;
	

	/// <summary>
	/// Event called when a request to get all achievements has failed
	/// </summary>
	/// <param name="failureReason">a string indicating the reason for the request failure</param>	
	public static event Action<string> RequestAchievementsFailedEvent;

	
	static AGSAchievementsClient(){
		JavaObject = new AndroidJavaObjectFrameManagerWrapper(); 
		using( var PluginClass = new AndroidJavaClass( PROXY_CLASS_NAME ) ){
			JavaObject.setAndroidJavaObject(PluginClass.CallStatic<AndroidJavaObject>( "getInstance" ));
		}
	}
	
	/// <summary>
	/// updates an achievement
	/// </summary>
	/// <remarks>
	/// If a value outside of range is submitted, it is capped at 100 or 0.
    /// If submitted value is less than the stored value, the update is ignored.
	/// </remarks>
	/// <param name="achievementId">the id of the achievement to update</param>
	/// <param name="percentComplete">a float between 0.0f and 100.0f</param>	
	public static void UpdateAchievementProgress( string achievementId, float progress ){
		JavaObject.Call( "updateAchievementProgress", achievementId, progress );	
	}

	
	/// <summary>
	///  requests a list of all achievements
	/// </summary>
	/// <remarks>
	/// Registered updateAchievementSucceededEvents will recieve response
    /// The list returned in the response includes all achievements for the game.
    /// Each Achievement object in the list includes the current players
    /// progress toward the Achievement.
	/// </remarks>
	public static void RequestAchievements(){			
		JavaObject.Call( "requestAchievements" );	
	}

	/// <summary>
	///  shows the Amazon GameCircle Overlay
	/// </summary>
	public static void ShowAchievementsOverlay(){
		JavaObject.Call( "showAchievementsOverlay" );
	}
	
	/**
	 * callback method for native code
	 **/
	public static void RequestAchievementsSucceeded( string json ){
		if( RequestAchievementsSucceededEvent != null ){
			var Achievements = new List<AGSAchievement>();
			var list = json.arrayListFromJson();
			foreach( Hashtable ht in list ){
				Achievements.Add( AGSAchievement.fromHashtable( ht ) );
			}
			RequestAchievementsSucceededEvent( Achievements );
		}
	}
	
	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static void UpdateAchievementFailed( string json ){
		if( UpdateAchievementFailedEvent != null ){
			var ht = json.hashtableFromJson();
			string achievementId = GetStringFromHashtable(ht,"achievementId");
			string error = GetStringFromHashtable(ht,"error");
			UpdateAchievementFailedEvent( achievementId, error );
		}
	}

	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static void UpdateAchievementSucceeded( string json ){
		if( UpdateAchievementSucceededEvent != null ){
			var ht = json.hashtableFromJson();
			string AchievementId = GetStringFromHashtable(ht,"achievementId");
			UpdateAchievementSucceededEvent(AchievementId);
		}
	}
	
	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static void RequestAchievementsFailed( string json ){
		if( RequestAchievementsFailedEvent != null ){
			var ht = json.hashtableFromJson();
			string error = GetStringFromHashtable(ht,"error");
			RequestAchievementsFailedEvent(error);
		}
	}
	
	private static string GetStringFromHashtable(Hashtable ht, string key){
		string val = null;
		if(ht.Contains(key)){
			val = ht[key].ToString();	
		}
		return val;
	}
}
#endif