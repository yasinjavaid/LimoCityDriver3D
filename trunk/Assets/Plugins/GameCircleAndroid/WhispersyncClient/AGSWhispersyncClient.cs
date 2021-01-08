using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
/// <summary>
/// WhispersyncClient used for interacting with synchronized game objects
/// </summary>
public class AGSWhispersyncClient : MonoBehaviour
{
	private static AndroidJavaObjectFrameManagerWrapper javaObject;
	
	private static readonly string PROXY_CLASS_NAME = "com.amazon.ags.api.unity.WhispersyncClientProxyImpl"; 
	
	
	/// <summary>
	/// Event called when new data is available
	/// </summary>
	public static event Action OnNewCloudDataEvent;

	static AGSWhispersyncClient()
	{
		javaObject = new AndroidJavaObjectFrameManagerWrapper(); 
		using( var PluginClass = new AndroidJavaClass( PROXY_CLASS_NAME ) ){
			javaObject.setAndroidJavaObject(PluginClass.CallStatic<AndroidJavaObject>( "getInstance" ));
		}
	}
	
	 /// <summary>
	 /// gets the root game datamap 
	 /// </summary>
	 /// <returns>Game datamap</returns>
	public static AGSGameDataMap GetGameData( )
	{
		AndroidJavaObject jo = javaObject.Call<AndroidJavaObject>( "getGameData" );
		if(jo != null){
			return new AGSGameDataMap(jo);
		}
		return null;
	}
	
	 /// <summary>
	 /// Manually triggers a background thread to synchronize in-memory game data with local storage and the cloud.
	 /// </summary>
	public static void Synchronize(){
		javaObject.Call( "synchronize" );	
	}

	 /// <summary>
	 /// Manually triggers a background thread to write in-memory game data to only the local storage.
	 /// </summary>	
	public static void Flush(){
		javaObject.Call( "flush" );	
	}

	/// <summary>
	///  callback method for native code to communicate events back to unity
	/// </summary>			
	public static void OnNewCloudData()
	{
		if( OnNewCloudDataEvent != null )
		{		
			OnNewCloudDataEvent(  );
		}
	}

}
#endif