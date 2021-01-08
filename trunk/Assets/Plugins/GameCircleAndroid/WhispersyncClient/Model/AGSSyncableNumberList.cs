using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable number list.
/// </summary>
public class AGSSyncableNumberList : AGSSyncableList
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableNumberList"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableNumberList(AndroidJavaObject javaObject) : base(javaObject)
	{
	}

    
  	/// <summary>
  	///  Add the specified val. 
  	/// </summary>
  	/// <param name='val'>
  	///  Value. 
  	/// </param>
    public void Add(long val){
		javaObject.Call ( "add", val );	
	}

	/// <summary>
	///  Add the specified val. 
	/// </summary>
	/// <param name='val'>
	///  Value. 
	/// </param>
    public void Add(double val){
		javaObject.Call ("add", val );	
	}

	/// <summary>
	///  Add the specified val. 
	/// </summary>
	/// <param name='val'>
	///  Value. 
	/// </param>
    public void Add(int val){
		javaObject.Call( "add", val );	
	}
    
    /// <summary>
    ///  Add the specified val and metadata. 
    /// </summary>
    /// <param name='val'>
    ///  Value. 
    /// </param>
    /// <param name='metadata'>
    ///  Metadata. 
    /// </param>
    public void Add(long val, Dictionary<String, String> metadata){
			javaObject.Call ("add", val, DictionaryToAndroidHashMap(metadata));	
	}	

	/// <summary>
	///  Add the specified val and metadata. 
	/// </summary>
	/// <param name='val'>
	///  Value. 
	/// </param>
	/// <param name='metadata'>
	///  Metadata. 
	/// </param>
    public void Add(double val, Dictionary<String, String> metadata){
			javaObject.Call ("add", val, DictionaryToAndroidHashMap(metadata));	
	}

   	/// <summary>
   	///  Add the specified val and metadata. 
   	/// </summary>
   	/// <param name='val'>
   	///  Value. 
   	/// </param>
   	/// <param name='metadata'>
   	///  Metadata. 
   	/// </param>
    public void Add(int val, Dictionary<String, String> metadata){
			javaObject.Call ("add", val, DictionaryToAndroidHashMap(metadata));	
	}

	/// <summary>
	/// Gets the values.
	/// </summary>
	/// <returns>
	/// The values.
	/// </returns>
    public AGSSyncableNumberElement[] GetValues(){
		AndroidJNI.PushLocalFrame(10);
		AndroidJavaObject[] records = javaObject.Call<AndroidJavaObject[]>("getValues");
		
		if(records == null || records.Length == 0){
			return null;
		}
		
		AGSSyncableNumberElement[] returnElements =
				new AGSSyncableNumberElement[records.Length];
		
		for( int i = 0; i < records.Length; ++i){
			returnElements[i] = new AGSSyncableNumber(records[i]);
		}
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);

		return returnElements;
	}
	
}
#endif