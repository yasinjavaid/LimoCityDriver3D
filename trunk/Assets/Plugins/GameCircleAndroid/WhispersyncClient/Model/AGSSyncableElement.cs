using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
///  Base syncable type that supports metadata and timestamp information
/// </summary>
public class AGSSyncableElement :AGSSyncable
{
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableElement"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableElement(AndroidJavaObject javaObject) : base(javaObject){

	}

	/// <summary>
	///  The time in which this element was set as the number of seconds 
    /// elapsed since January 1, 1970, 00:00:00 GMT.
	/// </summary>
	/// <returns>time this element was set</returns>	
	public long GetTimestamp(){
		return javaObject.Call<long>( "getTimestamp" );
	}

	/// <summary>
    /// Optional metadata associated with this SyncableElement.  A
    /// non-null, unmodifiable map is returned.
	/// </summary>
	/// <returns>dictionary containing key,value map of metadata</returns>		
	public Dictionary<string,string> GetMetadata(){
		
		Dictionary<string,string> dictionary = new Dictionary<string, string>();
		
		AndroidJNI.PushLocalFrame(10);
		AndroidJavaObject javaMap = javaObject.Call<AndroidJavaObject>("getMetadata");
		if(javaMap == null){
			return dictionary;	
		}
		
		AndroidJavaObject javaSet = javaMap.Call<AndroidJavaObject>("keySet");
		if(javaSet == null){
			return dictionary;	
		}

				
		AndroidJavaObject javaIterator = javaSet.Call<AndroidJavaObject>("iterator");
		if(javaIterator == null){
			return dictionary;	
		}
		
		string key, val;
		while( javaIterator.Call<bool>("hasNext") ){
			key = javaIterator.Call<string>("next");
			if(key != null){
				val = javaMap.Call<string>("get",key);
				if(val != null){
					dictionary.Add (key,val);	
				}
			}	
		}	
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);
	
		
		return dictionary;		
	}


}
#endif