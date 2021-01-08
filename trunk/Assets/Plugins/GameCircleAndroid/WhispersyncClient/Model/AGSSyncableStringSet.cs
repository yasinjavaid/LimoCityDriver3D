using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable string set.
/// </summary>
public class AGSSyncableStringSet : AGSSyncable
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableStringSet"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableStringSet(AndroidJavaObject javaObject) : base(javaObject)
	{
	}

	/// <summary>
	/// Add the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
    public void Add(string val){
			javaObject.Call("add",val);
	}

    /**
     * Adds a SyncableStringElement to this SyncableStringSet with the
     * given string value.  value cannot be null.
     * @param value The value to be added to this SyncableStringSet.
     * @param metadata the metadata associated with the SyncableStringElement
     *                 to be created.  Metadata can be null.
     * @throws java.lang.IllegalArgumentException if value is null or empty.
     * 
     * @see SyncableStringElement
     */
    public void Add(string val, Dictionary<string, string> metadata){
			javaObject.Call ("add", val, DictionaryToAndroidHashMap(metadata));	
	}

	/// <summary>
	/// Get the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
    public AGSSyncableStringElement Get(string val){
		return GetAGSSyncable<AGSSyncableStringElement>(val);
	}

	/// <summary>
	/// Contains the specified val.
	/// </summary>
	/// <param name='val'>
	/// If set to <c>true</c> value.
	/// </param>
    public bool Contains(string val){
		return javaObject.Call<bool>("contains",val);
	}

	/// <summary>
	/// Ises the set.
	/// </summary>
	/// <returns>
	/// The set.
	/// </returns>
    public bool IsSet(){
		return javaObject.Call<bool>("isSet");
	}
    
	/// <summary>
	/// Gets the values.
	/// </summary>
	/// <returns>
	/// The values.
	/// </returns>
    public HashSet<AGSSyncableStringElement> GetValues(){
		
		AndroidJNI.PushLocalFrame(10);

		//header states that this is non-null
		HashSet<AGSSyncableStringElement> returnSet = new HashSet<AGSSyncableStringElement>();

		AndroidJavaObject stringSet = javaObject.Call<AndroidJavaObject>( "getValues" );
		
		if(stringSet == null){
			return returnSet;
		}
		
		//get iterator from string set
		AndroidJavaObject iterator = stringSet.Call<AndroidJavaObject>( "iterator" );
		
		if(iterator == null){
			return returnSet;	
		}
		
		//could do size here...could...
		AndroidJavaObject jo;
		
		//iterate until it has been... iterated...
		while (  iterator.Call<bool>( "hasNext" ) ){
			jo = iterator.Call<AndroidJavaObject>( "next" );
			if(jo != null){
				returnSet.Add(new AGSSyncableStringElement(jo));
			}
		}
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);

		return returnSet;	
	}
}
#endif