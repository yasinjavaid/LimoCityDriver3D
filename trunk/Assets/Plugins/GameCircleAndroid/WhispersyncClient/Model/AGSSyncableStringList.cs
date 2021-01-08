using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable string list.
/// </summary>
public class AGSSyncableStringList : AGSSyncableList
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableStringList"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableStringList(AndroidJavaObject javaObject) : base(javaObject)
	{
	}

	/// <summary>
	/// Returns an immutable copy of the elements of this list as an array
	/// </summary>
	/// <returns>
	/// The values.
	/// </returns>
    public AGSSyncableString[] GetValues(){
		AndroidJNI.PushLocalFrame(10);

		AndroidJavaObject[] records = javaObject.Call<AndroidJavaObject[]>("getValues");
		
		if(records == null || records.Length == 0){
			return null;
		}
		
		AGSSyncableString[] returnElements =
				new AGSSyncableString[records.Length];
		
		for( int i = 0; i < records.Length; ++i){
			returnElements[i] = new AGSSyncableString(records[i]);
		}
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);

		return returnElements;
	}
	
}
#endif