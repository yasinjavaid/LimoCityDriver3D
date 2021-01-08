using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
/// <summary>
/// AGS syncable list.
/// </summary>
public class AGSSyncableList : AGSSyncable
{
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableList"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableList(AndroidJavaObject javaObject) : base(javaObject)
	{
	}
	
	/// <summary>
	/// Sets the max size of this List..
	/// </summary>
	/// <remarks>
	/// Sets the max size of this List.  size must be positive
    /// and no greater than MAX_SIZE_LIMIT.  If size is smaller than the 
    /// current size of this SyncableNumberList in the cloud, then its size 
    /// will remain.  In other words, the size of SyncableNumberList can 
    /// never shrink.
	/// </remarks>
	/// <param name='size'>
	/// the max size of this List
	/// </param>	
    public void SetMaxSize(int size){
		javaObject.Call( "setMaxSize", size );	
	}
    

	/// <summary>
	/// Gets the size of the max.
	/// </summary>
	/// <returns>
	/// The max size.
	/// </returns>
    public int GetMaxSize(){
		return javaObject.Call<int>( "getMaxSize" );	
	}
	
	/// <summary>
	/// bool indicating if a value is set
	/// </summary>
	/// <returns>
	/// bool indicating if a value is set
	/// </returns>
    public bool IsSet(){
		return javaObject.Call<bool>( "isSet" );
	}
	
	/// <summary>
	/// Add the specified val and metadata.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	/// <param name='metadata'>
	/// Metadata.
	/// </param>
    public void Add(String val, Dictionary<String, String> metadata){
			javaObject.Call ("add", val, DictionaryToAndroidHashMap(metadata));	
	}
	
	/// <summary>
	/// Add the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
    public void Add(String val){
		javaObject.Call( "add", val );				
	}	
	

}
#endif