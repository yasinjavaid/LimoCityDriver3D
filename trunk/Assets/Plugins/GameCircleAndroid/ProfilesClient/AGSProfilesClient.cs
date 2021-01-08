using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
///  Profile client used to get information on the currently logged in player
/// </summary>
public class AGSProfilesClient : MonoBehaviour{
	
	private static AndroidJavaObjectFrameManagerWrapper JavaObject;
	
	private static readonly string PROXY_CLASS_NAME = "com.amazon.ags.api.unity.ProfilesClientProxyImpl"; 
	
	/// <summary>
	/// Event called when alias request succeeds
	/// </summary>
	/// <param name="playerAliasName">the name of the logged in user</param>	
	public static event Action<AGSProfile> PlayerAliasReceivedEvent;
	
	/// <summary>
	/// Event called when alias request fails
	/// </summary>
	/// <param name="failureReason">a string indicating the failure reason</param>	
	public static event Action<string> PlayerAliasFailedEvent;
	 
	static AGSProfilesClient(){

		// find the plugin instance
		JavaObject = new AndroidJavaObjectFrameManagerWrapper(); 
		using( var PluginClass = new AndroidJavaClass( PROXY_CLASS_NAME ) ){
			JavaObject.setAndroidJavaObject(PluginClass.CallStatic<AndroidJavaObject>( "getInstance" ));
		}

	}

	/// <summary>
	/// Request the local player profile information
	/// </summary>
	public static void RequestLocalPlayerProfile(){
		JavaObject.Call( "requestLocalPlayerProfile" );
	}

	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>	
	public static void PlayerAliasReceived( string json ){
		if( PlayerAliasReceivedEvent != null ){
			var ht = json.hashtableFromJson();
			PlayerAliasReceivedEvent( AGSProfile.fromHashtable(ht) );
		}
	}
	
	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>		
	public static void PlayerAliasFailed( string json ){
		if( PlayerAliasFailedEvent != null ){
			var ht = json.hashtableFromJson();
			string error = GetStringFromHashtable(ht,"error");
			PlayerAliasFailedEvent( error );
		}
	}
	
	/// <summary>
	/// Gets the string from hashtable.
	/// </summary>
	/// <returns>
	/// The string from hashtable.
	/// </returns>
	/// <param name='ht'>
	/// Ht.
	/// </param>
	/// <param name='key'>
	/// Key.
	/// </param>
	private static string GetStringFromHashtable(Hashtable ht, string key){
		string val = null;
		if(ht.Contains(key)){
			val = ht[key].ToString();	
		}
		return val;
	}	
}
#endif