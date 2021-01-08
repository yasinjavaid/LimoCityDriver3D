using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//will need to move ifdefs around for iOS - possibly just down to the static initializer where we setup the plugin
#if UNITY_ANDROID
/// <summary>
/// AGS syncable string.
/// </summary>
public class AGSSyncableString : AGSSyncableStringElement
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableString"/> class.
	/// </summary>
	/// <param name='JavaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableString(AndroidJavaObject javaObject) : base(javaObject){
		
	}	
	
	/// <summary>
	/// Set the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
    public void Set(string val){
		javaObject.Call("set",val);
	}

	/// <summary>
	/// Set the specified val and metadata.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	/// <param name='metadata'>
	/// Metadata.
	/// </param>
    public void Set(string val, Dictionary<string, string> metadata){
			javaObject.Call ("set", val, DictionaryToAndroidHashMap(metadata));	
	}

	/// <summary>
	/// returns true if a value is set
	/// </summary>
	/// <returns>
	/// bool indicating if this has been set
	/// </returns>
    public bool IsSet(){
		return javaObject.Call<bool>("isSet");
	}
	
}
#endif