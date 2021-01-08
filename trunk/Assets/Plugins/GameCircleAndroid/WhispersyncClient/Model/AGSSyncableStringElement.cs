using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable string element.
/// </summary>
public class AGSSyncableStringElement : AGSSyncableElement
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableStringElement"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableStringElement(AndroidJavaObject javaObject) : base(javaObject){
		
	}	

	/// <summary>
	/// Gets the value.
	/// </summary>
	/// <returns>
	/// The value.
	/// </returns>
	public string GetValue(){
		return javaObject.Call<string>("getValue");
	}	
	
}
#endif