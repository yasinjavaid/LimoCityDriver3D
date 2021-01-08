using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
/// <summary>
/// AGS syncable number.
/// </summary>
public class AGSSyncableNumber : AGSSyncableNumberElement
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableNumber"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableNumber(AndroidJavaObject javaObject) : base(javaObject){
		
	}
	
	/// <summary>
	/// Set the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	public void Set(long val){
		javaObject.Call( "set", val );
	}

  	/// <summary>
  	/// Set the specified val.
  	/// </summary>
  	/// <param name='val'>
  	/// Value.
  	/// </param>
	public void Set(double val){
		javaObject.Call( "set", val );
	}	

	/// <summary>
	/// Set the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	public void Set(int val){
		javaObject.Call( "set", val );
	}
	
 	/// <summary>
 	/// Set the specified val.
 	/// </summary>
 	/// <param name='val'>
 	/// Value.
 	/// </param>
	public void Set(string val){
		javaObject.Call ( "set", val);
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
	public void Set(long val, Dictionary<String,String> metadata){
		javaObject.Call( "set", val, DictionaryToAndroidHashMap(metadata) );
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
	public void Set(double val, Dictionary<String,String> metadata){
		javaObject.Call ("set", val, DictionaryToAndroidHashMap(metadata));	
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
	public void Set(int val, Dictionary<String,String> metadata){
		javaObject.Call ("set", val, DictionaryToAndroidHashMap(metadata));	
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
	public void Set(string val, Dictionary<String,String> metadata){
		javaObject.Call ("set", val, DictionaryToAndroidHashMap(metadata));	
	}

  	/// <summary>
  	/// returns whether a value is set
  	/// </summary>
  	/// <returns>
  	/// bool indicating if a value has been set
  	/// </returns>
	public bool IsSet(){
		return javaObject.Call<bool>("isSet");
	}

}
#endif