using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Enum used for positioning gamecircle toast messages
/// </summary>
public enum GameCirclePopupLocation
{
	BOTTOM_LEFT,
	BOTTOM_CENTER,
	BOTTOM_RIGHT,
	TOP_LEFT,
	TOP_CENTER,
	TOP_RIGHT
}
#if UNITY_ANDROID
/// <summary>
/// AGSClient used for init and global GameCircle features
/// </summary>
public class AGSClient : MonoBehaviour
{
	
	/// <summary>
	/// Event called when GameCircle initialization succeeds and clients are ready to use
	/// </summary>
	public static event Action ServiceReadyEvent;
	
	/// <summary>
	/// Event called when GameCircle initialization fails
	/// </summary>
	/// <param name="failureReason">a string indicating the reason for the initialization failure</param>
	public static event Action<string> ServiceNotReadyEvent;
	
	private static AndroidJavaObjectFrameManagerWrapper JavaObject;
	
	private static readonly string PROXY_CLASS_NAME = "com.amazon.ags.api.unity.AmazonGamesClientProxyImpl"; 
	
	private static bool IsReady = false;

	
	static AGSClient()
	{
		JavaObject = new AndroidJavaObjectFrameManagerWrapper(); 
		using( var PluginClass = new AndroidJavaClass( PROXY_CLASS_NAME ) ){
			JavaObject.setAndroidJavaObject(PluginClass.CallStatic<AndroidJavaObject>( "getInstance" ));
		}

	}
	
	/// <summary>
	/// Initializes this AGSClient.  The serviceReadyEvent or the serviceNotReady event will be called
	/// upon completion
	/// </summary>
	public static void Init()
	{
		Init(false, false, false );
	}
	
	
	/// <summary>
	/// Initializes this AGSClient.  The serviceReadyEvent or the serviceNotReady event will be called
	/// upon completion
	/// </summary>
	/// <param name="supportsLeaderboards">bool indicating if this game uses leaderboards</param>
	/// <param name="supportsAchievements">bool indicating if this game uses achievements</param>
	/// <param name="supportsWhispersync">bool indicating if this game uses whispersync</param>
	public static void Init(bool supportsLeaderboards, bool supportsAchievements, bool supportsWhispersync )
	{
		JavaObject.Call( "init", supportsLeaderboards, supportsAchievements, supportsWhispersync );
	}
	
	
	/// <summary>
	/// Sets the pop up location for toast notifications
	/// </summary>
	/// <param name="location">location enum value indicating the preferred position of toast</param>
	public static void SetPopUpLocation( GameCirclePopupLocation location )
	{
		JavaObject.Call( "setPopUpLocation", location.ToString() );
	}
	
	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static void ServiceReady( string empty )
	{
		Debug.Log ("Client GameCircle - Service is ready");
		
		IsReady = true;
		if( ServiceReadyEvent != null )
			ServiceReadyEvent();
	}
	
	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static bool IsServiceReady(){
		return IsReady;	
	}
	
	/// <summary>
	/// Pauses game time played tracking.  This should be called when the game leaves the foreground
	/// </summary>
	public static void release(){
		JavaObject.Call ("release");
	}
	

	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>
	public static void ServiceNotReady( string param )
	{
		IsReady = false;
		if( ServiceNotReadyEvent != null )
			ServiceNotReadyEvent( param );
	}

}
#endif